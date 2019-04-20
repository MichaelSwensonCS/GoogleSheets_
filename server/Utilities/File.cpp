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

	std::stack<std::string> File::Load_Undo_History(const std::string &filename) {
		std::stack<std::string> output;
		std::vector<std::string> holder;

		// Load file.
		std::string line;
		std::ifstream file(filename);
		if (file.is_open()) {
			while (std::getline(file,line)) {
				holder.push_back(line);
			}

			file.close();
		}
		else {
			Log::Error("Unable to open undo history file, " + filename);
		}

		// Loop backwards to preserve stack ordering.
		for (auto it = holder.rbegin(); it != holder.rend(); it++) {
			output.push(*it);
		}

		return output;
	}

	std::map<std::string, std::stack<std::string>> File::Load_Revert_History(const std::string &filename) {
		std::map<std::string, std::stack<std::string>> output;

		std::string line;
		std::ifstream file(filename);
		if (file.is_open()) {

			json j;
			std::size_t delim;
			std::string key, value;
			while (std::getline(file,line)) {
				delim	= line.find_first_of('=');
				key		= line.substr(0, delim);
				value	= line.substr(delim + 1);
				j		= json::parse(value);

				output[key] = std::stack<std::string>();
				for (auto it = j.rbegin(); it != j.rend(); it++) {
					output[key].push(it.value());
				}
			}

			file.close();
		}
		else {
			Log::Error("Unable to open revert history file, " + filename);
		}

		return output;
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

	void File::Save_Undo_History(const std::string &filename, std::stack<std::string> undo) {
		std::ofstream out(filename);
		if (out.is_open()) {
			while (undo.size() != 0) {
				out << undo.top() << "\n";
				undo.pop();
			}
		}
		else {
			Log::Error("Unable to create undo history file, " + filename);
		}
		
		out.close();
	}

	void File::Save_Revert_History(const std::string &filename, std::map<std::string, std::stack<std::string>> revert) {
		std::vector<std::string> holder;

		std::ofstream out(filename);
		if (out.is_open()) {
			for (auto & [key, val] : revert) {
				out << key << "=[";
				while (val.size() != 0) {
					if (val.size() == 1) {
						out << '\"' << val.top() << "\"";
					}
					else {
						out << '\"' << val.top() << "\",";
					}
					val.pop();
				}
				out << "]\n";
			}
		}
		else {
			Log::Error("Unable to create revert history file, " + filename);
		}

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

	// Taken from: https://stackoverflow.com/questions/216823/whats-the-best-way-to-trim-stdstring
	// {
	// trim from start (in place)
	inline void File::L_Trim(std::string &s) {
		s.erase(s.begin(), std::find_if(s.begin(), s.end(), [](int ch) {
			return !std::isspace(ch);
		}));
	}

	// trim from end (in place)
	inline void File::R_Trim(std::string &s) {
		s.erase(std::find_if(s.rbegin(), s.rend(), [](int ch) {
			return !std::isspace(ch);
		}).base(), s.end());
	}

	// trim from both ends (in place)
	inline void File::Trim(std::string &s) {
		L_Trim(s);
		R_Trim(s);
	}

	// trim from both ends (copying)
	inline std::string File::Trim_Copy(std::string s) {
		Trim(s);
		return s;
	}
	// } end
}