/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Server.cpp                                                   *
 *                                                                                             *
 *                   Start Date : 04/06/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/20/19                                                     *
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
	Server::Server(const std::string &host, const uint16_t &port, const std::vector<Action> &actions)
			: host_(host), port_(port), actions_(actions), threads_(), connections_(), sheets_(), users_() {}

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

		// Execute any actions provided from command line arguments.
		Do_Actions();

		// Must be non-capturing lambda.
		// https://stackoverflow.com/questions/11468414/using-auto-and-lambda-to-handle-signal
		std::signal(SIGINT, [](int) {
			RS::Log::Warning("Shutting down.");
			std::exit(0);
		});

		// Begin listening.
		kn::tcp_socket listen_socket({ host_, port_ });
		listen_socket.bind();
		listen_socket.listen();

		RS::Log::Success("Server started.");
		RS::Log::Message("Press ctrl+c to shutdown the server.");

		Update(listen_socket);
	}

	/*-----------------------------------------------------------------------------------------*
	 * Helper Methods                                                                          *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Executes any actions that were provided from command line arguments.
	 *
	 */
	void Server::Do_Actions() {
		for (const auto &action : actions_) {
			switch(action.Action_Type()) {
				case CL_Action_Type::Account:
					switch(action.The_Action()) {
						case CL_Action::Create:
							Do_Account_Create(action);
							break;
						case CL_Action::Delete:
							Do_Account_Delete(action);
							break;
					}
					break;
				case CL_Action_Type::Spreadsheet:
					switch(action.The_Action()) {
						case CL_Action::Create:
							Do_Spreadsheet_Create(action);
							break;
						case CL_Action::Delete:
							Do_Spreadsheet_Delete(action);
							break;
					}
					break;
				default:
					break;
			}
		}
	}

	/*
	 * Attempts to create a new user account, based on data provided from the action.
	 *
	 * @param action The related action object.
	 */
	void Server::Do_Account_Create(const Action &action) {
		// Get password from user.
		std::string pw(RS::Log::Prompt_Password(action.Arg01()));

		// Verify.
		if (users_.find(action.Arg01()) == users_.end()) {
			users_[action.Arg01()] = pw;
			RS::Server::Save_Auth();
			RS::Log::Success("User " + action.Arg01() + " created.");
		}
		else {
			RS::Log::Error("User already exists! No changes applied.");
		}
	}

	/*
	 * Attempts to delete a user account, based on the data provided from the action.
	 *
	 * @param action The related action object.
	 */
	void Server::Do_Account_Delete(const Action &action) {
		auto it = users_.find(action.Arg01());
		if (it != users_.end()) {
			users_.erase(it);
			RS::Server::Save_Auth();
			RS::Log::Success("User " + action.Arg01() + " deleted.");
		}
		else {
			RS::Log::Error("Can't delete user " + action.Arg01() + " because user doesn't exist.");
		}
	}

	/*
	 * Attempts to create a new spreadsheet, based on data provided from the action.
	 *
	 * @param action The related action object.
	 */
	void Server::Do_Spreadsheet_Create(const Action &action) {
		bool create_new = false;

		if (std::filesystem::exists(action.Arg01())) {
			std::string response;

		response_check:
			response = RS::Log::Prompt_Overwrite(action.Arg01());
			std::transform(response.begin(), response.end(), response.begin(), ::tolower);
			if (response == "y" || response == "yes") {
				create_new = true;
			}
			else if (response == "n" || response == "no") {
				RS::Log::Message("No action taken.");
			}
			else {
				goto response_check;
			}
		}
		else {
			create_new = true;
		}

		if (create_new) {
			json sheet = {
				{"type", "full send"},
				{"spreadsheet", {
					{"A1", ""},
					{"A2", ""}
				}}
			};

			File::Save_Json(action.Arg01(), sheet);
			RS::Log::Success("Spreadsheet " + action.Arg01() + " created.");
		}
	}

	/*
	 * Attempts to delete a spreadsheet, based on the data provided from the action.
	 *
	 * @param action The related action object.
	 */
	void Server::Do_Spreadsheet_Delete(const Action &action) {
		if (std::filesystem::exists(action.Arg01())) {
			unlink(action.Arg01().c_str());
			RS::Log::Success("Spreadsheet " + action.Arg01() + " deleted.");
		}
		else {
			RS::Log::Error("Can't delete spreadsheet " + action.Arg01() + " because it doesn't exist.");
		}
	}

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

	json& Server::Load_Sheet(const std::string &filename) {
		json sheet;
		auto history_filename = File::Get_Base_Filename(filename) + ".history";

		// Load .sprd file.
		if (std::filesystem::exists(filename)) {
			sheet = File::Load_Json(filename);
		}
		else {
			sheet = {
				{"type", "full send"},
				{"spreadsheet", {
					{"A1", ""},
					{"A2", ""}
				}}
			};
			File::Save_Json(filename, sheet);
		}

		sheets_[filename].Sheet() = sheet;
		
		// Load .history file.
		if (std::filesystem::exists(history_filename)) {
			auto history = RS::File::Load_History(history_filename);
			sheets_[filename].History(std::get<0>(history), std::get<1>(history));
		}
		else {

		}

		return sheets_[filename].Sheet();
	}

	void Server::Save_Sheet(const std::string &filename, SNode &node) {
		auto history_filename = File::Get_Base_Filename(filename) + ".history";

		json& sheet = node.Sheet();
		RS::File::Save_Json(filename, sheet);
		RS::File::Save_History(history_filename, node.Undo(), node.Revert());
	}

	/*
	 * The server's main update loop which handles new connections and any messages.
	 *
	 * @param listen_socket The server's socket which accepts incomming connections.
	 */
	void Server::Update(kn::tcp_socket &listen_socket) {
		RS::Log::Message("Waiting for client connections.");

		while(true) {
			auto accept = std::make_shared<kn::tcp_socket>(listen_socket.accept());
			Socket_State connection("", accept);
			connections_[connection.ID()] = connection;

			auto &state = connections_[connection.ID()];

			// On initial connection, send list of spreadsheets.
			Do_List_Send(state);

			// Listens to messages from the particular socket.
			threads_.emplace_back([&]{
				bool receive = true;
				kn::buffer<1024> buff;

				while(receive) {
					auto [size, valid] = state.Socket().recv(buff);

					if (valid) {
						if (valid.value == kn::socket_status::cleanly_disconnected) {
							receive = false;
						}
						else {
							auto output = std::string(reinterpret_cast<char*>(buff.data()), size);
							auto msg = json::parse(output);
							Receive_Message(msg, state);
						}
					}
					else {
						receive = false;
					}
				}

				RS::Log::Message("Client disconnect.");
				const auto it = connections_.find(state.ID());
				if (it != connections_.end()) {
					if (!state.Spreadsheet().empty()) {
						sheets_[state.Spreadsheet()].Clients().erase(state.ID());
					}
					connections_.erase(it);
					RS::Log::Message("Socket removed.");
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
	 * @param state The socket state for the respective client.
	 */
	void Server::Receive_Message(const json &msg, Socket_State &state) {
		std::string type = msg["type"];
		if (type == "open") {
			On_Open(msg["name"], msg["username"], msg["password"], state);
		}
		else if (type == "edit") {
			On_Edit(msg["cell"], msg["value"], msg["dependencies"], state);
		}
		else if (type == "undo") {
			On_Undo(state);
		}
		else if (type == "revert") {
			On_Revert(msg["cell"], state);
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
	 * @param state The socket state for the respective client.
	 */
	void Server::On_Open(const std::string &filename, const std::string &username,
			const std::string &password, Socket_State &state) {

		if (Valid_Auth(username, password)) {
			state.Spreadsheet(filename);
			Do_Full_Send(filename, state);
		}
		else {
			Do_Error(1, "", state);
		}
	}

	/*
	 * Action for when a client sends an edit.
	 *
	 * @param cell The cell that was edited.
	 * @param contents The new contents of the cell.
	 * @param dependencies The direct dependents of the cell.
	 * @param state The socket state for the respective client.
	 */
	void Server::On_Edit(const std::string &cell, const std::string &contents,
			const std::vector<std::string> &dependencies, Socket_State &state) {

		// Verify
		// TODO

		// Initial setup.
		int id = state.ID();
		std::string filename = state.Spreadsheet();
		SNode node = sheets_[filename];
		json& sheet = node.Sheet();

		// Set sheet data and history.
		sheet["spreadsheet"][cell] = contents;
		node.Push_Edit(cell, contents, dependencies);

		// Save.
		Save_Sheet(filename, node);

		// Echo edits to clients on same sheet.
		for (int client : node.Clients()) {
			if (client == id) { continue; }
			else {
				Do_Full_Send(sheet, connections_[client]);
			}
		}
	}

	/*
	 * Action for when a client sends an undo.
	 *
	 * @param state The socket state for the respective client.
	 */
	void Server::On_Undo(Socket_State &state) {
		// Initial setup.
		int id = state.ID();
		std::string filename = state.Spreadsheet();
		SNode node = sheets_[filename];
		json& sheet = node.Sheet();

		// Undo.
		std::string contents = node.Do_Undo();

		// Save.
		Save_Sheet(filename, node);

		// Send back previous contents to clients.
		for (int client : node.Clients()) {
			Do_Full_Send(state.Spreadsheet(), connections_[client]);
		}
	}
	
	/*
	 * Action for when a client sends a revert.
	 *
	 * @param cell The cell that was edited.
	 * @param state The socket state for the respective client.
	 */
	void Server::On_Revert(const std::string &cell, Socket_State &state) {
		// Initial setup.
		int id = state.ID();
		std::string filename = state.Spreadsheet();
		SNode node = sheets_[filename];
		json& sheet = node.Sheet();

		// Revert.
		std::string contents = node.Do_Revert(cell);

		// Save.
		Save_Sheet(filename, node);

		// Send back previous contents to clients.
		for (int client : sheets_[state.Spreadsheet()].Clients()) {
			Do_Full_Send(state.Spreadsheet(), connections_[client]);
		}
	}

	/*
	 * Creates and sends a "list" message to a client.
	 *
	 * @param state The socket state for the respective client.
	 */
	void Server::Do_List_Send(Socket_State &state) {
		auto sprds = RS::File::List_Spreadsheets(std::filesystem::current_path());

		json list = {
			{"type", "list"},
			{"spreadsheets", sprds}
		};

		Send_Message(list, state);
	}

	/*
	 * Creates and sends a "full_send" message to a client.
	 *
	 * @param filename The name of the spreadsheet to open/create.
	 * @param state The socket state for the respective client.
	 */
	void Server::Do_Full_Send(const std::string &filename, Socket_State &state) {
		json full_send;

		// Check if sheet is already loaded.
		auto it = sheets_.find(filename);
		if (it != sheets_.end()) {
			full_send = it->second.Sheet();
		}
		else {
			full_send = Load_Sheet(filename);
		}

		// Store connection reference and send message.
		sheets_[filename].Clients().insert(state.ID());
		Send_Message(full_send, state);
	}

	/*
	 * Creates and sends an error message to a client.
	 *
	 * @param code The error code.
	 * @param source The cell source, if applicable.
	 * @param state The socket state for the respective client.
	 */
	void Server::Do_Error(int code, const std::string &source, Socket_State &state) {
		json j_error = {
			{"type", "error"},
			{"code", code},
			{"source", source}
		};

		Send_Message(j_error, state);
	}

	/*
	 * Small helper method that appends the message terminator ("\n\n") to the outgoing message
	 * and then sends the newly formatted message.
	 *
	 * @param msg The JSON object of the message to send.
	 * @param state The socket state for the respective client.
	 */
	void Server::Send_Message(const json &msg, Socket_State &state) {
		auto out = std::string{ msg.dump() + "\n\n" };
		state.Socket().send(reinterpret_cast<const std::byte*>(out.c_str()), out.size());
	}
}