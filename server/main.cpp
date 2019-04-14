/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : main.cpp                                                     *
 *                                                                                             *
 *                   Start Date : 04/06/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/14/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * main:                                                                                       *
 *   The main entrypoint for the application.                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include <iostream>
#include <fstream>
#include "nlohmann/json.hpp"
#include "Server.hpp"
#include "Utilities/AParser.hpp"

using json = nlohmann::json;

void json_example(const std::string &filename) {	
	json j;
	std::ifstream file(filename);
	if (file.is_open()) {
		file >> j;
		file.close();
	}
	else {
		std::cout << "Unable to open JSON file." << std::endl; 
	}

	std::cout << "JSON data:" << std::endl;
	std::cout << j.dump() << "\n" << std::endl;
	std::cout << "User " << j["username"] << " wants to open " << j["name"] <<std::endl;
}

int main(int argc, char **argv) {
	RS::AParser argparse(argc, argv);
	auto host = argparse.Host().empty() ? "127.0.0.1" : argparse.Host();
	auto port = argparse.Port() == -1 ? 2112 : argparse.Port();

	RS::Server srv(host, port);
	srv.Start();

	json_example("test.json");
	return 0;
}
