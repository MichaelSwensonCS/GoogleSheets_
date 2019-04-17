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
	
	/*-----------------------------------------------------------------------------------------*
	 * Constructor/Destructor Methods                                                          *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Paramaterized constructor.
	 *
	 * @param argc The argument count.
	 * @param argv The array of arguments.
	 * @return A new AParser instance that has evaluated the given arguments.
	 */
	AParser::AParser(int argc, char **argv) : actions_() {
		host_ = "";
		port_ = -1;

		if (argc > 1) {
			for (int i = 1; i < argc; i++) {
				std::string arg(Get_Arg(i, argv));

				if(arg == "-acct" && i + 1 < argc) {
					if (i + 2 < argc) {
						std::string action(Get_Arg(++i, argv));
						std::string input(Get_Arg(++i, argv));
						Register_Action(CL_Action_Type::Account, action, input);
					}
					else {
						Log::Warning("Not enough arguments provided for the account action.");
					}
				}
				else if(arg == "-sprd" && i + 1 < argc) {
					if (i + 2 < argc) {
						std::string action(Get_Arg(++i, argv));
						std::string input(Get_Arg(++i, argv));
						Register_Action(CL_Action_Type::Spreadsheet, action, input);
					}
					else {
						Log::Warning("Not enough arguments provided for the spreadsheet action.");
					}
				}
				else if (arg == "-host" && i + 1 < argc) {
					std::string host(Get_Arg(++i, argv));
					host_ = host;
				}
				else if (arg == "-port" && i + 1 < argc) {
					std::string port(Get_Arg(++i, argv));
					port_ = std::stoi(port);
				}
			}
		}
	}

	/*-----------------------------------------------------------------------------------------*
	 * Accessor Methods                                                                        *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Gets a list of actions that were provided.
	 *
	 * @return List of actions.
	 */
	const std::vector<Action>& AParser::Actions() const {
		return actions_;
	}

	/*
	 * Gets the host address loaded from the command line.
	 *
	 * @return Host address.
	 */
	const std::string& AParser::Host() const {
		return host_;
	}

	/*
	 * Gets the port loaded from the command line.
	 *
	 * @return JSON object of this class.
	 */
	int AParser::Port() {
		return port_;
	}

	/*-----------------------------------------------------------------------------------------*
	 * Helper Methods                                                                          *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Gets an argument from the specified index as a std::string with all characters made lowercase.
	 *
	 * @param idx The index to pull from.
	 * @param argv The argument array.
	 * @return The single argument as a lowercase string.
	 */
	std::string AParser::Get_Arg(int idx, char **argv) {
		std::string arg(argv[idx]);
		std::transform(arg.begin(), arg.end(), arg.begin(), ::tolower);
		return arg;
	}

	/*
	 * Registers an action depending on the given action type and action string.
	 *
	 * @param type The desired action type.
	 * @param action The desired action to perform.
	 */
	void AParser::Register_Action(CL_Action_Type type, const std::string &action, const std::string &input) {
		switch(type) {
			case CL_Action_Type::Account:
				if (action == "new") {
					Action act(CL_Action_Type::Account, CL_Action::Create, input, "");
					actions_.push_back(act);
				}
				else if (action == "del") {
					Action act(CL_Action_Type::Account, CL_Action::Delete, input, "");
					actions_.push_back(act);
				}
				else if (action == "pass") {
					Log::Warning("Password changing is not available.");
				}
				else { Log::Warning(action + " is not a valid account action"); }
				break;
			case CL_Action_Type::Spreadsheet:
				if (action == "new") {
					Action act(CL_Action_Type::Spreadsheet, CL_Action::Create, input, "");
					actions_.push_back(act);
				}
				else if (action == "del") {
					Action act(CL_Action_Type::Spreadsheet, CL_Action::Delete, input, "");
					actions_.push_back(act);
				}
				else { Log::Warning(action + " is not a valid spreadsheet action"); }
				break;
			default:
				break;
		}
	}
}