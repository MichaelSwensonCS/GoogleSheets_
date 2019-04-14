/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Server.cpp                                                   *
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

#include "Server.hpp"

namespace RS {
	Server::Server(const std::string &host, const uint16_t &port) : host_(host), port_(port),
			threads_(), sockets_() {}

	void Server::Start() {
		RS::Log::Message("Starting server on " + host_ + ":" + std::to_string(port_));

		kn::tcp_socket listen_socket({ host_, port_ });
		listen_socket.bind();
		listen_socket.listen();

		//close program upon ctrl+c or other signals
		std::signal(SIGINT, [](int) {
			RS::Log::Warning("Shutting down.");
			std::exit(0);
		});

		//Send the SIGINT signal to ourself if user press return on "server" terminal
		std::thread run_th([] {
			RS::Log::Message("Press 'enter' to shutdown the server.");
			std::cin.get();
			std::cin.clear();
			std::raise(SIGINT);
		});

		run_th.detach();

		RS::Log::Success("Server started.");

		Update(listen_socket);
	}

	void Server::Update(kn::tcp_socket &listen_socket) {
		RS::Log::Message("Waiting for client connections...");

		while(true) {
			sockets_.emplace_back(listen_socket.accept());
			auto &sock = sockets_.back();

			auto sprds = std::vector<std::string>{ "test.sprd", "test2.sprd" };
			auto list = RS::Message::List{ sprds };
			auto first_msg = std::string{ list.Json().dump() };

			sock.send(reinterpret_cast<const std::byte*>(first_msg.c_str()), first_msg.size());

			// example below echos whatever message comes into the server...

			// threads_.emplace_back([&]{
			// 	bool receive = true;
			// 	kn::buffer<1024> buff;

			// 	while(receive) {
			// 		if (auto [size, valid] = sock.recv(buff); valid) {
			// 			if (valid.value == kn::socket_status::cleanly_disconnected) {
			// 				receive = false;
			// 			}
			// 			else {
			// 				sock.send(buff.data(), size);
			// 			}
			// 		}
			// 		else {
			// 			receive = false;
			// 		}
			// 	}

			// 	RS::Log::Message("Disconnect");
			// 	if (const auto it = std::find(sockets_.begin(), sockets_.end(), std::ref(sock)); it != sockets_.end()) {
			// 		RS::Log::Message("Closing socket...");
			// 		sockets_.erase(it);
			// 	}
			// });

			// threads_.back().detach();
		}
	}
}