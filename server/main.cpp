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

#include "Server.hpp"
#include "Utilities/AParser.hpp"

int main(int argc, char **argv) {
	RS::AParser argparse(argc, argv);
	auto host = argparse.Host().empty() ? "127.0.0.1" : argparse.Host();
	auto port = argparse.Port() == -1 ? 2112 : argparse.Port();

	RS::Server srv(host, port);
	srv.Start();

	return 0;
}
