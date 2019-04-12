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

char Log::timestamp[0x20] = "\0";

void Log::Message(const std::string &msg) {
	Do_Msg("[ MESSAGE ]:   " + msg);
}

void Log::Success(const std::string &msg) {
	Do_Msg("[\033[32m SUCCESS \033[0m]:   " + msg);
}

void Log::Warning(const std::string &msg) {
	Do_Msg("[\033[33m WARNING \033[0m]:   " + msg);
}

void Log::Error(const std::string &msg) {
	Do_Msg("[\033[31m  ERROR  \033[0m]:   " + msg);
}

void Log::Do_Timestamp() {
	time_t t = time(NULL);
	strftime(Log::timestamp, 0x20, "%m/%d/%Y %I:%M:%S %p", localtime(&t));
}

void Log::Do_Msg(const std::string &msg) {
	Do_Timestamp();
	std::cout << '[' << timestamp << ']' << msg << std::endl;
}