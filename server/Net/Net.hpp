/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Net/Net.hpp                                                  *
 *                                                                                             *
 *                   Start Date : 04/07/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/11/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Net:                                                                                        *
 *   The net class is responsible all network related tasks.                                   *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef NET_RS_H
#define NET_RS_H

#include "../Utilities/Log.hpp"
#include "asio.hpp"

using asio::ip::tcp;

namespace RS {

	class Net {
	private:
	public:
		static const int DEFAULT_PORT = 2112;
		// static tcp::socket Create_Socket(const std::string &hostname);

	};
}

#endif