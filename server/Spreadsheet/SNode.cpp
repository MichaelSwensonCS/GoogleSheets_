/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Spreadsheet/SNode.hpp                                        *
 *                                                                                             *
 *                   Start Date : 04/18/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/20/19                                                     *
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

	const std::stack<std::string>& SNode::Undo() const {
		return undo_;
	}

	const std::map<std::string, std::stack<std::string>>& SNode::Revert() const {
		return revert_;
	}

	/*-----------------------------------------------------------------------------------------*
	 * Mutator Methods                                                                         *
	 *-----------------------------------------------------------------------------------------*/

	void SNode::History(const std::stack<std::string> &undo, const std::map<std::string, std::stack<std::string>> &revert) {
		undo_ = undo;
		revert_ = revert;
	}

	void SNode::Reset_History() {
		undo_ = std::stack<std::string>();
		revert_ = std::map<std::string, std::stack<std::string>>();
	}

	const std::string& SNode::Do_Undo() {
		return "";
	}

	const std::string& SNode::Do_Revert() {
		return "";
	}


}