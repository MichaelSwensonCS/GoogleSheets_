/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Msg/Default.cpp                                              *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/13/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Default:                                                                                    *
 *   The default class is the base model for any network message.                              *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "Default.hpp"

using json = nlohmann::json;

namespace RS { namespace Message {

	/*---------------------------------------------------------------------------------------------*
	 * Constructor/Destructor Methods                                                              *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Paramaterized constructor.
	 *
	 * @param type The message type.
	 * @return A new Default instance with a value of the provided type.
	 */
	Default::Default(const std::string &type) : type_(type) {}

	/*---------------------------------------------------------------------------------------------*
	 * Accessor Methods                                                                            *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Gets the JSON representation of this class.
	 *
	 * @return JSON object of this class.
	 */
	json Default::Json() const {
		json j = {
				{"type", type_}
		};

		return j;
	}

	/*
	 * Gets the message type.
	 *
	 * @return String of the message type.
	 */
	std::string Default::Type() const {
		return type_;
	}

	/*---------------------------------------------------------------------------------------------*
	 * Mutator Methods                                                                             *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Sets the fields of this class to those specified in the given JSON object.
	 *
	 * @param j The JSON object to use.
	 */
	void Default::Json(json j) {
		type_ = j["type"];
	}

	/*
	 * Sets the message type.
	 *
	 * @param type The type to set the message to.
	 */
	void Default::Type(const std::string &type) {
		type_ = type;
	}
}}