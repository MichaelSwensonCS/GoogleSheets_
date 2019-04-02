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
 *                      Modtime : 04/02/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

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
        /// A set of the current titles in use by the applicatoin's instances.
        /// </summary>
        public HashSet<string> InstanceTitles { get; } = new HashSet<string>();

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
            if (TryCreateModel(path, out ISpreadsheetModel model)) {
                ISpreadsheetView view = new SpreadsheetView(path, false);
                SubViewsController subViews = new SubViewsController(false);
                ISpreadsheetController controller = new SpreadsheetController(this, view, model, subViews);

                controller.ClosingInitiated += OnInstanceClosing;

                InstanceTitles.Add(path);
            }
        }

        /// <summary>
        /// Loads a new model into an already existing controller.
        /// </summary>
        /// <param name="path">The spreadsheet file to load.</param>
        /// <param name="controller">The instance of the controller to load into.</param>
        public void LoadModelIntoInstance(string path, ISpreadsheetController controller) {
            if (TryCreateModel(path, out ISpreadsheetModel model)) {
                InstanceTitles.Remove(controller.ModelPath);

                controller.LoadModel(model);

                InstanceTitles.Add(path);
            }
        }

        /// <summary>
        /// Safely tries to create a new spreadsheet model.
        /// </summary>
        /// <param name="path">Path to the spreadsheet if available.</param>
        /// <param name="model">The model object to output.</param>
        /// <returns></returns>
        private bool TryCreateModel(string path, out ISpreadsheetModel model) {
            bool modelCreated = false;

            model = null;
            try {
                model = new SpreadsheetModel(path);
                modelCreated = true;
            }
            catch (SpreadsheetReadWriteException e) {
                Utilities.PopErrorBox(e.Message, "Spreadsheet Read/Write Exception");
            }

            return modelCreated;
        }

        /// <summary>
        /// Swaps the title of a given instance.
        /// </summary>
        /// <param name="original">The original instance's title.</param>
        /// <param name="updated">The new title for the instance.</param>
        public static void UpdateInstanceTitle(string original, string updated) {
            AppController appController = AppController.GetController();

            if (appController.InstanceTitles.Contains(original)) {
                if(!appController.InstanceTitles.Contains(updated)) {
                    appController.InstanceTitles.Remove(original);
                    appController.InstanceTitles.Add(updated);
                }
            }
        }

        /// <summary>
        /// Handler for when an instance commits to closing.
        /// </summary>
        /// <param name="controller"></param>
        public void OnInstanceClosing(ISpreadsheetController controller) {
            InstanceTitles.Remove(controller.ModelPath);
        }
    }
}
