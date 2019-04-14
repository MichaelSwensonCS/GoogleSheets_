/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Server.hpp                                                   *
 *                                                                                             *
 *                   Start Date : 04/06/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/14/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Server:                                                                                     *
 *   The server class is responsible for handling all fundamental server logic. Incoming       *
 *   connections, sending messages, etc.                                                       *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef SERVER_RS_H
#define SERVER_RS_H

#include <functional>
#include <thread>
#include <vector>
#include <algorithm>
#include <csignal>
#include "kissnet.hpp"
#include "Msg/List.hpp"
#include "Net/Connection.hpp"
#include "nlohmann/json.hpp"
#include "Utilities/File.hpp"
#include "Utilities/Log.hpp"

using json = nlohmann::json;
namespace kn = kissnet;

namespace RS {

	class Server {
	private:
		std::string host_;
		uint16_t port_;

		std::vector<std::thread> threads_;
		std::vector<kn::tcp_socket> sockets_;
	public:
		static const uint16_t DEFAULT_PORT = 2112;

		Server(const std::string&, const uint16_t&);

		void Start();
		void Update(kn::tcp_socket&);
	};
}

#endif