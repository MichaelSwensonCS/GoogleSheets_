/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Msg/List.cpp                                                 *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/13/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * List:                                                                                       *
 *   The list class is the model for an "spreadsheet list" message.                            *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "List.hpp"

namespace RS { namespace Message {

	/*---------------------------------------------------------------------------------------------*
	 * Constructor/Destructor Methods                                                              *
	 *---------------------------------------------------------------------------------------------*/

	List::List() : Default("list"), list_(std::vector<std::string>()) {}

	/*
	 * Paramaterized constructor.
	 *
	 * @param sprd_list List of spreadsheet names.
	 * @return A new List instance with a values of the provided parameters.
	 */
	List::List(const std::vector<std::string> &sprd_list) : Default("list"), list_(sprd_list) {}

	/*---------------------------------------------------------------------------------------------*
	 * Accessor Methods                                                                            *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Gets the JSON representation of this class.
	 *
	 * @return JSON object of this class.
	 */
	json List::Json() const {
		json j = {
				{"type", type_},
				{"spreadsheets", list_}
		};

		return j;
	}

	/*
	 * Gets the list of spreadsheet names.
	 *
	 * @return List of spreadsheet names.
	 */
	const std::vector<std::string>& List::Spreadsheet_List() const {
		return list_;
	}

	/*---------------------------------------------------------------------------------------------*
	 * Mutator Methods                                                                             *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Sets the fields of this class to those specified in the given JSON object.
	 *
	 * @param j The JSON object to use.
	 */
	void List::Json(json j) {
		if (j.is_array()) {
			list_.clear();

			for (auto& s : j.items()) {
				list_.push_back(s.value());
			}
		}
	}

	/*
	 * Sets the spreadsheet name.
	 *
	 * @param name The name of the spreadsheet to open/create.
	 */
	void List::Spreadsheet_List(const std::vector<std::string> &sprd_list) {
		list_ = sprd_list;
	}
}}