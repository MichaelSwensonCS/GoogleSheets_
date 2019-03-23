/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Program.cs                                                   *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/13/18                                                     *
 *                                                                                             *
 *                      Modtime : 10/15/18                                                     *
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
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppController controller = AppController.GetController();
            controller.CreateNewWindow("");
            Application.Run(controller);
        }
    }
}
