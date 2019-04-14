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

#include <fstream>
#include <iomanip>
#include "Log.hpp"
#include "../nlohmann/json.hpp"

using json = nlohmann::json;

namespace RS {
	
	class File {
	private:
	public:
		static json Load_Json(const std::string&);
		static void Save_Json(const std::string&, json&);
	};
}

#endif