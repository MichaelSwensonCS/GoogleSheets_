/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Msg/List.hpp                                                 *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/13/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * List:                                                                                       *
 *   The list class is the model for an "spreadsheet list" message.                            *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef SPRDLIST_RS_H
#define SPRDLIST_RS_H

#include <vector>
#include "Default.hpp"

using json = nlohmann::json;

namespace RS { namespace Message {

	class List : Default {
	private:
		std::vector<std::string> list_;
	public:
		List();
		List(const std::vector<std::string>&);

		json Json() const;
		const std::vector<std::string>& Spreadsheet_List() const;

		void Json(json);
		void Spreadsheet_List(const std::vector<std::string>&);
	};
}}

#endif