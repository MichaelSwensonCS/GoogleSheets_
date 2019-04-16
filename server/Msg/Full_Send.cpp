/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final Project                                         *
 *                                                                                             *
 *                        File  : Msg/Full_Send.hpp                                            *
 *                                                                                             *
 *                   Start Date : 04/13/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/15/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Full_Send:                                                                                  *
 *   The full_send class is the model for an "full send" message.                              *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

#include "Full_Send.hpp"

// This is a stub until Spreadsheet class is implemented.
namespace RS { namespace Message {

	/*-----------------------------------------------------------------------------------------*
	 * Constructor/Destructor Methods                                                          *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Paramaterized constructor.
	 *
	 * @param 
	 * @return A new Full_Send instance with a values of the provided parameters.
	 */
	Full_Send::Full_Send() : Default("full send") {}

	/*-----------------------------------------------------------------------------------------*
	 * Accessor Methods                                                                        *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Gets the JSON representation of this class.
	 *
	 * @return JSON object of this class.
	 */
	json Full_Send::Json() const {
		json j = {
				{"type", type_},
		};

		return j;
	}

	/*-----------------------------------------------------------------------------------------*
	 * Mutator Methods                                                                         *
	 *-----------------------------------------------------------------------------------------*/

	/*
	 * Sets the fields of this class to those specified in the given JSON object.
	 *
	 * @param j The JSON object to use.
	 */
	void Full_Send::Json(json j) {}
}}