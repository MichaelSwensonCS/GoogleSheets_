/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Spreadsheet/Spreadsheet.hpp                                  *
 *                                                                                             *
 *                   Start Date : 04/14/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/16/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Spreadsheet:                                                                                *
 *   The spreadsheet class acts as a spreadsheet model with a list of key-value pairs for the  *
 *   cells contained in the sheet.                                                             *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "Spreadsheet.hpp"

namespace RS {

	/*-----------------------------------------------------------------------------------------*
	 * Constructor/Destructor Methods                                                          *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Default constructor.
	 *
	 * @return A new Spreadsheet instance.
	 */
	Spreadsheet::Spreadsheet() : name_(), cells_() {}

	/*
	 * Parameterized constructor.
	 *
	 * @param name The name of the spreadsheet.
	 * @return A new Spreadsheet instance with a value of the provided type.
	 */
	Spreadsheet::Spreadsheet(const std::string &name) : name_(name), cells_() {}

	/*-----------------------------------------------------------------------------------------*
	 * Accessor Methods                                                                        *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Gets the amount of cells in the spreadsheet.
	 *
	 * @return Total amount of cells.
	 */
	int Spreadsheet::Size() const {
		return cells_.size();
	}

	/*
	 * Gets the name of the spreadsheet.
	 *
	 * @return The name of the spreadsheet.
	 */
	const std::string& Spreadsheet::Name() const {
		return name_;
	}

	/*
	 * Gets all the cells in the spreadsheet.
	 *
	 * @return All of the cells.
	 */
	const json& Spreadsheet::Cells() const {
		return cells_;
	}

	/*
	 * Gets the contents of a specific cell.
	 *
	 * @param key The cell to lookup.
	 * @return The cell's contents.
	 */
	std::string Spreadsheet::Cell(const std::string &key) const {
		return cells_[key];
	}

	/*-----------------------------------------------------------------------------------------*
	 * Mutator Methods                                                                         *
	 *-----------------------------------------------------------------------------------------*/

	void Spreadsheet::Name(const std::string &name) {
		name_ = name;
	}

	void Spreadsheet::Cells(const json &cells) {
		cells_ = cells;
	}

	void Spreadsheet::Insert(const std::string &key, const std::string &value) {
		cells_[key] = value;
	}


	/*-----------------------------------------------------------------------------------------*
	 * Helper Methods                                                                          *
	 *-----------------------------------------------------------------------------------------*/
}