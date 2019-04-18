/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Spreadsheet/SNode.hpp                                        *
 *                                                                                             *
 *                   Start Date : 04/18/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/18/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * SNode:                                                                                      *
 *   The snode class stands for "spreadsheet node" and acts as a wrapper for spreadsheets.     *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef SNODE_RS_H
#define SNODE_RS_H

#include <unordered_set>
#include "../Libraries/json.hpp"

using json = nlohmann::json;

namespace RS {

	class SNode {
	private:
		std::unordered_set<int> clients_;
		json sheet_;
	public:
		SNode();

		std::unordered_set<int>& Clients();
		json& Sheet();
	};
}

#endif