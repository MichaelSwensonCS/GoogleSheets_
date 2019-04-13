/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Msg/Open.hpp                                                 *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/13/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Open:                                                                                       *
 *   The open class is the model for an "open" message.                                        *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef OPEN_RS_H
#define OPEN_RS_H

#include "Default.hpp"

namespace RS { namespace Message {
	
	class Open : Default {
	private:
		std::string name_, user_, pass_;
	public:
		Open(const std::string&, const std::string&, const std::string&, const std::string&);
	};
}}

#endif