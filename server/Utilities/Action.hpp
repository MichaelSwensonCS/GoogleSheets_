/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Utilities/Action.hpp                                         *
 *                                                                                             *
 *                   Start Date : 04/17/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/17/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Action:                                                                                     *
 *   The action class helps wrap up actions that the server needs to execute.                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef ACTION_RS_H
#define ACTION_RS_H

#include <string>
#include "Log.hpp"

namespace RS {

	enum class CL_Action_Type { Account, Spreadsheet, Server };
	enum class CL_Action { Create, Delete, Password };

	class Action {
	private:
		CL_Action_Type action_type_;
		CL_Action action_;
		std::string arg01_;
		std::string arg02_;
	public:
		Action(CL_Action_Type, CL_Action, const std::string&, const std::string&);

		CL_Action_Type Action_Type() const;
		CL_Action The_Action() const;
		const std::string& Arg01() const;
		const std::string& Arg02() const;
	};
}

#endif