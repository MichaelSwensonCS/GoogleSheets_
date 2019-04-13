/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Msg/Error.cpp                                                *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/13/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Error:                                                                                      *
 *   The error class is the model for an "error" message.                                      *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "Error.hpp"

namespace RS { namespace Message {

	/*---------------------------------------------------------------------------------------------*
	 * Constructor/Destructor Methods                                                              *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Paramaterized constructor.
	 *
	 * @param type The message type.
	 * @param code The error code.
	 * @param source The error source.
	 * @return A new Error instance with a values of the provided parameters.
	 */
	Error::Error(const std::string &type, int code, const std::string &source) :
		Default(type), code_(code), src_(source) {}

	/*---------------------------------------------------------------------------------------------*
	 * Accessor Methods                                                                            *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Gets the JSON representation of this class.
	 *
	 * @return JSON object of this class.
	 */
	json Error::Json() const {
		json j = {
				{"type", type_},
				{"code", code_},
				{"source", src_}
		};

		return j;
	}

	/*
	 * Gets error code.
	 *
	 * @return Error code integer.
	 */
	int Error::Code() const {
		return code_;
	}

	/*
	 * Gets the error source.
	 *
	 * @return String of the error source.
	 */
	const std::string& Error::Source() const {
		return src_;
	}

	/*---------------------------------------------------------------------------------------------*
	 * Mutator Methods                                                                             *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Sets the fields of this class to those specified in the given JSON object.
	 *
	 * @param j The JSON object to use.
	 */
	void Error::Json(json j) {
		type_ = j["type_"];
		code_ = j["code"];
		src_ = j["source"];
	}

	/*
	 * Sets the error code.
	 *
	 * @param code The error code.
	 */
	void Error::Code(int code) {
		code_ = code;
	}

	/*
	 * Sets the error source.
	 *
	 * @param source The source of the error.
	 */
	void Error::Source(const std::string &source) {
		src_ = source;
	}
}}