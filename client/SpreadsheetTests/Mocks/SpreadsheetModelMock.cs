/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Mocks/SpreadsheetModelMock.cs                                *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/14/18                                                     *
 *                                                                                             *
 *                      Modtime : 10/15/18                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using SpreadsheetUtilities;
using SS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace SS.Mocks {

    /// <summary>
    /// Attempts to create a mock class for the SpreadsheetModel class.
    /// </summary>
    class SpreadsheetModelMock : ISpreadsheetModel {

        /// <summary>
        /// A struct for shortening the parameter list that is passed to the constructor.
        /// </summary>
        public struct InitialConditions {
            public Spreadsheet sheet;
            public Cell current;
            public Cell previous;
            public bool pendingSave;
            public string path;

            /// <summary>
            /// Basic constructor.
            /// </summary>
            /// <param name="sheet">The spreadsheet to use.</param>
            /// <param name="current">The current cell to use.</param>
            /// <param name="previous">The previous cell to use.</param>
            /// <param name="pendingSave">The save state to set the spreadsheet in.</param>
            /// <param name="path">The path to use.</param>
            public InitialConditions(Spreadsheet sheet, Cell current, Cell previous, bool pendingSave, string path) {
                this.sheet = sheet;
                this.current = current;
                this.previous = previous;
                this.pendingSave = pendingSave;
                this.path = path;
            }
        }

        /// <summary>
        /// The spreadsheet data. Holds all information about cells and their contents.
        /// </summary>
        public Spreadsheet Sheet { get; }

        /// <summary>
        /// The path that the spreadsheet is stored.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Represents whether the spreadsheet has been modified and needs to be saved.
        /// </summary>
        public bool PendingSave { get; }

        /// <summary>
        /// Represents whether the current theme is dark or not.
        /// </summary>
        public bool DarkMode { get; set; }

        /// <summary>
        /// The currently selected cell.
        /// </summary>
        public Cell Current { get; set; }

        /// <summary>
        /// The previously selected cell.
        /// </summary>
        public Cell Previous { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Basic constructor.
        /// </summary>
        /// <param name="init">The initial parameters struct to use.</param>
        public SpreadsheetModelMock(InitialConditions init) {
            Sheet = init.sheet;

            Current = init.current;
            Previous = init.previous;

            PendingSave = init.pendingSave;
            FilePath = init.path;
        }

        /// <summary>
        /// Changes the current cell and evaluates any modifications to the prevous cell.
        /// If there are modifications then they are handled with all direct and indirect
        /// dependents of the modified cell.
        /// </summary>
        /// <param name="newCol">The next cell's column coordinate</param>
        /// <param name="newRow">The next cell's row coordinate.</param>
        /// <param name="notifyError">An outside action to trigger if an error happens.</param>
        /// <returns>List of cells with newly evaluated values.</returns>
        public List<Tuple<Point, string>> ChangeCurrentCell(int newCol, int newRow, Action<Exception> notifyError) {
            List<Tuple<Point, string>> output = new List<Tuple<Point, string>>();

            Previous = Current;

            try {
                ISet<string> cellsToCalc = Sheet.SetContentsOfCell(Previous.Name, Previous.Contents);
                foreach (string cell in cellsToCalc) {
                    output.Add(new Tuple<Point, string>(new Point(newCol, newRow), Sheet.GetCellValue(cell).ToString()));
                }
            }
            catch (CircularException e) {
                notifyError(e);
            }
            catch (FormulaFormatException e) {
                notifyError(e);
            }

            string name = Cell.CoordsToName(newCol, newRow);
            Current = new Cell(name, newCol, newRow);
            Current.Contents = Sheet.GetCellContents(name).ToString();

            return output;
        }

        /// <summary>
        /// Gets the values associated with the given cells.
        /// </summary>
        /// <param name="cells">The cells to lookup. If null then it will look at all
        /// cells with values in the spreadshet.</param>
        /// <returns></returns>
        public List<Tuple<Point, string>> GetCellValues(IEnumerable<string> cells) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Method for saving the spreadsheet.
        /// </summary>
        /// <param name="notifyError">An outside action to trigger if an error happens.</param>
        /// <returns>True if the save succeeded, false otherwise.</returns>
        public bool SaveSheet(Action<Exception> notifyError) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Safely updates the contents of the cell.
        /// </summary>
        /// <param name="cell">The cell to update.</param>
        /// <param name="notifyError">An outside action to trigger if an error happens.</param>
        /// <returns>List of cells that were affected by the contents being changed of the particular cell.</returns>
        public List<Tuple<Point, string>> UpdateCellContents(Cell cell, Action<Exception> notifyError) {
            throw new NotImplementedException();
        }
    }
}
