/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Msg/Revert.cpp                                               *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/13/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Revert:                                                                                     *
 *   The revert class is the model for an "revert" message.                                    *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "Revert.hpp"

namespace RS { namespace Message {

	/*---------------------------------------------------------------------------------------------*
	 * Constructor/Destructor Methods                                                              *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Paramaterized constructor.
	 *
	 * @param type The message type.
	 * @param cell The cell to revert.
	 * @return A new Revert instance with a values of the provided parameters.
	 */
	Revert::Revert(const std::string &type, const std::string &cell) :
		Default(type), cell_(cell) {}

	/*---------------------------------------------------------------------------------------------*
	 * Accessor Methods                                                                            *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Gets the JSON representation of this class.
	 *
	 * @return JSON object of this class.
	 */
	json Revert::Json() const {
		json j = {
				{"type", type_},
				{"cell", cell_}
		};

		return j;
	}

	/*
	 * Gets the cell to revert.
	 *
	 * @return String of the cell.
	 */
	const std::string& Revert::Cell() const {
		return cell_;
	}

	/*---------------------------------------------------------------------------------------------*
	 * Mutator Methods                                                                             *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Sets the fields of this class to those specified in the given JSON object.
	 *
	 * @param j The JSON object to use.
	 */
	void Revert::Json(json j) {
		type_ = j["type_"];
		cell_ = j["cell"];
	}

	/*
	 * Sets the cell to revert.
	 *
	 * @param cell The cell to revert.
	 */
	void Revert::Cell(const std::string &cell) {
		cell_ = cell;
	}
}}