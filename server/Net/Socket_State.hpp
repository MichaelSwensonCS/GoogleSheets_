/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Net/Socket_State.hpp                                         *
 *                                                                                             *
 *                   Start Date : 04/18/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/18/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Socket_State:                                                                               *
 *   The socket_state class acts as a wrapper for socket objects.                              *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef SOCKETSTATE_RS_H
#define SOCKETSTATE_RS_H

#include <memory>
#include <string>
#include "../Libraries/kissnet.hpp"
#include "../Utilities/Log.hpp"

namespace kn = kissnet;

namespace RS {

	class Socket_State {
	private:
		static int ids_;

		int id_;
		std::string spreadsheet_;
		std::shared_ptr<kn::tcp_socket> socket_;
	public:
		Socket_State();
		Socket_State(const std::string&, std::shared_ptr<kn::tcp_socket>);

		int ID() const;
		const std::string& Spreadsheet() const;
		kn::tcp_socket& Socket();

		void Spreadsheet(const std::string&);
		void Socket(std::shared_ptr<kn::tcp_socket>);
	};
}

#endif