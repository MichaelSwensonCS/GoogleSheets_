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

	std::tuple<std::stack<std::string>, std::map<std::string, std::stack<std::string>>>
	File::Load_History(const std::string &filename) {
		std::stack<std::string> undo;
		std::map<std::string, std::stack<std::string>> revert;

		std::string line;
		std::ifstream file(filename);
		if (file.is_open()) {
			while (std::getline(file,line)) {
				if (line == "[revert]") {
					revert = Load_Revert_History(file);
					undo = Load_Undo_History(file);
				}
				else if (line == "[undo]") {
					undo = Load_Undo_History(file);
					revert = Load_Revert_History(file);
				}
			}

			file.close();
		}
		else {
			Log::Error("Unable to open history file, " + filename);
		}

		return std::make_tuple(undo, revert);
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

	void File::Save_History(const std::string &filename, std::stack<std::string> undo, std::map<std::string, std::stack<std::string>> revert) {
		std::ofstream file(filename);
		if (file.is_open()) {
			Save_Revert_History(file, revert);
			Save_Undo_History(file, undo);
		}
		else {
			Log::Error("Unable to create history file, " + filename);
		}
		
		file.close();
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

	/*-----------------------------------------------------------------------------------------*
	 * Helper Methods                                                                          *
	 *-----------------------------------------------------------------------------------------*/

	std::stack<std::string> File::Load_Undo_History(std::ifstream &file) {
		std::stack<std::string> output;
		std::vector<std::string> holder;

		// Load file.
		std::string line;
		if (file.is_open()) {
			while (true) {
				std::getline(file,line);

				if (line == "[revert]") { break; }
				if (file.eof()) 		{ break; }

				holder.push_back(line);
			}
		}
		else {
			Log::Error("Unable to load undo segment of history file");
		}

		// Loop backwards to preserve stack ordering.
		for (auto it = holder.rbegin(); it != holder.rend(); it++) {
			output.push(*it);
		}

		return output;
	}

	std::map<std::string, std::stack<std::string>> File::Load_Revert_History(std::ifstream &file) {
		std::map<std::string, std::stack<std::string>> output;

		std::string line;
		if (file.is_open()) {

			json j;
			std::size_t delim;
			std::string key, value;
			while (true) {
				std::getline(file,line);

				if (line == "[undo]") 	{ break; }
				if (file.eof()) 		{ break; }

				delim	= line.find_first_of('=');
				key		= line.substr(0, delim);
				value	= line.substr(delim + 1);
				j		= json::parse(value);

				output[key] = std::stack<std::string>();
				for (auto it = j.rbegin(); it != j.rend(); it++) {
					output[key].push(it.value());
				}
			}
		}
		else {
			Log::Error("Unable to load revert segment of history file.");
		}

		return output;
	}

	void File::Save_Undo_History(std::ofstream &file, std::stack<std::string> &undo) {
		if (file.is_open()) {
			file << "[undo]\n";
			while (undo.size() != 0) {
				file << undo.top() << "\n";
				undo.pop();
			}
		}
		else {
			Log::Error("Unable to save undo segment of history file.");
		}
	}

	void File::Save_Revert_History(std::ofstream &file, std::map<std::string, std::stack<std::string>> &revert) {
		std::vector<std::string> holder;
		if (file.is_open()) {
			file << "[revert]\n";
			for (auto & [key, val] : revert) {
				file << key << "=[";
				while (val.size() != 0) {
					if (val.size() == 1) {
						file << '\"' << val.top() << "\"";
					}
					else {
						file << '\"' << val.top() << "\",";
					}
					val.pop();
				}
				file << "]\n";
			}
		}
		else {
			Log::Error("Unable to save revert segment of history file.");
		}
	}
}