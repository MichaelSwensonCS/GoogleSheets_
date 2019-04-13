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
	Default::Default(const std::string &type) : type_(type) {}

	json Default::Json() const {
		json j = {
				{"type", type_},
		};

		return j;
	}

	std::string Default::Type() const {
		return type_;
	}

	void Default::Json(json j) {
		type_ = j["type"];
	}

	void Default::Type(const std::string &type) {
		type_ = type;
	}
}}