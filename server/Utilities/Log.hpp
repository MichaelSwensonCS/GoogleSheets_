/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Utilities/Log.hpp                                            *
 *                                                                                             *
 *                   Start Date : 04/06/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/11/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Log:                                                                                        *
 *   The log class is responsible for outputing additional information for a user to consume.  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef LOG_RS_H
#define LOG_RS_H

#include <ctime>
#include <iostream>

class Log {
private:
	static char timestamp[0x20];

	static void Do_Timestamp();
	static void Do_Msg(const std::string &msg);
public:
	static void Message(const std::string &msg);
	static void Success(const std::string &msg);
	static void Warning(const std::string &msg);
	static void Error(const std::string &msg);
};

#endif