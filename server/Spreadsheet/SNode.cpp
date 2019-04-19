/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Spreadsheet/SNode.hpp                                        *
 *                                                                                             *
 *                   Start Date : 04/18/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/19/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * SNode:                                                                                      *
 *   The snode class stands for "spreadsheet node" and acts as a wrapper for spreadsheets.     *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "SNode.hpp"

namespace RS {

	/*-----------------------------------------------------------------------------------------*
	 * Constructor/Destructor Methods                                                          *
	 *-----------------------------------------------------------------------------------------*/

	SNode::SNode() : clients_(), sheet_(), undo_(), revert_() {}

	/*-----------------------------------------------------------------------------------------*
	 * Accessor Methods                                                                        *
	 *-----------------------------------------------------------------------------------------*/

	std::unordered_set<int>& SNode::Clients() {
		return clients_;
	}

	json& SNode::Sheet() {
		return sheet_;
	}

	const std::string& Undo() {
		return "";
	}

	const std::string& Revert() {
		return "";
	}


}