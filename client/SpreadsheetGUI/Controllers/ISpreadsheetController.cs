/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Controllers/ISpreadsheetController.cs                        *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/13/18                                                     *
 *                                                                                             *
 *                      Modtime : 10/15/18                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */


using SS.Models;

namespace SS.Controllers {

    /// <summary>
    /// Interface for the spreadsheet controller.
    /// </summary>
    public interface ISpreadsheetController {

        /// <summary>
        /// Triggers when the controller commits to closing.
        /// </summary>
        event ClosingHandler ClosingInitiated;

        /// <summary>
        /// The path associated with the controller.
        /// </summary>
        string ModelPath { get; }

        /// <summary>
        /// Loads a model into the controller.
        /// </summary>
        /// <param name="model">The model to load.</param>
        void LoadModel(ISpreadsheetModel model);

        void LoadModelThreaded(ISpreadsheetModel model);
    }
}
