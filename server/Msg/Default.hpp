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
#include "../Libraries/json.hpp"
#include "../Utilities/Log.hpp"

using json = nlohmann::json;

namespace RS { namespace Message {
	
	class Default {
	protected:
		std::string type_;
	public:
		Default(const std::string&);

		virtual json Json() const;
		const std::string& Type() const;
	};
}}

#endif