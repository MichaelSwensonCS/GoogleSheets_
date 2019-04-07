/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : SocketState.hpp                                              *
 *                                                                                             *
 *                   Start Date : 04/07/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/07/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * SocketState:                                                                                *
 *   The socket state class is responsible for encapsulating the state of a socket connection. *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef SOCKETSTATE_RS_H
#define SOCKETSTATE_RS_H

#include "Utilities/Log.hpp"

class SocketState {
private:
	int _id;
	bool _error;

	std::string _error_msg;
public:
	SocketState();

	int ID() const;
	bool Error() const;
	const std::string & Error_Message() const;

	void ID(int id);
	void Error(bool error);
	void Error_Message(std::string msg);
};

#endif