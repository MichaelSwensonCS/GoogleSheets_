/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Controllers/AppController.cs                                 *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/06/18                                                     *
 *                                                                                             *
 *                      Modtime : 04/16/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using SS.Misc;
using SS.Models;
using SS.Views;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SS.Controllers {

    /// <summary>
    /// Represents the context of the overall application state. This allows
    /// for multiple spreadsheet windows to be displayed and maintained properly.
    /// </summary>
    public class AppController : ApplicationContext {

        private static AppController _appCtrl;

        /// <summary>
        /// Tally of spreadsheet windows currently open and running.
        /// </summary>
        public int Instances { get; private set; } = 0;

        /// <summary>
        /// Singleton constructor.
        /// </summary>
        private AppController() { }

        /// <summary>
        /// Retrieves the application controller.
        /// </summary>
        /// <returns></returns>
        public static AppController GetController() {
            if (_appCtrl == null) { _appCtrl = new AppController(); }

            return _appCtrl;
        }

        /// <summary>
        /// Initiates and displays the given window. Also tracks the instance's title.
        /// </summary>
        /// <param name="f"></param>
        public void RunForm(Form f) {
            Instances++;

            f.FormClosed += (o, e) => {
                if (--Instances <= 0) {
                    ExitThread();
                    Application.Exit();
                }
            };

            f.Show();
        }

        /// <summary>
        /// Creates a new spreadsheet window in the app context.
        /// </summary>
        /// <returns>The application context.</returns>
        public void CreateNewWindow() {
            string path = "";
            Dictionary<string, string>  cells = new Dictionary<string, string>();
            if (TryCreateModel(path, cells, out ISpreadsheetModel model)) {
                ISpreadsheetView view = new SpreadsheetView(path, false);
                SubViewsController subViews = new SubViewsController(false);
                ISpreadsheetController controller = new SpreadsheetController(this, view, model, subViews);

                controller.ClosingInitiated += OnInstanceClosing;
            }
        }

        /// <summary>
        /// Helps parse any command line arguments that may have been passed to the program.
        /// </summary>
        /// <param name="args">The arguments to parse.</param>
        public void ParseCommandLineArgs(string[] args) {
            foreach (string s in args) {
                if (string.IsNullOrEmpty(s)) {
                    continue;
                }

                string temp = s.ToLower();
                switch (temp) {
                    case "-log":
                        EnableLogging();
                        break;
                }
            }
        }

        /// <summary>
        /// Loads a new model into an already existing controller.
        /// </summary>
        /// <param name="name">The spreadsheet file to load.</param>
        /// <param name="controller">The instance of the controller to load into.</param>
        public void LoadModelIntoInstance(string name, Dictionary<string, string> cells, ISpreadsheetController controller) {
            if (TryCreateModel(name, cells, out ISpreadsheetModel model)) {
                controller.LoadModelThreaded(model);
            }
        }

        /// <summary>
        /// Safely tries to create a new spreadsheet model.
        /// </summary>
        /// <param name="name">The name of the spreadsheet.</param>
        /// <param name="model">The model object to output.</param>
        /// <returns></returns>
        private bool TryCreateModel(string name, Dictionary<string, string> cells, out ISpreadsheetModel model) {
            bool modelCreated = false;

            model = null;
            try {
                model = new SpreadsheetModel(name, cells);
                modelCreated = true;
            }
            catch (SpreadsheetReadWriteException e) {
                Utilities.PopErrorBox(e.Message, "Spreadsheet Read/Write Exception");
            }

            return modelCreated;
        }

        /// <summary>
        /// Handler for when an instance commits to closing.
        /// </summary>
        /// <param name="controller"></param>
        public void OnInstanceClosing(ISpreadsheetController controller) {
        }

        /// <summary>
        /// Helper method that enables logging for the application.
        /// </summary>
        private void EnableLogging() {
            string path = $"{System.IO.Path.GetDirectoryName(Application.ExecutablePath)}/client.log";
            Log.Start(path);
        }
    }
}
