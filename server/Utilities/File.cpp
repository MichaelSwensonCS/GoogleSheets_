/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Utilities/File.hpp                                           *
 *                                                                                             *
 *                   Start Date : 04/10/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/16/19                                                     *
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

	/*
	 * Loads a local JSON file.
	 *
	 * @param filename The name of the JSON file to load.
	 * @return A new JSON instance with the associated values from the loaded file.
	 */
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

	/*
	 * Saves a JSON object locally to a file.
	 *
	 * @param filename The name of the JSON file to save.
	 * @param j The JSON object to be saved.
	 */
	void File::Save_Json(const std::string &filename, json &j) {
		std::ofstream out(filename);
		out << std::setw(4) << j << std::endl;
		out.close();
	}

	/*
	 * Returns a list of all the spreadsheets (.sprd) found in a given path.
	 *
	 * @param path The path to search.
	 * @return A list of spreadsheet names.
	 */
	std::vector<std::string> File::List_Spreadsheets(const std::string &path) {
		std::vector<std::string> spreadsheets;
		std::string filename;
		std::string extension;

		for (const auto &file : std::filesystem::directory_iterator(path)) {
			filename = file.path().filename();
			extension = Get_Extension(filename);
			if (extension == "sprd") {
				spreadsheets.push_back(filename);
			}
		}

		return spreadsheets;
	}

	/*
	 * Returns the extension of a provided filename. IE - "test.jpg" would return "jpg".
	 *
	 * @param filename The filename to extract off of.
	 * @return The file's extension.
	 */
	std::string File::Get_Extension(const std::string &filename) {
		return filename.substr(filename.find_last_of('.') + 1);
	}

	/*
	 * Returns the the base name of a file.
	 *
	 * @param filename The filename to extract off of.
	 * @return The base of the filename.
	 */
	std::string File::Get_Base_Filename(const std::string &filename) {
		std::size_t end_dot = filename.find_last_of('.');
		return filename.substr(0, end_dot);
	}
}