/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Utilities/File.hpp                                           *
 *                                                                                             *
 *                   Start Date : 04/10/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/20/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * File:                                                                                       *
 *   The file class is responsible for loading/saving local files.                             *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef FILE_RS_H
#define FILE_RS_H

#include <cstddef>
#include <filesystem>
#include <fstream>
#include <iomanip>
#include <map>
#include <stack>
#include <string>
#include <tuple>
#include <vector>
#include "Log.hpp"
#include "../Libraries/json.hpp"

using json = nlohmann::json;

namespace RS {
	
	class File {
	private:
		static std::stack<std::string> Load_Undo_History(std::ifstream&);
		static std::map<std::string, std::stack<std::string>> Load_Revert_History(std::ifstream&);
		static void Save_Undo_History(std::ofstream&, std::stack<std::string>&);
		static void Save_Revert_History(std::ofstream&, std::map<std::string, std::stack<std::string>>&);
	public:
		static json Load_Json(const std::string&);
		static std::tuple<std::stack<std::string>, std::map<std::string, std::stack<std::string>>> Load_History(const std::string &filename);
		
		static void Save_Json(const std::string&, json&);
		static void Save_History(const std::string &filename, std::stack<std::string>, std::map<std::string, std::stack<std::string>>);

		static std::vector<std::string> List_Spreadsheets(const std::string&);

		static std::string Get_Extension(const std::string&);
		static std::string Get_Base_Filename(const std::string&);
	};
}

#endif