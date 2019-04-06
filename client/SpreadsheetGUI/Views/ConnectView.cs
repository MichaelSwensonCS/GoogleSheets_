/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final                                                 *
 *                                                                                             *
 *                        File  : Views/ConnectView.cs                                         *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 04/06/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/06/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using SS.Models;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace SS.Views {

    /// <summary>
    /// Represents the Connect view.
    /// </summary>
    public partial class ConnectView : Form {

        public event EventHandler ConnectClicked;

        public string Server {
            get { return serverBox.Text; }
            set { serverBox.Text = value; }
        }

        /// <summary>
        /// Basic constructor.
        /// </summary>
        /// <param name="mode">Determines whether the theme is set to dark mode.</param>
        public ConnectView(bool mode) {
            InitializeComponent();
            DarkMode(mode);

            connectBtn.Click += (o, e) => ConnectClicked?.Invoke(o, e);
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
                ChangeTextBoxColors(DialogColors.ColorMidAlt, DialogColors.ColorHiAlt);
            }
            else {
                BackColor = Color.FromArgb(255, 255, 255);
                ChangeTextColors(Color.Black);
                ChangeButtonColors(Color.FromArgb(240, 240, 240), Color.Black, Color.FromArgb(43, 142, 221));
                ChangeTextBoxColors(Color.White, Color.Black);
            }
        }

        /// <summary>
        /// Allows the view's inputs to be enabled/disabled.
        /// </summary>
        /// <param name="enable">Flag that enables inputs if true and disables inputs if false.</param>
        public void ToggleInputs(bool enable) {
            serverBox.Enabled = enable;
            connectBtn.Enabled = enable;
        }

        /// <summary>
        /// Helper method that updates the text colors of the view.
        /// </summary>
        /// <param name="c">The new text color.</param>
        private void ChangeTextColors(Color c) {
            serverLbl.ForeColor = c;
        }

        /// <summary>
        /// Helper method that updates the button colors of the view.
        /// </summary>
        /// <param name="bg">The new background color.</param>
        /// <param name="fg">The new foreground color.</param>
        /// <param name="outline">The new outline color.</param>
        private void ChangeButtonColors(Color bg, Color fg, Color outline) {
            connectBtn.BackColor = bg;
            connectBtn.ForeColor = fg;
            connectBtn.FlatAppearance.BorderColor = outline;
        }

        /// <summary>
        /// Helper method that updates the textbox colors of the view.
        /// </summary>
        /// <param name="bg">The new background color.</param>
        /// <param name="fg">The new foreground color.</param>
        private void ChangeTextBoxColors(Color bg, Color fg) {
            serverBox.BackColor = bg;
            serverBox.ForeColor = fg;
        }
    }
}
