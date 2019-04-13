/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Msg/Full_Send.hpp                                            *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/13/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Full_Send:                                                                                  *
 *   The full_send class is the model for an "full send" message.                              *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef FULLSEND_RS_H
#define FULLSEND_RS_H

#include "Default.hpp"

using json = nlohmann::json;

namespace RS { namespace Message {

	class Full_Send : Default {
	private:
	public:
		Full_Send();

		json Json() const;


		void Json(json);
	};
}}

#endif