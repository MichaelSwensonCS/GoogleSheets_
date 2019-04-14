/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Utilities/File.hpp                                           *
 *                                                                                             *
 *                   Start Date : 04/10/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/14/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * File:                                                                                       *
 *   The file class is responsible for loading/saving local files.                             *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef FILE_RS_H
#define FILE_RS_H

#include <filesystem>
#include <fstream>
#include <iomanip>
#include <vector>
#include "Log.hpp"
#include "../Libraries/json.hpp"

using json = nlohmann::json;

namespace RS {
	
	class File {
	private:
	public:
		static json Load_Json(const std::string&);
		static void Save_Json(const std::string&, json&);

		static std::vector<std::string> List_Spreadsheets(const std::string&);
	};
}

#endif