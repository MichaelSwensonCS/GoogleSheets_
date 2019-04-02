/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Controllers/SubViewsController.cs                            *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/09/18                                                     *
 *                                                                                             *
 *                      Modtime : 04/02/18                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using SS.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SS.Controllers {

    /// <summary>
    /// Handles additional subviews that popup from the parent view.
    /// </summary>
    public class SubViewsController {
        private AboutView _about;
        private HelpNavView _helpNav;
        private HelpChangingCellsContentsView _helpCells;
        private HelpAdditionalFeatures _helpFeatures;
        private OpenSaveView _openSave;

        public event FormClosedEventHandler OpenSaveFormClosed;
        public event EventHandler OpenSaveOpenClicked;
        public event EventHandler OpenSaveNewClicked;

        private bool _openSaveIsInitialLoad;

        public string OpenSaveUsername {
            get { return _openSave.Username; }
            set { _openSave.Username = value; }
        }

        public string OpenSavePassword {
            get { return _openSave.Password; }
            set { _openSave.Password = value; }
        }

        public string OpenSaveServer {
            get { return _openSave.Server; }
            set { _openSave.Server = value; }
        }

        /// <summary>
        /// Basic constructor that will create all the subviews.
        /// </summary>
        public SubViewsController(bool mode) {
            _about = new AboutView(mode);
            _helpNav = new HelpNavView(mode);
            _helpCells = new HelpChangingCellsContentsView(mode);
            _helpFeatures = new HelpAdditionalFeatures(mode);
            _openSave = new OpenSaveView(mode);

            _openSaveIsInitialLoad = false;

            _openSave.FormClosed += OnOpenSaveClose;
            _openSave.OpenClicked += OnOpenSaveOpen;
            _openSave.NewClicked += OnOpenSaveNew;

            DarkMode(mode);
        }

        /// <summary>
        /// Shows the "About" dialog.
        /// </summary>
        public void ShowAboutView() {
            _about.ShowDialog();
        }

        /// <summary>
        /// Shows the "Navigating Cells" dialog.
        /// </summary>
        public void ShowHelpNavView() {
            _helpNav.ShowDialog();
        }

        /// <summary>
        /// Shows the "Changing Cell Contents" dialog.
        /// </summary>
        public void ShowHelpChangingCellsView() {
            _helpCells.ShowDialog();
        }

        /// <summary>
        /// Show the "Additional Features" dialog.
        /// </summary>
        public void ShowHelpAdditoinalFeaturesView() {
            _helpFeatures.ShowDialog();
        }

        /// <summary>
        /// Show the "Open/Save" dialog.
        /// </summary>
        /// <param name="isInitialLoad">If true then treats the dialog as the anchor for the main
        /// running process.</param>
        public void ShowOpenSaveView(bool isInitialLoad) {
            _openSaveIsInitialLoad = isInitialLoad;
            _openSave.ShowDialog();
        }

        /// <summary>
        /// Switches the theme of this view to or from dark mode.
        /// </summary>
        /// <param name="mode">Enable or disable dark mode.</param>
        public void DarkMode(bool mode) {
            _about.DarkMode(mode);
            _helpNav.DarkMode(mode);
            _helpCells.DarkMode(mode);
            _helpFeatures.DarkMode(mode);
            _openSave.DarkMode(mode);
        }

        /// <summary>
        /// Handler for the OpenSave view when it closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenSaveClose(Object sender, FormClosedEventArgs e) {
            if (_openSaveIsInitialLoad) {
                OpenSaveFormClosed?.Invoke(sender, e);
            }
            else {
                _openSave.Username = "";
                _openSave.Password = "";
                _openSave.Server = "";
            }
        }

        /// <summary>
        /// Handler for the OpenSave view when the open action is triggered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenSaveOpen(Object sender, EventArgs e) {
            _openSave.ToggleInputs(false);
            if (OpenSaveAreValidInputs(out List<string> values, out string msg)) {
                MessageBox.Show($"{{{values[0]}, {values[1]}, {values[2]}}}", "Open");
            }
            else {
                MessageBox.Show(msg, "Error");
            }

            _openSave.ToggleInputs(true);
        }

        /// <summary>
        /// Handler for the OpenSave view when the new action is triggered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenSaveNew(Object sender, EventArgs e) {
            _openSave.ToggleInputs(false);
            if (OpenSaveAreValidInputs(out List<string> values, out string msg)) {
                MessageBox.Show($"{{{values[0]}, {values[1]}, {values[2]}}}", "New");
            }
            else {
                MessageBox.Show(msg, "Error");
            }

            _openSave.ToggleInputs(true);
        }

        /// <summary>
        /// Helper function that validates the inputs of the OpenSave view and returns the
        /// inputs if they are valid.
        /// </summary>
        /// <param name="values">Output of all the inputs if they are valid.</param>
        /// <param name="msg">A message that provides detail on an invalid input.</param>
        /// <returns>True if the inputs are valid and false otherwise.</returns>
        private bool OpenSaveAreValidInputs(out List<string> values, out string msg) {
            values = new List<string>();
            msg = "";

            string username = _openSave.Username;
            string password = _openSave.Password;
            string server = _openSave.Server;

            if (string.IsNullOrEmpty(username)) {
                msg = "Please provide a valid username.";
                return false;
            }
            else {
                values.Add(username);
            }

            if (string.IsNullOrEmpty(password)) {
                msg = "Please provide a valid password.";
                return false;
            }
            else {
                values.Add(password);
            }

            if (string.IsNullOrEmpty(server)) {
                msg = "Please provide a valid server address.";
                return false;
            }
            else {
                values.Add(server);
            }

            return true;
        }
    }
}
