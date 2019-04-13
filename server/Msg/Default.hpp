/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Msg/Default.hpp                                              *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/13/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Default:                                                                                    *
 *   The default class is the base model for any network message.                              *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef MESSAGE_RS_H
#define MESSAGE_RS_H

#include <string>
#include "../nlohmann/json.hpp"

using json = nlohmann::json;

namespace RS { namespace Message {
	
	class Default {
	private:
		std::string type_;
	public:
		Default(const std::string&);

		virtual json Json() const;
		std::string Type() const;

		virtual void Json(json);
		void Type(const std::string&);
	};
}}

#endif