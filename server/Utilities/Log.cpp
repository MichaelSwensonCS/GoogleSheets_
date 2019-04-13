/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Utilities/Log.cpp                                            *
 *                                                                                             *
 *                   Start Date : 04/06/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/11/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Log:                                                                                        *
 *   The log class is responsible for outputing additional information for a user to consume.  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "Log.hpp"

namespace RS {

	/*---------------------------------------------------------------------------------------------*
	 * Class Members                                                                               *
	 *---------------------------------------------------------------------------------------------*/

	char Log::timestamp[0x20] = "\0";

	/*---------------------------------------------------------------------------------------------*
	 * Public Methods                                                                              *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Outputs a basic message to the user.
	 *
	 * @param msg The message to relay.
	 */
	void Log::Message(const std::string &msg) {
		Do_Msg("[ MESSAGE ]:   " + msg);
	}

	/*
	 * Outputs a success message to the user.
	 *
	 * @param msg The message to relay.
	 */
	void Log::Success(const std::string &msg) {
		Do_Msg("[\033[32m SUCCESS \033[0m]:   " + msg);
	}

	/*
	 * Outputs a warning message to the user.
	 *
	 * @param msg The message to relay.
	 */
	void Log::Warning(const std::string &msg) {
		Do_Msg("[\033[33m WARNING \033[0m]:   " + msg);
	}

	/*
	 * Outputs an error message to the user.
	 *
	 * @param msg The message to relay.
	 */
	void Log::Error(const std::string &msg) {
		Do_Msg("[\033[31m  ERROR  \033[0m]:   " + msg);
	}

	/*---------------------------------------------------------------------------------------------*
	 * Helper Methods                                                                              *
	 *---------------------------------------------------------------------------------------------*/

	/*
	 * Creates a timestamp for the current time and stores it in the timestamp variable.
	 *
	 */
	void Log::Do_Timestamp() {
		time_t t = time(NULL);
		strftime(Log::timestamp, 0x20, "%m/%d/%Y %I:%M:%S %p", localtime(&t));
	}

	/*
	 * Generic message method that prepends any messages with a timestamp.
	 *
	 * @param msg The message to relay.
	 */
	void Log::Do_Msg(const std::string &msg) {
		Do_Timestamp();
		std::cout << '[' << timestamp << ']' << msg << std::endl;
	}
}