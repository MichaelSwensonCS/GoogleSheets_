/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Views/HelpChangingCellsContentsView.cs                       *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/09/18                                                     *
 *                                                                                             *
 *                      Modtime : 10/14/18                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using SS.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SS.Views {

    /// <summary>
    /// Respresents a help window that explains changing the contents of a cell.
    /// </summary>
    public partial class HelpChangingCellsContentsView : Form {

        /// <summary>
        /// Basic constructor.
        /// </summary>
        /// <param name="mode">Determines whether the theme is set to dark mode.</param>
        public HelpChangingCellsContentsView(bool mode) {
            InitializeComponent();
            DarkMode(mode);
        }

        /// <summary>
        /// Switches the theme of this view to or from dark mode.
        /// </summary>
        /// <param name="mode">Enable or disable dark mode.</param>
        public void DarkMode(bool mode) {
            if (mode) {
                BackColor = DialogColors.ColorLowAlt;
                ChangeTextColors(DialogColors.ColorHiAlt);
                ChangeButtonColors(DialogColors.ColorLowAlt, DialogColors.ColorHiAlt, DialogColors.ColorMidAlt);
            }
            else {
                BackColor = Color.FromArgb(255, 255, 255);
                ChangeTextColors(Color.Black);
                ChangeButtonColors(Color.FromArgb(240, 240, 240), Color.Black, Color.FromArgb(43, 142, 221));
            }
        }

        /// <summary>
        /// Helper method that updates the text colors of the view.
        /// </summary>
        /// <param name="c">The new text color.</param>
        private void ChangeTextColors(Color c) {
            label1.ForeColor = c;
        }

        /// <summary>
        /// Helper method that updates the button colors of the view.
        /// </summary>
        /// <param name="bg">The new background color.</param>
        /// <param name="fg">The new foreground color.</param>
        /// <param name="outline">The new outline color.</param>
        private void ChangeButtonColors(Color bg, Color fg, Color outline) {
            okBtn.BackColor = bg;
            okBtn.ForeColor = fg;
            okBtn.FlatAppearance.BorderColor = outline;
        }

        /// <summary>
        /// Handler for the "Ok" button being clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okBtn_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
