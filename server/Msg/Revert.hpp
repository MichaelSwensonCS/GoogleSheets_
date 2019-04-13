/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Msg/Revert.hpp                                               *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/13/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Revert:                                                                                     *
 *   The revert class is the model for an "revert" message.                                    *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef REVERT_RS_H
#define REVERT_RS_H

#include "Default.hpp"

using json = nlohmann::json;

namespace RS { namespace Message {

	class Revert : Default {
	private:
		std::string cell_;
	public:
		Revert(const std::string&, const std::string&);

		json Json() const;
		const std::string& Cell() const;

		void Json(json);
		void Cell(const std::string&);
	};
}}

#endif