/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : main.cpp                                                     *
 *                                                                                             *
 *                   Start Date : 04/06/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/16/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * main:                                                                                       *
 *   The main entrypoint for the application.                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "Server.hpp"
#include "Utilities/AParser.hpp"

/*
 * The main entrypoint for the application. All command line arguments that have been specified
 * are checked. Then the server is created and started.
 *
 * @param argc The total count of arguments provided.
 * @param argv The arguments that have been provided.
 */
int main(int argc, char **argv) {
	RS::AParser argparse(argc, argv);
	auto host = argparse.Host().empty() ? RS::Server::DEFAULT_HOST : argparse.Host();
	auto port = argparse.Port() == -1 ? RS::Server::DEFAULT_PORT : argparse.Port();

	RS::Server srv(host, port);
	srv.Start();

	return 0;
}
