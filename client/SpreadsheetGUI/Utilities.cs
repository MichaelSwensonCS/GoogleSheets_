/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Utilities.cs                                                 *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/15/18                                                     *
 *                                                                                             *
 *                      Modtime : 10/15/18                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using System;
using System.Windows.Forms;

namespace SS {
    public static class Utilities {

        /// <summary>
        /// An error function to be provided when read/write error happens.
        /// Allows for the called method to directly respond with an exceptions.
        /// </summary>
        /// <param name="e">The exception that was thrown.</param>
        public static void ReadWriteErrorAction(Exception e) {
            Exception exception = e as SpreadsheetReadWriteException;
            if (exception != null) {
                PopErrorBox(e.Message, "Spreadsheet Read/Write Exception");
                return;
            }
        }

        /// <summary>
        /// Small helper method to pop an error message box.
        /// </summary>
        /// <param name="msg">The error message.</param>
        /// <param name="caption">The caption of the message box.</param>
        public static void PopErrorBox(string msg, string caption) {
            MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
