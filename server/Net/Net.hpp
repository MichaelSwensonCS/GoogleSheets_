/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Net.hpp                                                      *
 *                                                                                             *
 *                   Start Date : 04/07/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/07/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Net:                                                                                        *
 *   The net class is responsible all network related tasks.                                   *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#ifndef NET_RS_H
#define NET_RS_H

#include "Utilities/Log.hpp"

class Net {
private:
	bool _running;

public:
	static void Start();
	static void Update();
};

#endif