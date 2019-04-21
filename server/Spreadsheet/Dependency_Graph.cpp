/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Spreadsheet/Dependency_Graph.cpp                             *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/17/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Dependency_Graph:                                                                           *
 *   The dependency_graph class is a directed graph that represents dependencies of objects    *
 *   towards each other.                                                                       *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "Dependency_Graph.hpp"

namespace RS {

	/*-----------------------------------------------------------------------------------------*
	 * Constructor/Destructor Methods                                                          *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Nested Node class constructor.
	 *
	 * @return A new Node instance.
	 */
	Dependency_Graph::Node::Node() : dependents_(new std::unordered_set<std::string>()),
			dependees_(new std::unordered_set<std::string>()) {}

	/*
	 * Nested Node class destructor.
	 *
	 */
	Dependency_Graph::Node::~Node() {
		delete dependents_;
		delete dependees_;
	}

	/*
	 * Paramaterized constructor.
	 *
	 * @return A new Dependency_Graph instance with a value of the provided type.
	 */
	Dependency_Graph::Dependency_Graph() : size_(0) {}

	/*
	 * Destructor.
	 *
	 */
	Dependency_Graph::~Dependency_Graph() {
		for (auto &pair : graph_) {
			delete pair.second;
		}
	}

	/*-----------------------------------------------------------------------------------------*
	 * Accessor Methods                                                                        *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Get dependents for node.
	 *
	 * @return A set of dependents for the node.
	 */
	std::unordered_set<std::string>* Dependency_Graph::Node::Dependents() {
		return dependents_;
	}

	/*
	 * Get dependees for node.
	 *
	 * @return A set of dependees for the node.
	 */
	std::unordered_set<std::string>* Dependency_Graph::Node::Dependees() {
		return dependees_;
	}

	int Dependency_Graph::Size() {
		return size_;
	}

	bool Dependency_Graph::Has_Dependents(const std::string &s) const {
		return Has_Relation(s, Relation::Dependents);
	}

	bool Dependency_Graph::Has_Dependees(const std::string &s) const {
		return Has_Relation(s, Relation::Dependees);
	}

	const std::unordered_set<std::string>& Dependency_Graph::Get_Dependents(const std::string &s) {
		std::unordered_set<std::string> *set = Get_Relation_Set(s, Relation::Dependents);
		return *set;
	}

	const std::unordered_set<std::string>& Dependency_Graph::Get_Dependees(const std::string &s) {
		std::unordered_set<std::string> *set = Get_Relation_Set(s, Relation::Dependees);
		return *set;
	}

	const std::unordered_set<std::string>& Dependency_Graph::GetDirectDependents(const std::string &s) {
		Dependency_Graph dep;


		return dep.Get_Dependents(s);
	}


	bool Dependency_Graph::Has_Circular_Dependency(const std::string &cells, const std::string& contents, const std::vector<std::string>& dependencies) {
		
		std::unordered_set<std::string> cell_deps = GetDirectDependents(cells);

		for(std::string it : cell_deps) {

				if(it.compare(contents) == 0) {
					return true;
				}
			}

		return false;
	}


	// bool Dependency_Graph::Has_Circular_Dependency(const std::unordered_set<std::string> &cells, const std::unordered_set<std::string>& contents) {
	// 	return false;
	// }

	/*-----------------------------------------------------------------------------------------*
	 * Mutator Methods                                                                         *
	 *-----------------------------------------------------------------------------------------*/

	void Dependency_Graph::Add_Dependency(const std::string &s, const std::string &t) {
		if (Add_Relation(s, t, Relation::Dependents) && Add_Relation(t, s, Relation::Dependees)) {
			size_++;
		}
	}

	void Dependency_Graph::Remove_Dependency(const std::string &s, const std::string &t) {
		if (Remove_Relation(s, t, Relation::Dependents) && Remove_Relation(t, s, Relation::Dependees)) {
			size_--;
		}
	}

	void Dependency_Graph::Replace_Dependents(const std::string &s, const std::unordered_set<std::string> &set) {
		Replace_Relation(s, set, Relation::Dependents);
	}

	void Dependency_Graph::Replace_Dependees(const std::string &s, const std::unordered_set<std::string> &set) {
		Replace_Relation(s, set, Relation::Dependees);
	}

	/*-----------------------------------------------------------------------------------------*
	 * Helper Methods                                                                          *
	 *-----------------------------------------------------------------------------------------*/

	std::unordered_set<std::string>* Dependency_Graph::Get_Relation_Set(const std::string &key, Relation r) {
		if (key.empty()) { return nullptr; }

		auto it = graph_.find(key);
		if (it != graph_.end()) {
			auto n = it->second;
			if (r == Relation::Dependents) {
				return n->Dependents();
			}
			else {
				return n->Dependees();
			}
		}

		return nullptr;
	}

	bool Dependency_Graph::Has_Relation(const std::string &key, Relation r) const {
		if (key.empty()) { return false; }

		auto it = graph_.find(key);
		if (it != graph_.end()) {
			auto n = it->second;
			if (r == Relation::Dependents) {
				return n->Dependents()->size() > 0;
			}
			else {
				return n->Dependees()->size() > 0;
			}
		}

		return false;
	}

	bool Dependency_Graph::Add_Relation(const std::string &key, const std::string &val, Relation r) {
		if (key.empty() || val.empty()) { return false; }

		bool added = false;
		auto set = Get_Relation_Set(key, r);
		if (set != nullptr) {
			set->insert(val);
			added = true;
		}
		else {
			Node *n = new Node();
			if (r == Relation::Dependents) {
				n->Dependents()->insert(val);
			}
			else {
				n->Dependees()->insert(val);
			}

			graph_[key] = n;
			added = true;
		}

		return added;
	}

	bool Dependency_Graph::Remove_Relation(const std::string &key, const std::string &val, Relation r) {
		if (key.empty() || val.empty()) { return false; }

		bool removed = false;
		auto set = Get_Relation_Set(key, r);
		if (set != nullptr) {
			set->erase(val);
			removed = true;
		}

		return removed;
	}

	void Dependency_Graph::Replace_Relation(const std::string &key, const std::unordered_set<std::string> &set, Relation r) {
		if (key.empty()) { return; }

		auto dep = Get_Relation_Set(key, r);
		if (dep != nullptr) {
			*dep = set;
		}
		else {
			Node *n = new Node();
			if (r == Relation::Dependents) {
				dep = n->Dependents();
				*dep = set;
			}
			else {
				dep = n->Dependees();
				*dep = set;
			}

			graph_[key] = n;
		}
	}

	void Dependency_Graph::Visit(const std::string &start, const std::string &cell,
			std::unordered_set<std::string> &visited, std::vector<std::string> *changed) {

		// visited.Add(name);
		visited.insert(cell);
		
		// foreach (String n in GetDirectDependents(name)) {
		// 	if (n.Equals(start)) {
		// 		throw new CircularException();
		// 	}
		// 	else if (!visited.Contains(n)) {
		// 		Visit(start, n, visited, changed);
		// 	}
		// }
		// changed.AddFirst(name);
	}
}