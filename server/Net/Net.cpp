/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Net.cpp                                                      *
 *                                                                                             *
 *                   Start Date : 04/07/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/08/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Net:                                                                                        *
 *   The net class is responsible all network related tasks.                                   *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "Net.hpp"

using asio::ip::tcp;

tcp::socket Net::Create_Socket(const std::string &hostname) {
	tcp::socket socket;
	return socket;
}