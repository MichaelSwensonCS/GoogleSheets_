/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Msg/Open.cpp                                                 *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/13/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Open:                                                                                       *
 *   The open class is the model for an "open" message.                                        *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "Open.hpp"

namespace RS { namespace Message {

	/*---------------------------------------------------------------------------------------------*
	 * Constructor/Destructor Methods                                                              *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Paramaterized constructor.
	 *
	 * @param name The spreadsheet name.
	 * @param user The user's name.
	 * @param pass The user's password.
	 * @return A new Open instance with a values of the provided parameters.
	 */
	Open::Open(const std::string &name, const std::string &user, const std::string &pass) :
		Default("open"), name_(name), user_(user), pass_(pass) {}

	/*---------------------------------------------------------------------------------------------*
	 * Accessor Methods                                                                            *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Gets the JSON representation of this class.
	 *
	 * @return JSON object of this class.
	 */
	json Open::Json() const {
		json j = {
				{"type", type_},
				{"name", name_},
				{"username", user_},
				{"password", pass_}
		};

		return j;
	}

	/*
	 * Gets the spreadsheet name.
	 *
	 * @return String of the spreadsheet name.
	 */
	const std::string& Open::Spreadsheet() const {
		return name_;
	}

	/*
	 * Gets the username.
	 *
	 * @return String of the username.
	 */
	const std::string& Open::Username() const {
		return user_;
	}

	/*
	 * Gets the user's password.
	 *
	 * @return String of the user's password.
	 */
	const std::string& Open::Password() const {
		return pass_;
	}

	/*---------------------------------------------------------------------------------------------*
	 * Mutator Methods                                                                             *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Sets the fields of this class to those specified in the given JSON object.
	 *
	 * @param j The JSON object to use.
	 */
	void Open::Json(json j) {
		name_ = j["name"];
		user_ = j["username"];
		pass_ = j["password"];
	}

	/*
	 * Sets the spreadsheet name.
	 *
	 * @param name The name of the spreadsheet to open/create.
	 */
	void Open::Spreadsheet(const std::string &name) {
		name_ = name;
	}

	/*
	 * Sets the username.
	 *
	 * @param name The username for authentication.
	 */
	void Open::Username(const std::string &user) {
		user_ = user;
	}

	/*
	 * Sets the user's password.
	 *
	 * @param name The password for authentication.
	 */
	void Open::Password(const std::string &pass) {
		pass_ = pass;
	}
}}