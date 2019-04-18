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

#include "Socket_State.hpp"

namespace RS {

	/*-----------------------------------------------------------------------------------------*
	 * Class Members                                                                           *
	 *-----------------------------------------------------------------------------------------*/

	int Socket_State::ids_ = 0;

	/*-----------------------------------------------------------------------------------------*
	 * Constructor/Destructor Methods                                                          *
	 *-----------------------------------------------------------------------------------------*/

	Socket_State::Socket_State() : spreadsheet_(""), socket_(nullptr), id_(ids_++) {}

	Socket_State::Socket_State(const std::string &spreadsheet, std::shared_ptr<kn::tcp_socket> socket) :
			spreadsheet_(spreadsheet), socket_(socket), id_(ids_++) {}

	/*-----------------------------------------------------------------------------------------*
	 * Accessor Methods                                                                        *
	 *-----------------------------------------------------------------------------------------*/

	int Socket_State::ID() const {
		return id_;
	}

	const std::string& Socket_State::Spreadsheet() const {
		return spreadsheet_;
	}

	kn::tcp_socket& Socket_State::Socket() {
		return *socket_;
	}

	/*-----------------------------------------------------------------------------------------*
	 * Mutator Methods                                                                         *
	 *-----------------------------------------------------------------------------------------*/

	void Socket_State::Spreadsheet(const std::string &spreadsheet) {
		spreadsheet_ = spreadsheet;
	}

	void Socket_State::Socket(std::shared_ptr<kn::tcp_socket> socket) {
		socket_ = socket;
	}

}