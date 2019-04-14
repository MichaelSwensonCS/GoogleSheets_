/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Spreadsheet/Spreadsheet.hpp                                  *
 *                                                                                             *
 *                   Start Date : 04/14/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/14/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Spreadsheet:                                                                                *
 *   The spreadsheet class acts as a spreadsheet model with a list of key-value pairs for the  *
 *   cells contained in the sheet.                                                             *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef SPRDSHT_RS_H
#define SPRDSHT_RS_H

#include "../Libraries/json.hpp"

using json = nlohmann::json;

namespace RS {
	
	class Spreadsheet {
	private:
		std::string name_;
		json cells_;
	public:
		Spreadsheet();
		Spreadsheet(const std::string&);

		int Size() const;
		const std::string& Name() const;
		const json& Cells() const;
		std::string Cell(const std::string &) const;

		void Name(const std::string&);
		void Cells(const json&);
		void Insert(const std::string&, const std::string&);
	};
}

#endif