/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Models/Cell.cs                                               *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/12/18                                                     *
 *                                                                                             *
 *                      Modtime : 10/13/18                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace SS.Models {

    /// <summary>
    /// Represents a cell object in the spreadsheet. Used for keeping track only pertinent cells
    /// in a spreadsheet.
    /// </summary>
    public class Cell {
        private static readonly String ALPHA_PATTERN = @"[a-zA-Z]+";
        private static readonly String NUMBR_PATTERN = @"[0-9]+";
        private static readonly String VAR_PATTERN = String.Format("({0}) | ({1})", ALPHA_PATTERN, NUMBR_PATTERN);

        /// <summary>
        /// The name of the cell.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The coordinates of the cell.
        /// </summary>
        public Point Coords { get; set; }

        /// <summary>
        /// The contents of the cell.
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// The evaluated value of the cell.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The original contents of the cell, before modification.
        /// </summary>
        public string OriginalContents { get; set; }

        /// <summary>
        /// Whether or not the cell has been modified.
        /// </summary>
        public bool Modified { get; set; }

        /// <summary>
        /// Basic constructor for a cell that takes a cell name and its coordinates.
        /// </summary>
        /// <param name="name">The name of the cell.</param>
        /// <param name="col">The column coordinate.</param>
        /// <param name="row">The row coordinate.</param>
        public Cell(string name, int col, int row) {
            Name = name;
            Coords = new Point(col, row);
            Modified = false;
        }

        /// <summary>
        /// Helper method that converts coordinates into a cell name.
        /// </summary>
        /// <param name="col">The column coordinate.</param>
        /// <param name="row">The row coordinate.</param>
        /// <returns>Cell name</returns>
        public static string CoordsToName(int col, int row) {
            return $"{DecimalToBase26(col)}{row + 1}";
        }

        /// <summary>
        /// Internal helper method that converts a decimal number into a base 26
        /// representation with the letters A-Z. This method is recursive.
        /// </summary>
        /// <param name="number">The number to parse.</param>
        /// <returns>Base26 string representation of number.</returns>
        private static string DecimalToBase26(int number) {
            int quotient = number / 26;
            int remainder = number % 26;
            string left = quotient != 0 ? DecimalToBase26(quotient) : "";

            return $"{left}{(char)(65 + remainder)}";
        }

        /// <summary>
        /// Helper method that converts a cell name into coordinates.
        /// </summary>
        /// <param name="name">The name of the cell to parse.</param>
        /// <returns>2D Point</returns>
        public static Point NameToCoords(string name) {
            int col = 0;
            int row = 0;

            var matches = Regex.Matches(name, VAR_PATTERN, RegexOptions.IgnorePatternWhitespace);
            string[] results = matches.Cast<Match>().Select(m => m.Value).ToArray();

            foreach (char c in results[0]) {
                if (c >= 'A' && c <= 'Z') { col += c - 'A'; }
            }

            row = Int32.Parse(results[1]) - 1;

            return new Point(col, row);
        }
    }
}
