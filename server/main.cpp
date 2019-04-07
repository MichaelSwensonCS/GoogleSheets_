#include <iostream>
#include <fstream>
#include "nlohmann/json.hpp"
#include "Server.hpp"

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
	Server srv = Server();
	srv.Start();

	json_example("test.json");
	return 0;
}
