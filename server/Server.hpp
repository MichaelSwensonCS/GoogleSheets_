/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Server.hpp                                                   *
 *                                                                                             *
 *                   Start Date : 04/06/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/19/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Server:                                                                                     *
 *   The server class is responsible for handling all fundamental server logic. Incoming       *
 *   connections, sending messages, etc.                                                       *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef SERVER_RS_H
#define SERVER_RS_H

#include <algorithm>
#include <csignal>
#include <filesystem>
#include <functional>
#include <memory>
#include <thread>
#include <unistd.h>
#include <vector>
#include "Libraries/json.hpp"
#include "Libraries/kissnet.hpp"
#include "Net/Socket_State.hpp"
#include "Spreadsheet/SNode.hpp"
#include "Utilities/Action.hpp"
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

		std::vector<Action> actions_;

		std::vector<std::thread> threads_;
		std::map<int, Socket_State> connections_;
		std::map<std::string, std::string> users_;
		std::map<std::string, SNode> sheets_;

		void Do_Actions();
		void Do_Account_Create(const Action&);
		void Do_Account_Delete(const Action&);
		void Do_Spreadsheet_Create(const Action&);
		void Do_Spreadsheet_Delete(const Action&);

		void Load_Auth();
		void Save_Auth();
		
		json& Load_Sheet(const std::string&);

		void Update(kn::tcp_socket&);
		void Receive_Message(const json&, Socket_State&);

		bool Valid_Auth(const std::string&, const std::string&);
		void On_Open(const std::string&, const std::string&, const std::string&, Socket_State&);
		void On_Edit(const std::string&, const std::string&, const std::vector<std::string>&, Socket_State&);
		void On_Undo(Socket_State&);
		void On_Revert(const std::string&, Socket_State&);
		void Do_List_Send(Socket_State&);
		void Do_Full_Send(const std::string&, Socket_State&);
		void Do_Edit_Send();
		void Do_Error(int, const std::string&, Socket_State&);

		void Send_Message(const json&, Socket_State&);
	public:
		static const std::string DEFAULT_HOST;
		static const uint16_t DEFAULT_PORT;

		Server(const std::string&, const uint16_t&, const std::vector<Action>&);

		void Start();
	};
}

#endif