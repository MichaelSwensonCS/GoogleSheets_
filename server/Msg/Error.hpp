/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Msg/Error.hpp                                                *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/13/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Error:                                                                                      *
 *   The error class is the model for an "error" message.                                      *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef ERROR_RS_H
#define ERROR_RS_H

#include "Default.hpp"

using json = nlohmann::json;

namespace RS { namespace Message {

	class Error : Default {
	private:
		int code_;
		std::string src_;
	public:
		Error(int, const std::string&);

		json Json() const;
		int Code() const;
		const std::string& Source() const;

		void Json(json);
		void Code(int);
		void Source(const std::string&);
	};
}}

#endif