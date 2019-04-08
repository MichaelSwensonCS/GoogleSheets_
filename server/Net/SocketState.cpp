/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : SocketState.cpp                                              *
 *                                                                                             *
 *                   Start Date : 04/07/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/08/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * SocketState:                                                                                *
 *   The socket state class is responsible for encapsulating the state of a socket connection. *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "SocketState.hpp"

using asio::ip::tcp;

/*---------------------------------------------------------------------------------------------*
 * Constructor Methods                                                                         *
 *---------------------------------------------------------------------------------------------*/

/*
 * Default constructor. 
 *
 * @return A new SocketState instance.
 */
SocketState::SocketState() {}

/*---------------------------------------------------------------------------------------------*
 * Accessor Methods                                                                            *
 *---------------------------------------------------------------------------------------------*/

/*
 * Gets the id associated with the socket state. 
 *
 * @return Id of the socket state.
 */
int SocketState::ID() const {
	return _id;
}

/*
 * Gets the error
 *
 * @return Id of the socket state.
 */
bool SocketState::Error() const {
	return _error;
}

const std::string & SocketState::Error_Message() const {
	return _error_msg;
}

/*---------------------------------------------------------------------------------------------*
 * Mutator Methods                                                                             *
 *---------------------------------------------------------------------------------------------*/

void SocketState::ID(int id) {
	_id = id;
}

void SocketState::Error(bool error) {
	_error = error;
}

void SocketState::Error_Message(std::string msg) {
	_error_msg = msg;
}