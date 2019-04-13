/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Utilities/AParser.hpp                                        *
 *                                                                                             *
 *                   Start Date : 04/11/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/13/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * AParser:                                                                                    *
 *   The aparser class is responsible for handling command line arguments.                     *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "AParser.hpp"

// Info from slides about Administrative interface:
//
// –Account management (create/delete/change pw)
// –Spreadsheet removal and blank sheet creation
// –View current status:
//  	-Connections (real time updates)
//  	-Activity (real time updates)
// –Cleanshutdown

namespace RS {
	
	AParser::AParser(int argc, char **argv) {
		if (argc > 1) {
			Log::Message("Total arguments provided: " + std::to_string(argc - 1));

			for (int i = 1; i < argc; i++) {
				std::string arg(Get_Arg(i, argv));

				if(arg == "-acct" && i + 1 < argc) {
					std::string action(Get_Arg(++i, argv));
					Do_Action(CL_Action_Type::Account, action);
				}
				else if(arg == "-sprd" && i + 1 < argc) {
					std::string action(Get_Arg(++i, argv));
					Do_Action(CL_Action_Type::Spreadsheet, action);
				}
			}
		}
	}

	std::string AParser::Get_Arg(int idx, char **argv) {
		std::string arg(argv[idx]);
		std::transform(arg.begin(), arg.end(), arg.begin(), ::tolower);
		return arg;
	}

	void AParser::Do_Action(CL_Action_Type type, const std::string &action) {
		switch(type) {
			case CL_Action_Type::Account:
				if (action == "new") { Log::Message("Account create new"); }
				else if (action == "del") { Log::Message("Account delete"); }
				else if (action == "pass") { Log::Message("Account password change"); }
				else { Log::Warning(action + " is not a valid account action"); }
				break;
			case CL_Action_Type::Spreadsheet:
				if (action == "new") { Log::Message("Spreadsheet create new"); }
				else if (action == "del") { Log::Message("Spreadsheet delete"); }
				else { Log::Warning(action + " is not a valid spreadsheet action"); }
				break;
			default:
				break;
		}
	}
}