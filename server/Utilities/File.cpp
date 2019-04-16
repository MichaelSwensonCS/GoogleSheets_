/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Utilities/File.hpp                                           *
 *                                                                                             *
 *                   Start Date : 04/10/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/15/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * File:                                                                                       *
 *   The file class is responsible for loading/saving local files.                             *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "File.hpp"

namespace RS {

	/*-----------------------------------------------------------------------------------------*
	 * Public Methods                                                                          *
	 *-----------------------------------------------------------------------------------------*/

	json File::Load_Json(const std::string &filename) {
		json j;
		std::ifstream file(filename);
		if (file.is_open()) {
			file >> j;
			file.close();
		}
		else {
			Log::Error("Unable to open JSON file, " + filename);
		}

		return j;
	}

	void File::Save_Json(const std::string &filename, json &j) {
		std::ofstream out(filename);
		out << std::setw(4) << j << std::endl;
		out.close();
	}

	std::vector<std::string> File::List_Spreadsheets(const std::string &path) {
		std::vector<std::string> spreadsheets;
		std::string filename;
		std::string extension;

		for (const auto &file : std::filesystem::directory_iterator(path)) {
			filename = file.path().filename();
			extension = filename.substr(filename.find_last_of('.') + 1);
			if (extension == "sprd") {
				spreadsheets.push_back(filename);
			}
		}

		return spreadsheets;
	}
}