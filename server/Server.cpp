/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Server.cpp                                                   *
 *                                                                                             *
 *                   Start Date : 04/06/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/15/19                                                     *
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
		RS::Log::Message("Waiting for client connections.");

		while(true) {
			sockets_.emplace_back(listen_socket.accept());
			auto &sock = sockets_.back();

			auto sprds = RS::File::List_Spreadsheets(std::filesystem::current_path());
			auto list = RS::Message::List{ sprds };
			auto first_msg = std::string{ list.Json().dump() + "\n\n" };

			sock.send(reinterpret_cast<const std::byte*>(first_msg.c_str()), first_msg.size());

			threads_.emplace_back([&]{
				bool receive = true;
				kn::buffer<1024> buff;

				while(receive) {
					auto [size, valid] = sock.recv(buff);

					if (valid) {
						if (valid.value == kn::socket_status::cleanly_disconnected) {
							receive = false;
						}
						else {
							// sock.send(buff.data(), size);
							auto output = std::string(reinterpret_cast<char*>(buff.data()), size);
							auto j_open = json::parse(output);
							Client_Select_Sheet(j_open["name"], j_open["username"], j_open["password"], sock);
						}
					}
					else {
						receive = false;
					}
				}

				RS::Log::Message("Client disconnect.");
				const auto it = std::find(sockets_.begin(), sockets_.end(), std::ref(sock));
				if (it != sockets_.end()) {
					RS::Log::Message("Closing socket...");
					sockets_.erase(it);
				}
			});

			threads_.back().detach();
		}
	}

	bool Server::Valid_Auth(const std::string &username, const std::string &password) {
		// Do auth stuff...
		return true;
	}

	void Server::Client_Select_Sheet(const std::string &filename, const std::string &username,
			const std::string &password, kn::tcp_socket &sock) {

		if (Valid_Auth(username, password)) {
			json full_send;
			full_send["type"] = "full send";

			if (std::filesystem::exists(filename)) {
				// auto cells = File::Load_Json(filename);
				// full_send["spreadsheet"] = cells;
				
				auto new_sheet = Spreadsheet{ filename };
				full_send["spreadsheet"] = {};
			}
			else {
				auto new_sheet = Spreadsheet{ filename };
				full_send["spreadsheet"] = {};
			}

			Do_Full_Send(full_send, sock);
		}
		else {
			Do_Error("Bad password.", sock);
		}


	}

	void Server::Do_Full_Send(const json &full_send, kn::tcp_socket &sock) {
		auto msg = std::string{ full_send.dump() + "\n\n" };
		sock.send(reinterpret_cast<const std::byte*>(msg.c_str()), msg.size());
	}

	void Server::Do_Error(const std::string &error_msg, kn::tcp_socket &sock) {
		json j_error = {
			{"type", "error"},
			{"code", 1},
			{"source", ""}
		};
		auto msg = std::string{ j_error.dump() + "\n\n" };
		sock.send(reinterpret_cast<const std::byte*>(msg.c_str()), msg.size());
	}
}