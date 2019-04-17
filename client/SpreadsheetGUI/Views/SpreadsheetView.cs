/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Views/SpreadsheetView.cs                                     *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/06/18                                                     *
 *                                                                                             *
 *                      Modtime : 10/17/18                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using SS.Models;
using SS.Views;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SS {

    /// <summary>
    /// Represents the user interface of a spreadsheet window.
    /// </summary>
    public partial class SpreadsheetView : Form, ISpreadsheetView {
        private const int WIDTH = 800;
        private const int HEIGHT = 600;

        private MenuColorTable _menuColors;

        public event SelectionChangedHandler SelectionChanged;
        public event KeyPressEventHandler DisplayedContentsKeyPress;
        
        public event EventHandler OpenMenuClick;
        public event EventHandler CloseMenuClick;

        public event EventHandler UndoMenuClick;
        public event EventHandler RevertMenuClick;

        public event EventHandler DarkModeMenuClick;

        public event EventHandler HelpNavMenuClick;
        public event EventHandler HelpChangingCellsMenuClick;
        public event EventHandler HelpAddtionalFeaturesMenuClick;
        public event EventHandler AboutMenuClick;

        /// <summary>
        /// The title of the main window.
        /// </summary>
        public string Title {
            get { return this.Text; }
            set { this.Text = value; }
        }

        /// <summary>
        /// The name of the currently selected cell. Displayed outside of the
        /// spreadsheet panel.
        /// </summary>
        public string DisplayedCellName {
            get { return nameLabel.Text; }
            set { nameLabel.Text = value; }
        }

        /// <summary>
        /// The value of the currently selected cell. Displayed outside of the
        /// spreadsheet panel.
        /// </summary>
        public string DisplayedCellValue {
            get { return valueBox.Text; }
            set { valueBox.Text = value; }
        }

        /// <summary>
        /// The contents of the currently selected cell. Displayed outside of the
        /// spreadsheet panel.
        /// </summary>
        public string DisplayedCellContents {
            get { return formulaBox.Text; }
            set { formulaBox.Text = value; }
        }

        /// <summary>
        /// Return whether the spreadsheet panel is currently focused or not.
        /// </summary>
        public bool SpreadsheetPanelFocused {
            get { return spreadsheetPanel.Focused; }
        }

        /// <summary>
        /// Basic constructor for creating a SpreadsheetView. Registers all events for handling.
        /// </summary>
        /// <param name="title">The title of the view.</param>
        /// <param name="darkMode">Toggles the dark theme if true.</param>
        public SpreadsheetView(string title, bool darkMode) {
            InitializeComponent();
            Size = new Size(WIDTH, HEIGHT);
            Title = title;

            _menuColors = new MenuColorTable(darkMode);
            DarkMode(darkMode);

            spreadsheetPanel.SelectionChanged += OnCellSelectionChanged;
            formulaBox.KeyPress += (o, e) => DisplayedContentsKeyPress?.Invoke(o, e);
            
            openMenuItem.Click += (o, e) => OpenMenuClick?.Invoke(o, e);
            closeMenuItem.Click += (o, e) => CloseMenuClick?.Invoke(o, e);

            undoMenuItem.Click += (o, e) => UndoMenuClick?.Invoke(o, e);
            revertMenuItem.Click += (o, e) => RevertMenuClick?.Invoke(o, e);

            undoToolStripMenuItem.Click += (o, e) => UndoMenuClick?.Invoke(o, e);
            reverToolStripMenuItem.Click += (o, e) => RevertMenuClick?.Invoke(o, e);

            darkModeMenuItem.Click += (o, e) => DarkModeMenuClick?.Invoke(o, e);

            navMenuItem.Click += (o, e) => HelpNavMenuClick?.Invoke(o, e);
            changingCellsMenuItem.Click += (o, e) => HelpChangingCellsMenuClick?.Invoke(o, e);
            featuresMenuItem.Click += (o, e) => HelpAddtionalFeaturesMenuClick?.Invoke(o, e);
            aboutMenuItem.Click += (o, e) => AboutMenuClick?.Invoke(o, e);
        }

        /// <summary>
        /// Clears the spreadsheet view.
        /// </summary>
        public void Clear() {
            spreadsheetPanel.Clear();
        }

        /// <summary>
        /// Returns coordinates of the currently selected cell.
        /// </summary>
        /// <param name="col">The column coordinate output.</param>
        /// <param name="row">The row coordinate output.</param>
        public void GetSelectedCellCoords(out int col, out int row) {
            spreadsheetPanel.GetSelection(out col, out row);
        }

        /// <summary>
        /// Sets the displayed value of a cell in the spreadsheet panel.
        /// </summary>
        /// <param name="col">The column coordinate of the cell.</param>
        /// <param name="row">The row coordinate of the cell.</param>
        /// <param name="value">The value to display.</param>
        public void SetPanelValueOfCell(int col, int row, string value) {
            spreadsheetPanel.SetValue(col, row, value);
        }

        /// <summary>
        /// Sets the currently selected cell on the spreadsheet panel.
        /// </summary>
        /// <param name="col">The column coordinate of the cell.</param>
        /// <param name="row">The row coordinate of the cell.</param>
        public void SetSelectedCell(int col, int row) {
            if (spreadsheetPanel.SetSelection(col, row)) {
                if (!spreadsheetPanel.Focused) {
                    spreadsheetPanel.Select();
                }
            }
        }

        /// <summary>
        /// Handler for whenever a cell enters or exits editing mode.
        /// </summary>
        /// <param name="mode">True if in editing mode, false if not.</param>
        public void CellBeingEdited(bool mode) {
            spreadsheetPanel.CellBeingEdited(mode);
        }

        /// <summary>
        /// Handler for whenever autosave is toggled.
        /// </summary>
        /// <param name="autosave">True if autosave is enabled, false if not.</param>
        public void ToggleAutoSave(bool autosave) {
            //autoSaveMenuItem.Checked = autosave;
        }

        /// <summary>
        /// Switches the theme of this view to or from dark mode.
        /// </summary>
        /// <param name="mode">Enable or disable dark mode.</param>
        public void DarkMode(bool mode) {
            SetColorScheme(mode);
            darkModeMenuItem.Checked = mode;
        }

        /// <summary>
        /// Helper method that modifies the view's color scheme.
        /// </summary>
        private void SetColorScheme(bool darkMode) {
            spreadsheetPanel.DarkMode(darkMode);
            _menuColors.DarkMode = darkMode;
            SetMenuColors(darkMode);

            if (darkMode) {
                BackColor = DialogColors.ColorLowAlt;
                SetSelectionBoxColors(DialogColors.ColorMidAlt, DialogColors.ColorHiAlt);
            }
            else {
                BackColor = Color.FromArgb(240, 240, 240);
                SetSelectionBoxColors(Color.White, Color.Black);
            }
        }

        /// <summary>
        /// Helper method that remaps all the selection box control colors.
        /// </summary>
        /// <param name="bg">The controls' background color.</param>
        /// <param name="fg">The controls' foreground color.</param>
        private void SetSelectionBoxColors(Color bg, Color fg) {
            nameLabel.BackColor = bg;
            valueBox.BackColor = bg;
            fxLabel.BackColor = bg;
            formulaBox.BackColor = bg;
            nameLabel.ForeColor = fg;
            valueBox.ForeColor = fg;
            fxLabel.ForeColor = fg;
            formulaBox.ForeColor = fg;
        }

        /// <summary>
        /// Helper method that remaps all the menu controls of the view.
        /// </summary>
        private void SetMenuColors(bool darkMode) {
            menuStrip.Renderer = new ToolStripProfessionalRenderer(_menuColors);
            contextMenu.Renderer = menuStrip.Renderer;

            foreach (ToolStripMenuItem item in menuStrip.Items) {
                item.ForeColor = darkMode ? DialogColors.ColorHiAlt : Color.Black;

                var collection = item.DropDownItems.GetEnumerator();

                while (collection.MoveNext()) {
                    ToolStripMenuItem subItem = collection.Current as ToolStripMenuItem;

                    if (subItem != null) {
                        subItem.ForeColor = darkMode ? DialogColors.ColorHiAlt : Color.Black;
                    }
                }
            }

            foreach (ToolStripMenuItem item in contextMenu.Items) {
                item.ForeColor = darkMode ? DialogColors.ColorHiAlt : Color.Black;
            }
        }

        /// <summary>
        /// Internal view handler for a cell selection change event that is
        /// emitted by the spreadsheet panel.
        /// </summary>
        /// <param name="sp">The spreadsheet panel object.</param>
        private void OnCellSelectionChanged(SpreadsheetPanel sp) {
            spreadsheetPanel.Select();
            SelectionChanged?.Invoke(spreadsheetPanel);
        }
    }
}
