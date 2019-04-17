/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Views/ISpreadsheetView.cs                                    *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/12/18                                                     *
 *                                                                                             *
 *                      Modtime : 10/17/18                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using System;
using System.Windows.Forms;

namespace SS.Views {

    /// <summary>
    /// Interface for the spreadsheet view.
    /// </summary>
    public interface ISpreadsheetView {

        event FormClosingEventHandler FormClosing;
        event KeyPressEventHandler KeyPress;
        event KeyEventHandler KeyDown;

        event SelectionChangedHandler SelectionChanged;
        event KeyPressEventHandler DisplayedContentsKeyPress;
        
        event EventHandler OpenMenuClick;
        event EventHandler CloseMenuClick;

        event EventHandler UndoMenuClick;
        event EventHandler RevertMenuClick;

        event EventHandler DarkModeMenuClick;

        event EventHandler HelpNavMenuClick;
        event EventHandler HelpChangingCellsMenuClick;
        event EventHandler HelpAddtionalFeaturesMenuClick;
        event EventHandler AboutMenuClick;

        /// <summary>
        /// The title of the view.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// The name on display of the currently selected cell.
        /// </summary>
        string DisplayedCellName { get; set; }

        /// <summary>
        /// The value on display of the currently selected cell.
        /// </summary>
        string DisplayedCellValue { get; set; }

        /// <summary>
        /// The contents on display of the currently selected cell.
        /// </summary>
        string DisplayedCellContents { get; set; }

        /// <summary>
        /// Return whether the spreadsheet panel is currently focused or not.
        /// </summary>
        bool SpreadsheetPanelFocused { get; }

        /// <summary>
        /// Clears the spreadsheet view.
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns coordinates of the currently selected cell.
        /// </summary>
        /// <param name="col">The column coordinate output.</param>
        /// <param name="row">The row coordinate output.</param>
        void GetSelectedCellCoords(out int col, out int row);

        /// <summary>
        /// Sets the displayed value of a cell in the spreadsheet panel.
        /// </summary>
        /// <param name="col">The column coordinate of the cell.</param>
        /// <param name="row">The row coordinate of the cell.</param>
        /// <param name="value">The value to display.</param>
        void SetPanelValueOfCell(int col, int row, string value);

        /// <summary>
        /// Sets the currently selected cell on the spreadsheet panel.
        /// </summary>
        /// <param name="col">The column coordinate of the cell.</param>
        /// <param name="row">The row coordinate of the cell.</param>
        void SetSelectedCell(int col, int row);

        /// <summary>
        /// Handler for whenever a cell enters or exits editing mode.
        /// </summary>
        /// <param name="mode">True if in editing mode, false if not.</param>
        void CellBeingEdited(bool mode);

        /// <summary>
        /// Handler for whenever autosave is toggled.
        /// </summary>
        /// <param name="autosave">True if autosave is enabled, false if not.</param>
        void ToggleAutoSave(bool autosave);

        /// <summary>
        /// Switches the theme to or from dark mode.
        /// </summary>
        /// <param name="mode">Enable or disable dark mode.</param>
        void DarkMode(bool mode);

        /// <summary>
        /// Closes the view.
        /// </summary>
        void Close();
    }
}
