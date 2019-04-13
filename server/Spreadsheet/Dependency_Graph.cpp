/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Spreadsheet/Dependency_Graph.cpp                             *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/13/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Dependency_Graph:                                                                           *
 *   The dependency_graph class is a directed graph that represents dependencies of objects    *
 *   towards each other.                                                                       *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "Dependency_Graph.hpp"

namespace RS {

	/*---------------------------------------------------------------------------------------------*
	 * Constructor/Destructor Methods                                                              *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Paramaterized constructor.
	 *
	 * @return A new Dependency_Graph instance with a value of the provided type.
	 */
	Dependency_Graph::Dependency_Graph() : size_(0) {}

	/*---------------------------------------------------------------------------------------------*
	 * Accessor Methods                                                                            *
	 *---------------------------------------------------------------------------------------------*/

	int Dependency_Graph::Size() {
		return size_;
	}

	bool Dependency_Graph::Has_Dependents(const std::string &s) const {
		return Has_Relation(s, Relation::Dependents);
	}

	bool Dependency_Graph::Has_Dependees(const std::string &s) const {
		return Has_Relation(s, Relation::Dependees);
	}

	const std::vector<std::string>& Dependency_Graph::Get_Dependents(const std::string &s) const {
		std::vector<std::string> blah;
		return blah;
	}

	const std::vector<std::string>& Dependency_Graph::Get_Dependees(const std::string &s) const {
		std::vector<std::string> blah;
		return blah;
	}

	/*---------------------------------------------------------------------------------------------*
	 * Mutator Methods                                                                             *
	 *---------------------------------------------------------------------------------------------*/

	void Dependency_Graph::Add_Dependency(const std::string &s, const std::string &t) {
		if (Add_Relation(s, t, Relation::Dependents) && Add_Relation(t, s, Relation::Dependees)) {
			size_++;
		}
	}

	void Dependency_Graph::Remove_Dependency(const std::string &s, const std::string &t) {

	}

	void Dependency_Graph::Replace_Dependents(const std::string &s, const std::vector<std::string> &new_dep) {

	}

	void Dependency_Graph::Replace_Dependees(const std::string &s, const std::vector<std::string> &new_dep) {

	}

	/*---------------------------------------------------------------------------------------------*
	 * Helper Methods                                                                              *
	 *---------------------------------------------------------------------------------------------*/

	int Dependency_Graph::Relation_Index(Relation r) {
		int val = -1;
		switch(r) {
			case Relation::Dependents:
				val = 0;
				break;
			case Relation::Dependees:
				val = 1;
				break;
			default:
				break;
		}

		return val;
	}

	bool Dependency_Graph::Try_Get_Relation_Set(const std::string &key,
			Relation r, std::shared_ptr<std::unordered_set<std::string>> set) {

		auto it = graph_.find(key);
		if (it != graph_.end()) {
			auto test = it->second;
			return true;
		}

		return false;
	}

	bool Dependency_Graph::Has_Relation(const std::string &s, Relation r) const {
		return false;
	}

	bool Dependency_Graph::Add_Relation(const std::string &key, const std::string &val, Relation r) {
		if (key.empty() || val.empty()) { return false; }

		std::shared_ptr<std::unordered_set<std::string>> set;

		bool added = false;
		if (Try_Get_Relation_Set(key, r, set)) {
			added = true;
		}
		else {
			std::unordered_set<std::vector<std::string>, VectorHash> new_set;
			graph_[key] = new_set;
			added = true;
		}

		return added;
	}

}