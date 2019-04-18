/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Models/ISpreadsheetModel.cs                                  *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/12/18                                                     *
 *                                                                                             *
 *                      Modtime : 04/14/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace SS.Models {

    /// <summary>
    /// Interface for the spreadsheet model. Concrete classes must implement INotifyPropertyChanged as well.
    /// </summary>
    public interface ISpreadsheetModel : INotifyPropertyChanged {

        /// <summary>
        /// The spreadsheet data. Holds all information about cells and their contents.
        /// </summary>
        Spreadsheet Sheet { get; }

        /// <summary>
        /// The path that the spreadsheet is stored.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Represents whether the current theme is dark or not.
        /// </summary>
        bool DarkMode { get; set; }

        /// <summary>
        /// Represents whether the current spreadsheet is connected to a server.
        /// </summary>
        bool Connected { get; set; }

        /// <summary>
        /// Represents whether an "edit" message should be sent.
        /// </summary>
        bool SendChanges { get; set; }

        /// <summary>
        /// The currently selected cell.
        /// </summary>
        Cell Current { get; set; }

        /// <summary>
        /// The previously selected cell.
        /// </summary>
        Cell Previous { get; set; }

        /// <summary>
        /// Gets the values associated with the given cells.
        /// </summary>
        /// <param name="cells">The cells to lookup. If null then it will look at all
        /// cells with values in the spreadshet.</param>
        /// <returns></returns>
        List<Tuple<Point, string>> GetCellValues(IEnumerable<string> cells);

        /// <summary>
        /// Changes the current cell and evaluates any modifications to the prevous cell.
        /// If there are modifications then they are handled with all direct and indirect
        /// dependents of the modified cell.
        /// </summary>
        /// <param name="newCol">The next cell's column coordinate</param>
        /// <param name="newRow">The next cell's row coordinate.</param>
        /// <param name="notifyError">An outside action to trigger if an error happens.</param>
        /// <returns>List of cells with newly evaluated values.</returns>
        List<Tuple<Point, string>> ChangeCurrentCell(int newCol, int newRow, Action<Exception> notifyError);

        /// <summary>
        /// Safely updates the contents of the cell.
        /// </summary>
        /// <param name="cell">The cell to update.</param>
        /// <param name="notifyError">An outside action to trigger if an error happens.</param>
        /// <returns>List of cells that were affected by the contents being changed of the particular cell.</returns>
        List<Tuple<Point, string>> UpdateCellContents(Cell cell, Action<Exception> notifyError);

        IEnumerable<string> GetDirectDependents(string cell);
    }
}
