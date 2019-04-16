/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Server.hpp                                                   *
 *                                                                                             *
 *                   Start Date : 04/06/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/16/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Server:                                                                                     *
 *   The server class is responsible for handling all fundamental server logic. Incoming       *
 *   connections, sending messages, etc.                                                       *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef SERVER_RS_H
#define SERVER_RS_H

#include <filesystem>
#include <functional>
#include <thread>
#include <vector>
#include <algorithm>
#include <csignal>
#include "Libraries/json.hpp"
#include "Libraries/kissnet.hpp"
#include "Msg/List.hpp"
#include "Net/Connection.hpp"
#include "Spreadsheet/Spreadsheet.hpp"
#include "Utilities/File.hpp"
#include "Utilities/Log.hpp"

using json = nlohmann::json;
namespace kn = kissnet;

namespace RS {

	class Server {
	private:
		static const std::string AUTH_FILENAME;

		std::string host_;
		uint16_t port_;

		std::vector<std::thread> threads_;
		std::vector<kn::tcp_socket> sockets_;
		std::vector<Spreadsheet> sheets_;
		std::map<std::string, std::string> users_;

		void Load_Auth();
		void Save_Auth();

		void Update(kn::tcp_socket&);
		void Receive_Message(const json&, kn::tcp_socket&);

		bool Valid_Auth(const std::string&, const std::string&);
		void Client_Select_Sheet(const std::string&, const std::string&, const std::string&, kn::tcp_socket&);
		void Do_Error(int, const std::string&, kn::tcp_socket&);

		void Send_Message(const json&, kn::tcp_socket&);
	public:
		static const std::string DEFAULT_HOST;
		static const uint16_t DEFAULT_PORT;

		Server(const std::string&, const uint16_t&);

		void Start();
	};
}

#endif