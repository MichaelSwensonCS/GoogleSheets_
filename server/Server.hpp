/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Server.hpp                                                   *
 *                                                                                             *
 *                   Start Date : 04/06/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/11/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Server:                                                                                     *
 *   The server class is responsible for handling all fundamental server logic. Incoming       *
 *   connections, sending messages, etc.                                                       *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef SERVER_RS_H
#define SERVER_RS_H

#include <thread>
#include <vector>
#include "asio.hpp"
#include "Net/Net.hpp"
#include "Utilities/Log.hpp"

class Server {
private:
	std::string host_;
	uint16_t port_;

	std::shared_ptr< asio::io_service > io_service_;
	asio::ip::tcp::acceptor acceptor_;

	void Listen();
public:
	Server(std::shared_ptr<asio::io_service>, const std::string&, const uint16_t&);

	void Start();
	void Update();
};

#endif