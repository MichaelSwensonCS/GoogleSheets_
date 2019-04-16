/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Server.cpp                                                   *
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

#include "Server.hpp"

namespace RS {

	/*-----------------------------------------------------------------------------------------*
	 * Class Members                                                                           *
	 *-----------------------------------------------------------------------------------------*/

	const std::string Server::AUTH_FILENAME = "radical_panda$.txt";
	const std::string Server::DEFAULT_HOST = "127.0.0.1";
	const uint16_t Server::DEFAULT_PORT = 2112;

	/*-----------------------------------------------------------------------------------------*
	 * Constructor/Destructor Methods                                                          *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Parameterized constructor.
	 *
	 * @param host The host address that the server will listen on.
	 * @param port The port that the server will listen on.
	 * @return A new Spreadsheet instance with a value of the provided type.
	 */
	Server::Server(const std::string &host, const uint16_t &port) : host_(host), port_(port),
			threads_(), sockets_(), sheets_(), users_() {}

	/*-----------------------------------------------------------------------------------------*
	 * Public Methods                                                                          *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Intializes and sets the server to being listening on the given host and port. Upon startup
	 * success any client can connect.
	 *
	 */
	void Server::Start() {
		RS::Log::Message("Starting server on " + host_ + ":" + std::to_string(port_));

		// Load the authentication file.
		Load_Auth();

		// Must be non-capturing lambda.
		// https://stackoverflow.com/questions/11468414/using-auto-and-lambda-to-handle-signal
		std::signal(SIGINT, [](int) {
			RS::Log::Warning("Shutting down.");
			std::exit(0);
		});

		// Send SIGINT if user presses 'enter'.
		std::thread run_th([] {
			RS::Log::Message("Press 'enter' to shutdown the server.");
			std::cin.get();
			std::cin.clear();
			std::raise(SIGINT);
		});

		run_th.detach();

		// Begin listening.
		kn::tcp_socket listen_socket({ host_, port_ });
		listen_socket.bind();
		listen_socket.listen();

		RS::Log::Success("Server started.");

		Update(listen_socket);
	}

	/*-----------------------------------------------------------------------------------------*
	 * Helper Methods                                                                          *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Loads the local authentication file that is specified by AUTH_FILENAME. If the file cannot
	 * be found then the server creates a new one.
	 *
	 */
	void Server::Load_Auth() {
		json j;
		if (std::filesystem::exists(AUTH_FILENAME)) {
			j = File::Load_Json(AUTH_FILENAME);

			for (auto& [key, value] : j.items()) {
				users_[key] = value;
			}
		}
		else {
			Log::Warning("Couldn't find authentication file.");
			File::Save_Json(AUTH_FILENAME, j);
		}
	}

	/*
	 * Saves the current list of authenticated to users to the local authentication file.
	 *
	 */
	void Server::Save_Auth() {
		json j;
		for (auto& [key, value] : users_) {
			j[key] = value;
		}
		File::Save_Json(AUTH_FILENAME, j);
	}

	/*
	 * The server's main update loop which handles new connections and any messages.
	 *
	 * @param listen_socket The server's socket which accepts incomming connections.
	 */
	void Server::Update(kn::tcp_socket &listen_socket) {
		RS::Log::Message("Waiting for client connections.");

		while(true) {
			sockets_.emplace_back(listen_socket.accept());
			auto &sock = sockets_.back();

			// On initial connection, send list of spreadsheets.
			auto sprds = RS::File::List_Spreadsheets(std::filesystem::current_path());
			auto list = RS::Message::List{ sprds };
			Send_Message(list.Json(), sock);

			// Listens to messages from the particular socket.
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

	/*
	 * Handles all incomming messages from clients and decides which action to do depending
	 * on what message comes through.
	 *
	 * @param msg The incomming message formatted as a JSON object.
	 * @param sock The socket for the respective client.
	 */
	void Server::Receive_Message(const json &msg, kn::tcp_socket &sock) {
		std::string type = msg["type"];
		if (type == "open") {
			On_Open(msg["name"], msg["username"], msg["password"], sock);
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

	/*
	 * Validates a given client's credentials that have been sent to the server.
	 *
	 * @param username The username specified from the client.
	 * @param password The password specified from the client.
	 * @return True if the provided credentials are valid and false otherwise.
	 */
	bool Server::Valid_Auth(const std::string &username, const std::string &password) {
		bool valid = false;
		if (users_.find(username) == users_.end()) {
			users_[username] = password;
			RS::Server::Save_Auth();

			valid = true;
		}
		else {
			valid = users_[username] == password;
		}

		return valid;
	}

	/*
	 * Action for when a client selects a spreadsheet to open. If successful, then a "full_send"
	 * message will be sent back. Otherwise an error message will be sent back to the client.
	 *
	 * @param filename The name of the spreadsheet to open/create.
	 * @param username The username specified from the client.
	 * @param password The password specified from the client.
	 * @param sock The socket for the respective client.
	 * @return True if the provided credentials are valid and false otherwise.
	 */
	void Server::On_Open(const std::string &filename, const std::string &username,
			const std::string &password, kn::tcp_socket &sock) {

		if (Valid_Auth(username, password)) {
			Do_Full_Send(filename, sock);
		}
		else {
			Do_Error(1, "", sock);
		}
	}

	/*
	 * Creates and sends a "full_send" message to a client.
	 *
	 * @param filename The name of the spreadsheet to open/create.
	 * @param sock The socket for the respective client.
	 */
	void Server::Do_Full_Send(const std::string &filename, kn::tcp_socket &sock) {
		json full_send;
		if (std::filesystem::exists(filename)) {
			auto it = sheets_.find(filename);
			if (it != sheets_.end()) {
				full_send = it->second;
			}
			else {
				full_send = File::Load_Json(filename);
				sheets_[filename] = full_send;
			}
		}
		else {
			full_send = {
				{"type", "full send"},
				{"spreadsheet", {"A1", ""}}
			};
			sheets_[filename] = full_send;
			File::Save_Json(filename, full_send);
		}

		Send_Message(full_send, sock);
	}

	/*
	 * Creates and sends an error message to a client.
	 *
	 * @param code The error code.
	 * @param source The cell source, if applicable.
	 * @param sock The socket for the respective client.
	 */
	void Server::Do_Error(int code, const std::string &source, kn::tcp_socket &sock) {
		json j_error = {
			{"type", "error"},
			{"code", code},
			{"source", source}
		};

		Send_Message(j_error, sock);
	}

	/*
	 * Small helper method that appends the message terminator ("\n\n") to the outgoing message
	 * and then sends the newly formatted message.
	 *
	 * @param msg The JSON object of the message to send.
	 * @param sock The socket for the respective client.
	 */
	void Server::Send_Message(const json &msg, kn::tcp_socket &sock) {
		auto out = std::string{ msg.dump() + "\n\n" };
		sock.send(reinterpret_cast<const std::byte*>(out.c_str()), out.size());
	}
}