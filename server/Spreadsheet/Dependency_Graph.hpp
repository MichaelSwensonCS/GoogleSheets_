/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Spreadsheet/Dependency_Graph.hpp                             *
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

#ifndef DEPGRAPH_RS_H
#define DEPGRAPH_RS_H

#include <map>
#include <unordered_set>
#include <vector>
#include <memory>

namespace RS {
	
	class Dependency_Graph {
	private:
		enum class Relation { Dependents, Dependees };

		class Node {
			std::unordered_set<std::string> *dependents_;
			std::unordered_set<std::string> *dependees_;

		public:
			Node();
			~Node();
			std::unordered_set<std::string>* Dependents();
			std::unordered_set<std::string>* Dependees();
		};

		std::map<std::string, Node*> graph_;
		int size_;

		bool Has_Relation(const std::string&, Relation) const;
		bool Add_Relation(const std::string&, const std::string&, Relation);
		bool Remove_Relation(const std::string&, const std::string&, Relation);
		std::unordered_set<std::string>* Get_Relation_Set(const std::string&, Relation);
		void Replace_Relation(const std::string&, const std::unordered_set<std::string>&, Relation);

		static void Visit(const std::string&, const std::string&, std::unordered_set<std::string>&, std::vector<std::string>*);
	public:
		Dependency_Graph();
		~Dependency_Graph();

		int Size();
		bool Has_Dependents(const std::string&) const;
		bool Has_Dependees(const std::string&) const;
		const std::unordered_set<std::string>& Get_Dependents(const std::string&);
		const std::unordered_set<std::string>& Get_Dependees(const std::string&);

		void Add_Dependency(const std::string&, const std::string&);
		void Remove_Dependency(const std::string&, const std::string&);
		void Replace_Dependents(const std::string&, const std::unordered_set<std::string>&);
		void Replace_Dependees(const std::string&, const std::unordered_set<std::string>&);

		static const std::unordered_set<std::string>& GetDirectDependents(const std::string&);

		static bool Has_Circular_Dependency(const std::string&, const std::string&);
		static bool Has_Circular_Dependency(const std::unordered_set<std::string>&, const std::unordered_set<std::string>&);

	};
}

#endif