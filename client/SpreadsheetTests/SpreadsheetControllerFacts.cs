/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : SpreadsheetControllerFacts.cs                                *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/14/18                                                     *
 *                                                                                             *
 *                      Modtime : 10/14/18                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SS;
using SS.Mocks;
using SS.Models;
using System;
using static SS.Mocks.SpreadsheetModelMock;

namespace SpreadsheetTests {

    /// <summary>
    /// Tests for the SpreadsheetController class.
    /// </summary>
    [TestClass]
    public class SpreadsheetControllerFacts {

        /// <summary>
        /// Tests for interations between the controller and the model.
        /// </summary>
        [TestClass]
        public class ControllerToModelTests {

            /// <summary>
            /// Tests the ChangeCurrentCell method.
            /// </summary>
            [TestClass]
            public class ChangeCurrentCellMethod {

                /// <summary>
                /// Tests that a circular exception is thrown and the error action is performed.
                /// </summary>
                [TestMethod]
                public void ExpectsCircularErrorAction() {

                    // Initial properties for model.
                    Spreadsheet sheet = new Spreadsheet();
                    Cell current = new Cell("A1", 0, 0);
                    Cell previous = null;
                    string path = "Spreadsheet0";

                    // Setting the conditions so a circular exception will occur when
                    // the cell is changed.
                    current.Contents = "=A1";

                    // Check for verifying the error action was performed.
                    bool actionWasRun = false;

                    // The error action to perform.
                    Action<Exception> errorAction = new Action<Exception>(e => {
                        actionWasRun = true;
                        Assert.IsTrue(e is CircularException);
                    });

                    // Create the model.
                    InitialConditions init = new InitialConditions(sheet, current, previous, false, path);
                    SpreadsheetModelMock ss = new SpreadsheetModelMock(init);

                    // Verify
                    ss.ChangeCurrentCell(1, 1, errorAction );
                    Assert.IsTrue(actionWasRun);
                }
            }
        }
    }
}
