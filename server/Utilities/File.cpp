/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Utilities/File.hpp                                           *
 *                                                                                             *
 *                   Start Date : 04/10/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/11/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * File:                                                                                       *
 *   The file class is responsible for loading/saving local files.                             *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "File.hpp"

namespace RS {
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
}