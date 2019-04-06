/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Controllers/SpreadsheetController.cs                         *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/06/18                                                     *
 *                                                                                             *
 *                      Modtime : 04/06/18                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using SpreadsheetUtilities;
using SS.Misc;
using SS.Models;
using SS.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SS.Controllers {

    /// <summary>
    /// Handles a closing SpreadsheetController.
    /// </summary>
    /// <param name="sender"></param>
    public delegate void ClosingHandler(ISpreadsheetController sender);

    /// <summary>
    /// Represents the binding member between a SpreadsheetModel and a SpreadsheetView. All interactions
    /// between the model and view are handled by the controller.
    /// </summary>
    public class SpreadsheetController : ISpreadsheetController {
        // Used to try to safely disconnect from a server.
        private CancellationTokenSource _client;
        private CancellationToken _cancelToken;

        private static readonly string CircularExceptionMessage =
            "This current modification to the cell has created a circular dependence either directly or indirectly" +
            "through the cells that rely on it.\n\nNo cells have been updated.";

        private const char KEY_ENTER = (char)0xD;
        private const char KEY_TAB = (char)0x9;
        private const char KEY_BACKSPACE = (char)0x8;

        private ISpreadsheetView _view;
        private ISpreadsheetModel _model;
        private SubViewsController _subViews;

        /// <summary>
        /// Triggers when the controller commits to closing.
        /// </summary>
        public event ClosingHandler ClosingInitiated;

        /// <summary>
        /// The path associated with the controller.
        /// </summary>
        public string ModelPath { get { return _model.FilePath; } }

        /// <summary>
        /// Constructor that initializes the given view, model, and subviews.
        /// </summary>
        /// <param name="appController">The main application controller.</param>
        /// <param name="view">The view associated with this controller.</param>
        /// <param name="model">The model associated with this controller.</param>
        /// <param name="subviews">The subviews associated with this controller.</param>
        public SpreadsheetController(AppController appController, ISpreadsheetView view,
                                    ISpreadsheetModel model, SubViewsController subviews) {
            _view = view;
            _model = model;
            _subViews = subviews;

            Load(appController);
            _subViews.ShowConnectView(true);
        }

        /// <summary>
        /// Helper method to handle initialization of the controller and its associated components.
        /// </summary>
        /// <param name="appController">The main application controller.</param>
        private void Load(AppController appController) {
            LoadModel(_model);

            _client = new CancellationTokenSource();
            _cancelToken = _client.Token;

            PropagateHandlers();

            appController.RunForm(_view as SpreadsheetView);
        }

        /// <summary>
        /// Loads a model into the controller.
        /// </summary>
        /// <param name="model">The model to load.</param>
        public void LoadModel(ISpreadsheetModel model) {
            _model = model;
            _view.Clear();
            _view.Title = _model.FilePath;

            _view.DisplayedCellName = _model.Current.Name;
            _view.DisplayedCellContents = _model.Current.Contents;
            _view.SetSelectedCell(_model.Current.Coords.X, _model.Current.Coords.Y);
            
            List<Tuple<Point, string>> cells = _model.GetCellValues(null);
            foreach (Tuple<Point, string> cell in cells) {
                _view.SetPanelValueOfCell(cell.Item1.X, cell.Item1.Y, cell.Item2);
            }

            _view.DisplayedCellValue = _model.Current.Value;

            _model.PropertyChanged += OnModelPropertyChange;
        }

        /// <summary>
        /// Responsible for wiring up all the handlers that the controller will rely on for particular events.
        /// Most events pertain to events triggered from the view.
        /// </summary>
        private void PropagateHandlers() {
            _view.FormClosing += OnMainWindowClosing;
            _view.KeyPress += OnMainWindowKeyPress;

            _view.SelectionChanged += OnCellSelectionChanged;
            _view.DisplayedContentsKeyPress += OnFormulaBoxKeyPressed;
            
            _view.OpenMenuClick += OnOpenClick;
            _view.CloseMenuClick += (o, e) => _view.Close();

            _view.CutMenuClick += OnCutClick;
            _view.CopyMenuClick += OnCopyClick;
            _view.PasteMenuClick += OnPasteClick;

            _view.DarkModeMenuClick += OnDarkModeClick;

            _view.HelpNavMenuClick += (o, e) => _subViews.ShowHelpNavView();
            _view.HelpChangingCellsMenuClick += (o, e) => _subViews.ShowHelpChangingCellsView();
            _view.HelpAddtionalFeaturesMenuClick += (o, e) => _subViews.ShowHelpAdditoinalFeaturesView();
            _view.AboutMenuClick += (o, e) => _subViews.ShowAboutView();

            _model.PropertyChanged += OnModelPropertyChange;

            _subViews.ConnectFormClosed += OnConnectClosed;
            _subViews.OpenNewFormClosed += OnOpenSaveClosed;
            _subViews.ConnectToServer += OnConnectToServer;
        }

        /// <summary>
        /// Handler for when the main view begins to close.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMainWindowClosing(object sender, FormClosingEventArgs e) {
            ClosingInitiated?.Invoke(this);
        }

        /// <summary>
        /// Handler that looks at the whole view's key presses. However, the main logic pertains to when
        /// the spreadsheet panel is focused. Mostly it is responsible for allowing the user type on
        /// any cell to start modifying that cell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMainWindowKeyPress(object sender, KeyPressEventArgs e) {
            if (_view.SpreadsheetPanelFocused) {

                _view.GetSelectedCellCoords(out int col, out int row);
                string value = _view.DisplayedCellValue;

                switch (e.KeyChar) {
                    case KEY_TAB:
                    case KEY_ENTER:
                        return;
                    case KEY_BACKSPACE:
                        if (_model.Current.Modified) {
                            if (value.Length - 1 < 0) {
                                _view.DisplayedCellValue = "";
                            }
                            else {
                                _view.DisplayedCellValue = value.Substring(0, value.Length - 1);
                            }
                        }
                        else {
                            if (_model.Current.Contents != "") {
                                _model.Current.OriginalContents = _model.Current.Contents;
                                _model.Current.Modified = true;
                                _view.DisplayedCellValue = "";

                                _view.CellBeingEdited(true);
                            }
                        }
                        break;
                    default:
                        if (_model.Current.Modified) {
                            _view.DisplayedCellValue = value + e.KeyChar;
                        }
                        else {
                            _model.Current.OriginalContents = _model.Current.Contents;
                            _model.Current.Modified = true;
                            _view.DisplayedCellValue = "" + e.KeyChar;

                            _view.CellBeingEdited(true);
                        }
                        break;
                }

                _view.SetPanelValueOfCell(col, row, _view.DisplayedCellValue);
                _view.DisplayedCellContents = _view.DisplayedCellValue;
            }
        }

        /// <summary>
        /// Handler for responding to a cell selection change. It's responsible for
        /// displaying the correct information of the newly selected cell. Also responsible
        /// for evaluating the cell that the selection is coming from.
        /// </summary>
        /// <param name="sp">The spreadsheet panel control.</param>
        private void OnCellSelectionChanged(SpreadsheetPanel sp) {
            sp.GetSelection(out int col, out int row);
            _model.Current.Contents = _view.DisplayedCellContents;
            List<Tuple<Point, string>> cellsToUpdate = _model.ChangeCurrentCell(col, row, CellUpdateActionError);

            if (cellsToUpdate != null) {
                foreach (Tuple<Point, string> cell in cellsToUpdate) {
                    _view.SetPanelValueOfCell(cell.Item1.X, cell.Item1.Y, cell.Item2);
                }

                _view.CellBeingEdited(false);
            }

            UpdateSelectedCellDisplayValues(_model.Current);
        }

        /// <summary>
        /// An error function to be provided to the model when ChangeCurrentCell is called.
        /// Allows for the model to directly respond with any exceptions.
        /// </summary>
        /// <param name="e"></param>
        private void CellUpdateActionError(Exception e) {
            Exception exception = e as CircularException;
            if (exception != null) {
                Utilities.PopErrorBox(CircularExceptionMessage, "Circular Exception");
                _view.SetPanelValueOfCell(_model.Previous.Coords.X, _model.Previous.Coords.Y, _model.Previous.Value);
                return;
            }

            exception = e as FormulaFormatException;
            if (exception != null) {
                Utilities.PopErrorBox(exception.Message, "Formula Format Exception");
                _view.SetPanelValueOfCell(_model.Previous.Coords.X, _model.Previous.Coords.Y, _model.Previous.Value);
            }
        }

        /// <summary>
        /// Handler for when a key is pressed on the formula input box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormulaBoxKeyPressed(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Enter) {
                if (_model.Current.Modified) {
                    _model.Current.Contents = _view.DisplayedCellContents;
                    _view.SetSelectedCell(_model.Current.Coords.X, _model.Current.Coords.Y + 1);
                }
            }
            else {
                if (!_model.Current.Modified) {
                    _model.Current.OriginalContents = _model.Current.Contents;
                    _model.Current.Modified = true;
                }
            }
        }

        /// <summary>
        /// Handler that is responsible for showing the open dialog to load a spreadsheet file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenClick(object sender, EventArgs e) {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Spreadsheet Files|*.sprd|All files (*.*)|*.*";
            //openFileDialog.Title = "Select a Spreadsheet File";

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    if (openFileDialog.FilterIndex == 1)
            //    {
            //        string ext = Path.GetExtension(openFileDialog.SafeFileName);

            //        if (ext != ".sprd") { }
            //    }

            //    //AppController.CreateNewWindow(openFileDialog.FileName);
            //    AppController.GetController().LoadModelIntoInstance(openFileDialog.FileName, this);
            //}

            _subViews.ShowOpenNewView();
        }

        /// <summary>
        /// Handler for when a cut event is triggered. Cuts out the selected cell contents and stores
        /// them in the clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCutClick(object sender, EventArgs e) {
            CopyToClipboard(_view.DisplayedCellValue);

            _model.Current.OriginalContents = _model.Current.Contents;
            _model.Current.Contents = "";

            _model.UpdateCellContents(_model.Current, CellUpdateActionError);
            UpdateSelectedCellDisplayValues(_model.Current);
        }

        /// <summary>
        /// Handler for when a copy event is triggered. Copies the selected cell contents and stores
        /// them in the clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCopyClick(object sender, EventArgs e) {
            CopyToClipboard(_view.DisplayedCellValue);
        }

        /// <summary>
        /// Handler for when a paste event is triggered. Pastes whatever is stored in the clipboard
        /// into the selected cell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPasteClick(object sender, EventArgs e) {
            _model.Current.OriginalContents = _model.Current.Contents;
            _model.Current.Contents = PasteFromClipboard();

            _model.UpdateCellContents(_model.Current, CellUpdateActionError);
            UpdateSelectedCellDisplayValues(_model.Current);
        }

        /// <summary>
        /// Helper method to copy a value to the clipboard.
        /// </summary>
        /// <param name="value"></param>
        private void CopyToClipboard(string value) {
            if (value == "") {
                Clipboard.Clear();
            }
            else {
                Clipboard.SetText(value);
            }
        }

        /// <summary>
        /// Helper method to paste a value from the clipboard.
        /// </summary>
        /// <returns></returns>
        private string PasteFromClipboard() {
            string value = Clipboard.GetText();
            if (string.IsNullOrEmpty(value)) {
                return "";
            }
            else {
                return value;
            }
        }

        /// <summary>
        /// Handler for when a theme change to and from dark mode is toggled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDarkModeClick(Object sender, EventArgs e) {
            _model.DarkMode = !_model.DarkMode;

            _view.DarkMode(_model.DarkMode);
            _subViews.DarkMode(_model.DarkMode);
        }

        /// <summary>
        /// Handler for when the model's properties change, and specifically the PendingSave state.
        /// Used for the autosave functionality.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnModelPropertyChange(Object sender, PropertyChangedEventArgs e) {
            if (e.PropertyName == "PendingSave") {
                //if (_model.PendingSave) {
                //    if (_autoSave) {
                //        Save(out DialogResult result);
                //    }
                //}

                UpdateViewTitle(_model.FilePath);
            }
        }

        /// <summary>
        /// Helper method to update all the visual components of a selected cell.
        /// </summary>
        /// <param name="cell">The cell to display.</param>
        private void UpdateSelectedCellDisplayValues(Cell cell) {
            _view.DisplayedCellName = cell.Name;
            _view.DisplayedCellValue = cell.Value;
            _view.DisplayedCellContents = cell.Contents;
            _view.SetPanelValueOfCell(cell.Coords.X, cell.Coords.Y, cell.Value);
        }

        /// <summary>
        /// Small helper method to display autosave notification in the view title.
        /// </summary>
        /// <param name="path">The spreadsheet path.</param>
        private void UpdateViewTitle(string path) {
            _view.Title = path;
        }

        private void OnConnectClosed(Object sender, EventArgs e) {
            _view.Close();
        }

        private void OnOpenSaveClosed(Object sender, EventArgs e) {
            _view.Close();
        }

        /*---------------------------------------------------------------------------------------------*
         * Networking Related Calls and Callbacks                                                      *
         *---------------------------------------------------------------------------------------------*/
        

        private void OnConnectToServer(string server) {
            if (Log.Enabled) {
                Log.WriteLine($"Attempting to connect to {server}...", true);
            }

            try {
                Net.ConnectToServer(InitialConnection, server, _cancelToken);
            }
            catch (Exception exception) {

            }
        }

        /// <summary>
        /// Callback function that is used when a client first connects to a server.
        /// </summary>
        /// <param name="state">The socket state.</param>
        private void InitialConnection(SocketState state) {
            if (state.Error) {
                //_viewForm.Invoke(new MethodInvoker(() => {
                //    _view.ShowErrorMessage(state.ErrorMessage, _model.DarkMode);
                //    _view.ToggleConnectionControls(true);
                //}));
                if (Log.Enabled) {
                    Log.WriteLine($"Connection failed.", true);
                }
            }
            else {
                if (Log.Enabled) {
                    Log.WriteLine($"Connection created.", true);
                }
                _subViews.ShowOpenNewView();

                state.Callback = ReceiveInitialData;
                Net.Send(state.Socket, "Wassup world");
                Net.GetData(state);
            }
        }

        /// <summary>
        /// Callback function that is used when the client first receives data transmission.
        /// </summary>
        /// <param name="state">The socket state.</param>
        private void ReceiveInitialData(SocketState state) {
            //if (state.Error) {
            //    _viewForm.Invoke(new MethodInvoker(() => {
            //        _view.ShowErrorMessage(state.ErrorMessage, _model.DarkMode);
            //        _view.ToggleConnectionControls(true);
            //    }));
            //}
            //else {
            //    // Acknowledge this is the first message received and process it.
            //    state.InitialMessage = true;
            //    ProcessMessagesAndUpdate(state);

            //    // Notify view and model of being connectd.
            //    _model.Connected = true;
            //    _model.InGame = true;
            //    _viewForm.Invoke(new MethodInvoker(() => {
            //        _view.ServerConnected(_model.Connected);
            //    }));

            //    // Request more data.
            //    state.Callback = ReceiveWorld;
            //    Net.GetData(state);
            //}
        }
    }
}
