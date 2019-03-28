/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final                                                 *
 *                                                                                             *
 *                        File  : Views/OpenSaveView.cs                                        *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 03/28/19                                                     *
 *                                                                                             *
 *                      Modtime : 03/28/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using SS.Models;
using System.Windows.Forms;
using System.Drawing;

namespace SS.Views {

    /// <summary>
    /// Represents the Open/Save view.
    /// </summary>
    public partial class OpenSaveView : Form {

        /// <summary>
        /// Basic constructor.
        /// </summary>
        /// <param name="mode">Determines whether the theme is set to dark mode.</param>
        public OpenSaveView(bool mode) {
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
            usernameLbl.ForeColor = c;
            passwordLbl.ForeColor = c;
        }

        /// <summary>
        /// Helper method that updates the button colors of the view.
        /// </summary>
        /// <param name="bg">The new background color.</param>
        /// <param name="fg">The new foreground color.</param>
        /// <param name="outline">The new outline color.</param>
        private void ChangeButtonColors(Color bg, Color fg, Color outline) {
            //okBtn.BackColor = bg;
            //okBtn.ForeColor = fg;
            //okBtn.FlatAppearance.BorderColor = outline;
        }
    }
}
