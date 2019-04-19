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
 *                      Modtime : 04/15/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using SS.Models;
using SS.Models.NetMessages;
using SS.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SS.Controllers {

    /// <summary>
    /// Handles an "open" command.
    /// </summary>
    /// <param name="server">The server address.</param>
    public delegate void OpenSheetHandler(OpenMessage om, SocketState state);

    /// <summary>
    /// Handles additional subviews that popup from the parent view.
    /// </summary>
    public class SubViewsController {
        private AboutView _about;
        private HelpNavView _helpNav;
        private HelpChangingCellsContentsView _helpCells;
        private HelpAdditionalFeatures _helpFeatures;
        private ConnectView _connectView;
        private OpenNewView _openNew;

        public event FormClosedEventHandler ConnectFormClosed;
        public event FormClosedEventHandler OpenNewFormClosed;
        public event ConnectionHandler ConnectToServer;
        public event OpenSheetHandler OpenSheet;

        private bool _initialLoad;
        private SocketState _state;

        public string OpenNewUsername {
            get { return _openNew.Username; }
            set { _openNew.Username = value; }
        }

        public string OpenNewPassword {
            get { return _openNew.Password; }
            set { _openNew.Password = value; }
        }

        public string OpenNewSpreadsheet {
            get { return _openNew.Spreadsheet; }
            set { _openNew.Spreadsheet = value; }
        }

        public List<string> OpenNewSpreadsheetList {
            get { return _openNew.SpreadsheetList; }
            set { _openNew.SpreadsheetList = value; }
        }

        /// <summary>
        /// Basic constructor that will create all the subviews.
        /// </summary>
        public SubViewsController(bool mode) {
            _about = new AboutView(mode);
            _helpNav = new HelpNavView(mode);
            _helpCells = new HelpChangingCellsContentsView(mode);
            _helpFeatures = new HelpAdditionalFeatures(mode);
            _connectView = new ConnectView(mode);
            _openNew = new OpenNewView(mode);

            _initialLoad = false;

            _connectView.FormClosed += OnConnectClose;
            _connectView.ConnectClicked += OnConnectConnect;
            _openNew.FormClosed += OnOpenNewClose;
            _openNew.OpenClicked += OnOpenNewOpen;

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
        /// Show the "Connect" dialog.
        /// </summary>
        /// <param name="isInitialLoad">If true then treats the dialog as the anchor for the main
        /// running process.</param>
        public void ShowConnectView(bool isInitialLoad) {
            _initialLoad = isInitialLoad;
            _connectView.ShowDialog();
        }

        /// <summary>
        /// Show the "Open/New" dialog.
        /// </summary>
        /// running process.</param>
        public void ShowOpenNewView(List<string> spreadsheets, SocketState state) {
            _state = state;
            _openNew.SpreadsheetList = spreadsheets;
            _openNew.ShowDialog();
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
            _openNew.DarkMode(mode);
        }

        public void ConnectToggleInputs(bool enable) {
            _connectView.ToggleInputs(enable);
        }

        public void EndOpenNew() {
            if (_initialLoad) {
                _initialLoad = false;
                _connectView.Invoke(new MethodInvoker(() => {
                    _connectView.Close();
                }));
            }
            _openNew.Invoke(new MethodInvoker(() => {
                _openNew.Close();
                _openNew.ToggleInputs(true);
            }));
        }

        /// <summary>
        /// Handler for the Connect view when it closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnConnectClose(Object sender, FormClosedEventArgs e) {
            if (_initialLoad) {
                ConnectFormClosed?.Invoke(sender, e);
            }
            else {
                _connectView.Server = "";
            }
        }

        /// <summary>
        /// Handler for the Connect view when the connect action is triggered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnConnectConnect(Object sender, EventArgs e) {
            _connectView.ToggleInputs(false);

            string server = _connectView.Server;
            if (string.IsNullOrEmpty(server)) {
                MessageBox.Show("Please provide a valid server address.", "Error");
                _connectView.ToggleInputs(true);
            }
            else {
                ConnectToServer?.Invoke(server);
            }
        }

        /// <summary>
        /// Handler for the OpenNew view when it closes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenNewClose(Object sender, FormClosedEventArgs e) {
            if (_initialLoad) {
                OpenNewFormClosed?.Invoke(sender, e);
            }
            else {
                _openNew.Username = "";
                _openNew.Password = "";
                _openNew.Spreadsheet = "";
                _openNew.SpreadsheetList = new List<string>();
            }
        }

        /// <summary>
        /// Handler for the OpenNew view when the open/new action is triggered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenNewOpen(Object sender, EventArgs e) {
            _openNew.ToggleInputs(false);
            if (OpenNewAreValidInputs(out List<string> values, out string msg)) {

                OpenMessage om = new OpenMessage(values[2], values[0], values[1]);
                OpenSheet?.Invoke(om, _state);

                _openNew.Invoke(new MethodInvoker(() => {
                    _openNew.ToggleInputs(true);
                }));

                return;
            }
            else {
                MessageBox.Show(msg, "Error");
            }

            _openNew.ToggleInputs(true);
        }

        /// <summary>
        /// Helper function that validates the inputs of the OpenNew view and returns the
        /// inputs if they are valid.
        /// </summary>
        /// <param name="values">Output of all the inputs if they are valid.</param>
        /// <param name="msg">A message that provides detail on an invalid input.</param>
        /// <returns>True if the inputs are valid and false otherwise.</returns>
        private bool OpenNewAreValidInputs(out List<string> values, out string msg) {
            values = new List<string>();
            msg = "";

            string username = _openNew.Username;
            string password = _openNew.Password;
            string spreadsheet = _openNew.Spreadsheet;

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

            if (string.IsNullOrEmpty(spreadsheet)) {
                msg = "Please provide a valid spreadsheet name.";
                return false;
            }
            else {
                values.Add(spreadsheet);
            }

            return true;
        }
    }
}
