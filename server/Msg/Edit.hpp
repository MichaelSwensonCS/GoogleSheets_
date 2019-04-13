/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Msg/Edit.hpp                                                 *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/13/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Edit:                                                                                       *
 *   The edit class is the model for an "edit" message.                                        *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef EDIT_RS_H
#define EDIT_RS_H

#include <vector>
#include "Default.hpp"

using json = nlohmann::json;

namespace RS { namespace Message {

	class Edit : Default {
	private:
		std::string cell_, contents_;

		// Maybe just a placeholder until Dep. Graph gets implemented.
		std::vector<std::string> dependencies_;
	public:
		Edit(const std::string&);
		Edit(const std::string&, const std::string&);
		Edit(const std::string&, const std::string&, const std::vector<std::string>&);

		json Json() const;
		const std::string& Cell() const;
		const std::string& Contents() const;
		const std::vector<std::string>& Dependencies() const;

		void Json(json);
		void Cell(const std::string&);
		void Contents(const std::string&);
		void Dependencies(const std::vector<std::string>&);
	};
}}

#endif