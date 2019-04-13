/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Msg/Open.hpp                                                 *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/13/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Open:                                                                                       *
 *   The open class is the model for an "open" message.                                        *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef OPEN_RS_H
#define OPEN_RS_H

#include "Default.hpp"

using json = nlohmann::json;

namespace RS { namespace Message {

	class Open : Default {
	private:
		std::string name_, user_, pass_;
	public:
		Open(const std::string&, const std::string&, const std::string&, const std::string&);

		json Json() const;
		std::string Spreadsheet() const;
		std::string Username() const;
		std::string Password() const;

		void Json(json);
		void Spreadsheet(const std::string&);
		void Username(const std::string&);
		void Password(const std::string&);
	};
}}

#endif