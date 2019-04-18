/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Models/SpreadsheetModel.cs                                   *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/12/18                                                     *
 *                                                                                             *
 *                      Modtime : 04/18/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using SpreadsheetUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;

namespace SS.Models {

    /// <summary>
    /// Represents the model of a spreadsheet. Keeps track of relevant data for a spreadsheet and
    /// its state.
    /// </summary>
    class SpreadsheetModel : ISpreadsheetModel {

        private string _version = "ps6";
        private string _initCellName = "A1";

        /// <summary>
        /// The spreadsheet data. Holds all information about cells and their contents.
        /// </summary>
        public Spreadsheet Sheet { get; }

        /// <summary>
        /// The path that the spreadsheet is stored.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents whether the current theme is dark or not.
        /// </summary>
        public bool DarkMode { get; set; }

        /// <summary>
        /// Represents whether the current spreadsheet is connected to a server.
        /// </summary>
        public bool Connected { get; set; }

        /// <summary>
        /// Represents whether an "edit" message should be sent.
        /// </summary>
        public bool SendChanges { get; set; }

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
        /// <param name="path">The path of the spreadsheet to load. If null or empty then it creates
        /// a new, empty spreadsheet.</param>
        public SpreadsheetModel(string path) {
            if (string.IsNullOrEmpty(path) || !Path.HasExtension(path)) {
                Sheet = new Spreadsheet(s => true, s => s.ToUpper(), _version);
            }
            else {
                Sheet = new Spreadsheet(path, s => true, s => s.ToUpper(), _version);
            }

            Name = path;
            LoadModel();
        }

        public SpreadsheetModel(string name, Dictionary<string, string> cells) {
            Sheet = new Spreadsheet(s => true, s => s.ToUpper(), _version);

            foreach (KeyValuePair<string, string> cell in cells) {
                Sheet.SetContentsOfCell(cell.Key, cell.Value);
            }

            Name = name;
            LoadModel();
        }

        /// <summary>
        /// Helper method to load the initial model.
        /// </summary>
        private void LoadModel() {
            Previous = null;

            Point coords = Cell.NameToCoords(_initCellName);
            object contents = Sheet.GetCellContents(_initCellName);

            Current = new Cell(_initCellName, coords.X, coords.Y);
            Current.Contents = ParseContents(contents);
        }

        /// <summary>
        /// Gets the values associated with the given cells.
        /// </summary>
        /// <param name="cells">The cells to lookup. If null then it will look at all
        /// cells with values in the spreadshet.</param>
        /// <returns></returns>
        public List<Tuple<Point, string>> GetCellValues(IEnumerable<string> cells) {
            List<Tuple<Point, string>> output = new List<Tuple<Point, string>>();

            if (cells == null) {
                cells = Sheet.GetNamesOfAllNonemptyCells();
            }

            Point p;
            string value;
            foreach (string name in cells) {
                p = Cell.NameToCoords(name);
                value = Sheet.GetCellValue(name).ToString();

                if (name == Current.Name) {
                    Current.Value = value;
                }

                output.Add(new Tuple<Point, string>(p, value));
            }

            return output;
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
            List<Tuple<Point, string>> cells = null;

            if (Current.Coords.X == newCol && Current.Coords.Y == newRow) {
                return cells;
            }
            else {
                Previous = Current;
                Current = new Cell(Cell.CoordsToName(newCol, newRow), newCol, newRow);
                Current.Contents = ParseContents(Sheet.GetCellContents(Current.Name));

                if (Previous.Modified) {
                    Previous.Modified = false;
                    cells = UpdateCellContents(Previous, notifyError);
                    SendChanges = true;
                }

                if (Current.Value == null) {
                    Current.Value = Sheet.GetCellValue(Current.Name).ToString();
                }

                return cells;
            }
        }

        /// <summary>
        /// Safely updates the contents of the cell.
        /// </summary>
        /// <param name="cell">The cell to update.</param>
        /// <param name="notifyError">An outside action to trigger if an error happens.</param>
        /// <returns>List of cells that were affected by the contents being changed of the particular cell.</returns>
        public List<Tuple<Point, string>> UpdateCellContents(Cell cell, Action<Exception> notifyError) {
            List<Tuple<Point, string>> cells = null;

            CalculateCellsToUpdate(cell, notifyError, out ISet<string> cellsToUpdate);
            if (cellsToUpdate != null) {
                cells = GetCellValues(cellsToUpdate);
            }

            return cells;
        }

        public IEnumerable<string> GetDirectDependents(string cell) {
            return Sheet.GetDirectDependents(cell);
        }

        /// <summary>
        /// Helper method to safely set the contents of a cell and get back the cells that need updating.
        /// </summary>
        /// <param name="cell">The cell to update.</param>
        /// <param name="notifyError">An outside action to trigger if an error happens.</param>
        /// <param name="cellsToUpdate">Output parameter of the cells that need to update.</param>
        private void CalculateCellsToUpdate(Cell cell, Action<Exception> notifyError, out ISet<string> cellsToUpdate) {
            cellsToUpdate = null;

            try {
                cellsToUpdate = Sheet.SetContentsOfCell(cell.Name, cell.Contents);
            }
            catch (CircularException e) {
                cell.Contents = cell.OriginalContents;
                notifyError(e);
            }
            catch (FormulaFormatException e) {
                cell.Contents = cell.OriginalContents;
                notifyError(e);
            }
        }

        /// <summary>
        /// Helper method that correctly formats a cell's contents to a string.
        /// </summary>
        /// <param name="contents">The contents of the cell.</param>
        /// <returns>Formatted string of the contents.</returns>
        private string ParseContents(object contents) {
            Formula f = contents as Formula;
            if (f != null) {
                return "=" + f.ToString();
            }
            else {
                return contents.ToString();
            }
        }

        /// <summary>
        /// Triggers the property change event.
        /// </summary>
        /// <param name="propertyName">The property that was changed.</param>
        private void NotifyPropertyChange([CallerMemberName] String propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
