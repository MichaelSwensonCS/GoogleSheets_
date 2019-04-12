/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Server.cpp                                                   *
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

#include "Server.hpp"

using asio::ip::tcp;

Server::Server(std::shared_ptr<asio::io_service> io_service, const std::string &host, const uint16_t &port) :
	io_service_(io_service),
	host_(host),
	port_(port),
	acceptor_(*io_service, tcp::endpoint(tcp::v4(), port)) {}

void Server::Start() {
	io_service_->run();

	Log::Success("Server started.");
	Log::Message("Listening at " + host_ + " on port " + std::to_string(port_));
}

void Server::Update() {

}

void Server::Listen() {
	tcp::resolver res(*io_service_);
	tcp::resolver::query query(host_, std::to_string(port_));
	tcp::endpoint ep = *res.resolve(query);

	acceptor_.open(ep.protocol());
	acceptor_.set_option(tcp::acceptor::reuse_address(false));
	acceptor_.bind(ep);
	acceptor_.listen(asio::socket_base::max_connections);
}