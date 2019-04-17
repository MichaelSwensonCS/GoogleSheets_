/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Utilities/AParser.hpp                                        *
 *                                                                                             *
 *                   Start Date : 04/11/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/17/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * AParser:                                                                                    *
 *   The aparser class is responsible for handling command line arguments.                     *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef APARSER_RS_H
#define APARSER_RS_H

#include <algorithm>
#include <string> 
#include <vector>
#include "Action.hpp"
#include "Log.hpp"

namespace RS {

	class AParser {
	private:
		std::vector<Action> actions_;
		std::string host_;
		int port_;

		static std::string Get_Arg(int, char **);
		void Register_Action(CL_Action_Type, const std::string&, const std::string&);
	public:
		AParser(int, char **);

		const std::vector<Action>& Actions() const;
		const std::string& Host() const;
		int Port();
	};
}

#endif