﻿/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Program.cs                                                   *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/13/18                                                     *
 *                                                                                             *
 *                      Modtime : 04/06/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using SS.Controllers;
using System;
using System.Windows.Forms;

namespace SS {
    class Program {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppController controller = AppController.GetController();
            controller.ParseCommandLineArgs(args);
            controller.CreateNewWindow();
            Application.Run(controller);
        }
    }
}
