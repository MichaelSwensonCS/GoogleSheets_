/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Spreadsheet/Dependency_Graph.hpp                             *
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

#ifndef DEPGRAPH_RS_H
#define DEPGRAPH_RS_H

#include <functional>
#include <map>
#include <memory>
#include <unordered_set>
#include <vector>

namespace RS {
	
	class Dependency_Graph {
	private:
		enum class Relation { Dependents, Dependees };

		// See https://stackoverflow.com/questions/29855908/c-unordered-set-of-vectors
		struct VectorHash {
			size_t operator()(const std::vector<std::string>& v) const {
				std::hash<std::string> hasher;
				size_t seed = 0;
				for (auto& i : v) {
					seed ^= hasher(i) + 0x9e3779b9 + (seed<<6) + (seed>>2);
				}
				return seed;
			}
		};

		std::map< std::string, std::unordered_set< std::vector< std::string >, VectorHash > > graph_;
		int size_;

		int Relation_Index(Relation);
		bool Try_Get_Relation_Set(const std::string&, Relation, std::shared_ptr<std::unordered_set<std::string>>);
		bool Has_Relation(const std::string&, Relation) const;
		bool Add_Relation(const std::string&, const std::string&, Relation);
	public:
		Dependency_Graph();

		int Size();
		bool Has_Dependents(const std::string&) const;
		bool Has_Dependees(const std::string&) const;
		const std::vector<std::string>& Get_Dependents(const std::string&) const;
		const std::vector<std::string>& Get_Dependees(const std::string&) const;

		void Add_Dependency(const std::string&, const std::string&);
		void Remove_Dependency(const std::string&, const std::string&);
		void Replace_Dependents(const std::string&, const std::vector<std::string>&);
		void Replace_Dependees(const std::string&, const std::vector<std::string>&);
	};
}

#endif