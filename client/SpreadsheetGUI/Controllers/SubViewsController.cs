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
 *                      Modtime : 10/15/18                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using SS.Views;
using System.Windows.Forms;

namespace SS.Controllers {

    /// <summary>
    /// Handles additional subviews that popup from the parent view.
    /// </summary>
    public class SubViewsController {
        private AboutView _about;
        private HelpNavView _helpNav;
        private HelpChangingCellsContentsView _helpCells;
        private HelpAdditionalFeatures _helpFeatures;
        private OpenSaveView _openSave;

        /// <summary>
        /// Basic constructor that will create all the subviews.
        /// </summary>
        public SubViewsController(bool mode) {
            _about = new AboutView(mode);
            _helpNav = new HelpNavView(mode);
            _helpCells = new HelpChangingCellsContentsView(mode);
            _helpFeatures = new HelpAdditionalFeatures(mode);
            _openSave = new OpenSaveView(mode);

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
        /// Show the "Open/Save" dialog.
        /// </summary>
        public void ShowOpenSaveView() {
            _openSave.ShowDialog();
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
            _openSave.DarkMode(mode);
        }
    }
}
