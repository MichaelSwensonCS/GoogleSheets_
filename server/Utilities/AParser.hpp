/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Utilities/AParser.hpp                                        *
 *                                                                                             *
 *                   Start Date : 04/11/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/14/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * AParser:                                                                                    *
 *   The aparser class is responsible for handling command line arguments.                     *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef APARSER_RS_H
#define APARSER_RS_H

#include <algorithm>
#include <string> 
#include "Log.hpp"

namespace RS {
	class AParser {
		std::string host_;
		int port_;

	private:
		enum class CL_Action_Type { Account, Spreadsheet };

		static std::string Get_Arg(int, char **);
		static void Do_Action(CL_Action_Type, const std::string&);
	public:
		AParser(int, char **);

		const std::string& Host();
		int Port();
	};
}

#endif