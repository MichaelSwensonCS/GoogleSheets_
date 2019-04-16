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

	/*-----------------------------------------------------------------------------------------*
	 * Class Members                                                                           *
	 *-----------------------------------------------------------------------------------------*/

	const std::string Server::AUTH_FILENAME = "radical_panda$.txt";

	/*-----------------------------------------------------------------------------------------*
	 * Constructor/Destructor Methods                                                          *
	 *-----------------------------------------------------------------------------------------*/

	Server::Server(const std::string &host, const uint16_t &port) : host_(host), port_(port),
			threads_(), sockets_(), sheets_(), users_() {}

	/*-----------------------------------------------------------------------------------------*
	 * Public Methods                                                                          *
	 *-----------------------------------------------------------------------------------------*/

	void Server::Start() {
		RS::Log::Message("Starting server on " + host_ + ":" + std::to_string(port_));

		Load_Auth();

		kn::tcp_socket listen_socket({ host_, port_ });
		listen_socket.bind();
		listen_socket.listen();

		// Must be non-capturing lambda
		// https://stackoverflow.com/questions/11468414/using-auto-and-lambda-to-handle-signal
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

	/*-----------------------------------------------------------------------------------------*
	 * Helper Methods                                                                          *
	 *-----------------------------------------------------------------------------------------*/

	void Server::Load_Auth() {
		json j;
		if (std::filesystem::exists(AUTH_FILENAME)) {
			Log::Success("Found " + AUTH_FILENAME);
			j = File::Load_Json(AUTH_FILENAME);

			for (auto& [key, value] : j.items()) {
				users_[key] = value;
			}
		}
		else {
			Log::Warning("Couldn't find " + AUTH_FILENAME);
			File::Save_Json(AUTH_FILENAME, j);
		}
	}

	void Server::Save_Auth() {
		json j;
		for (auto& [key, value] : users_) {
			j[key] = value;
		}
		File::Save_Json(AUTH_FILENAME, j);
	}

	void Server::Update(kn::tcp_socket &listen_socket) {
		RS::Log::Message("Waiting for client connections.");

		while(true) {
			sockets_.emplace_back(listen_socket.accept());
			auto &sock = sockets_.back();

			auto sprds = RS::File::List_Spreadsheets(std::filesystem::current_path());
			auto list = RS::Message::List{ sprds };
			Send_Message(list.Json(), sock);

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
							auto output = std::string(reinterpret_cast<char*>(buff.data()), size);
							auto msg = json::parse(output);
							Receive_Message(msg, sock);
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

	void Server::Receive_Message(const json &msg, kn::tcp_socket &sock) {
		std::string type = msg["type"];
		if (type == "open") {
			Client_Select_Sheet(msg["name"], msg["username"], msg["password"], sock);
		}
		else if (type == "edit") {

		}
		else if (type == "undo") {

		}
		else if (type == "revert") {

		}
		else {

		}
	}

	bool Server::Valid_Auth(const std::string &username, const std::string &password) {
		bool valid = false;
		if (users_.find(username) == users_.end()) {
			users_[username] = password;

			// Temporary {
			RS::Server::Save_Auth();
			// }

			valid = true;
		}
		else {
			valid = users_[username] == password;
		}

		return valid;
	}

	void Server::Client_Select_Sheet(const std::string &filename, const std::string &username,
			const std::string &password, kn::tcp_socket &sock) {

		if (Valid_Auth(username, password)) {
			Log::Message(username + " authenticated.");
			json full_send;
			full_send["type"] = "full send";

			if (std::filesystem::exists(filename)) {
				// Do stuff to actually load spreadsheet...

				// auto cells = File::Load_Json(filename);
				// full_send["spreadsheet"] = cells;

				// Temp to make just work
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
			Do_Error(1, "", sock);
		}


	}

	void Server::Do_Full_Send(const json &full_send, kn::tcp_socket &sock) {
		Send_Message(full_send, sock);
	}

	void Server::Do_Error(int code, const std::string &source, kn::tcp_socket &sock) {
		json j_error = {
			{"type", "error"},
			{"code", code},
			{"source", source}
		};

		Send_Message(j_error, sock);
	}

	void Server::Send_Message(const json &msg, kn::tcp_socket &sock) {
		auto out = std::string{ msg.dump() + "\n\n" };
		sock.send(reinterpret_cast<const std::byte*>(out.c_str()), out.size());
	}
}