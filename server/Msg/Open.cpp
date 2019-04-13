/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Msg/Open.cpp                                                 *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/13/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Open:                                                                                       *
 *   The open class is the model for an "open" message.                                        *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "Open.hpp"

namespace RS { namespace Message {
	Open::Open(const std::string &type, const std::string &name, const std::string &user, const std::string &pass) :
		Default(type), name_(name), user_(user), pass_(pass) {}
}}