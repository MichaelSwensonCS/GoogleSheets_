/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Msg/Edit.cpp                                                 *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/15/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Edit:                                                                                       *
 *   The edit class is the model for an "edit" message.                                        *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "Edit.hpp"

namespace RS { namespace Message {

	/*-----------------------------------------------------------------------------------------*
	 * Constructor/Destructor Methods                                                          *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Paramaterized constructor.
	 *
	 * @param cell The cell to edit.
	 * @return A new Edit instance with a values of the provided parameters.
	 */
	Edit::Edit(const std::string &cell) :
		Default("edit"), cell_(cell), contents_(""), dependencies_(std::vector<std::string>()) {}

	/*
	 * Paramaterized constructor.
	 *
	 * @param cell The cell to edit.
	 * @param contents The contents to set the cell to.
	 * @return A new Edit instance with a values of the provided parameters.
	 */
	Edit::Edit(const std::string &cell, const std::string &contents) :
		Default("edit"), cell_(cell), contents_(contents), dependencies_(std::vector<std::string>()) {}

	/*
	 * Paramaterized constructor.
	 *
	 * @param cell The cell to edit.
	 * @param contents The contents to set the cell to.
	 * @param dep The cell's dependencies.
	 * @return A new Edit instance with a values of the provided parameters.
	 */
	Edit::Edit(const std::string &cell, const std::string &contents, const std::vector<std::string> &dep) :
		Default("edit"), cell_(cell), contents_(contents), dependencies_(dep) {}

	/*-----------------------------------------------------------------------------------------*
	 * Accessor Methods                                                                        *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Gets the JSON representation of this class.
	 *
	 * @return JSON object of this class.
	 */
	json Edit::Json() const {
		json j = {
				{"type", type_},
				{"cell", cell_},
				{"value", contents_},
				{"dependencies", dependencies_}
		};

		return j;
	}

	/*
	 * Gets the cell to edit.
	 *
	 * @return String of the cell to edit.
	 */
	const std::string& Edit::Cell() const {
		return cell_;
	}

	/*
	 * Gets the contents to set the cell to.
	 *
	 * @return String of the cell contents.
	 */
	const std::string& Edit::Contents() const {
		return contents_;
	}

	/*
	 * Gets the list of dependencies for the cell.
	 *
	 * @return List of dependencies.
	 */
	const std::vector<std::string>& Edit::Dependencies() const {
		return dependencies_;
	}

	/*-----------------------------------------------------------------------------------------*
	 * Mutator Methods                                                                         *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Sets the fields of this class to those specified in the given JSON object.
	 *
	 * @param j The JSON object to use.
	 */
	void Edit::Json(json j) {
		cell_ = j["cell"];
		contents_ = j["value"];

		if (j["dependencies"].is_array()) {
			dependencies_.clear();

			for (auto& s : j["dependencies"].items()) {
				dependencies_.push_back(s.value());
			}
		}
	}

	/*
	 * Sets the cell to edit.
	 *
	 * @param cell The cell to edit.
	 */
	void Edit::Cell(const std::string &cell) {
		cell_ = cell;
	}

	/*
	 * Sets the cell's contents.
	 *
	 * @param contents The new contents.
	 */
	void Edit::Contents(const std::string &contents) {
		contents_ = contents;
	}

	/*
	 * Sets the cell's dependencies
	 *
	 * @param dep The dependencies for the cell.
	 */
	void Edit::Dependencies(const std::vector<std::string> &dep) {
		dependencies_ = dep;
	}
}}