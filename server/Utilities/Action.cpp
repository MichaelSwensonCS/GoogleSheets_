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

#include "Action.hpp"

namespace RS {

	/*-----------------------------------------------------------------------------------------*
	 * Constructor/Destructor Methods                                                          *
	 *-----------------------------------------------------------------------------------------*/

	Action::Action(CL_Action_Type action_type, CL_Action action, const std::string &arg01,
			const std::string &arg02) : action_type_(action_type), action_(action), arg01_(arg01),
			arg02_(arg02) {}

	/*-----------------------------------------------------------------------------------------*
	 * Accessor Methods                                                                        *
	 *-----------------------------------------------------------------------------------------*/

	CL_Action_Type Action::Action_Type() const {
		return action_type_;
	}

	CL_Action Action::The_Action() const {
		return action_;
	}

	const std::string& Action::Arg01() const {
		return arg01_;
	}

	const std::string& Action::Arg02() const {
		return arg02_;
	}
}