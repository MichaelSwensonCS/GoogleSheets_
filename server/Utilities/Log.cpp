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

void Log::Message(const std::string &msg) {
	std::cout << "[ MESSAGE ]:   " << msg << std::endl;
}

void Log::Success(const std::string &msg) {
	std::cout << '[' << "\033[32m" <<  " SUCCESS " << "\033[0m" << "]:   " << msg << std::endl;
}

void Log::Warning(const std::string &msg) {
	std::cout << '[' << "\033[33m" <<  " WARNING " << "\033[0m" << "]:   " << msg << std::endl;
}

void Log::Error(const std::string &msg) {
	std::cout << '[' << "\033[31m" <<  "  ERROR  " << "\033[0m" << "]:   " << msg << std::endl;
}