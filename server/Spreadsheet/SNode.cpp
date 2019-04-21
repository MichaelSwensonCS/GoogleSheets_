/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Spreadsheet/SNode.hpp                                        *
 *                                                                                             *
 *                   Start Date : 04/18/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/21/19                                                     *
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

	const std::map<std::string, std::stack<std::tuple<std::string, std::vector<std::string>>>>& SNode::Revert() const {
		return revert_;
	}

	/*-----------------------------------------------------------------------------------------*
	 * Mutator Methods                                                                         *
	 *-----------------------------------------------------------------------------------------*/

	void SNode::History(const std::stack<std::string> &undo, const std::map<std::string, std::stack<std::tuple<std::string, std::vector<std::string>>>> &revert) {
		undo_ = undo;
		revert_ = revert;
	}

	void SNode::Reset_History() {
		undo_ = std::stack<std::string>();
		revert_ = std::map<std::string, std::stack<std::tuple<std::string, std::vector<std::string>>>>();
	}

	void SNode::Push_Edit(const std::string &cell, const std::string &contents, const std::vector<std::string> &deps) {
		undo_.push(cell);
		revert_[cell].push(std::make_tuple(contents, deps));
	}

	const std::string& SNode::Do_Undo() {
		auto contents = std::make_shared<std::string>("");

		if (undo_.size() > 0) {
			std::string cell = undo_.top();
			undo_.pop();
			return Do_Revert(cell);
		}
		else {
			return *contents;
		}
	}

	const std::string& SNode::Do_Revert(const std::string &cell) {
		auto contents = std::make_shared<std::string>("");

		// Check that the cell has history.
		auto it = revert_.find(cell);
		if (it != revert_.end()) {

			auto &history = it->second;
			if (history.size() > 0) {
				auto current = history.top();
				history.pop();

				if (history.size() != 0) {
					auto previous = history.top();

					*contents = std::get<0>(previous);
					auto dependees = std::get<1>(previous);

					// Probably check dependents
				}
			}
		}

		// Revert cell's contents.
		sheet_["spreadsheet"][cell] = *contents;

		return *contents;
	}
}