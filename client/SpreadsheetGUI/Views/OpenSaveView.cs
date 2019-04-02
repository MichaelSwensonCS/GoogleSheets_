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
 *                      Modtime : 04/02/19                                                     *
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
    /// Represents the Open/Save view.
    /// </summary>
    public partial class OpenSaveView : Form {

        public event EventHandler OpenClicked;
        public event EventHandler NewClicked;

        /// <summary>
        /// The user to use to connect to a server.
        /// </summary>
        public string Username {
            get { return usernameBox.Text; }
            set { usernameBox.Text = value; }
        }

        /// <summary>
        /// The password for a given user.
        /// </summary>
        public string Password {
            get { return passwordBox.Text; }
            set { passwordBox.Text = value; }
        }

        /// <summary>
        /// The address of the server to connect to.
        /// </summary>
        public string Server {
            get { return serverBox.Text; }
            set { serverBox.Text = value; }
        }

        /// <summary>
        /// Basic constructor.
        /// </summary>
        /// <param name="mode">Determines whether the theme is set to dark mode.</param>
        public OpenSaveView(bool mode) {
            InitializeComponent();
            DarkMode(mode);

            openBtn.Click += (o, e) => OpenClicked?.Invoke(o, e);
            newBtn.Click += (o, e) => NewClicked?.Invoke(o, e);
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
            usernameBox.Enabled = enable;
            passwordBox.Enabled = enable;
            serverBox.Enabled = enable;
            openBtn.Enabled = enable;
            newBtn.Enabled = enable;
        }

        /// <summary>
        /// Helper method that updates the text colors of the view.
        /// </summary>
        /// <param name="c">The new text color.</param>
        private void ChangeTextColors(Color c) {
            authLbl.ForeColor = c;
            usernameLbl.ForeColor = c;
            passwordLbl.ForeColor = c;
            serverLbl.ForeColor = c;
        }

        /// <summary>
        /// Helper method that updates the button colors of the view.
        /// </summary>
        /// <param name="bg">The new background color.</param>
        /// <param name="fg">The new foreground color.</param>
        /// <param name="outline">The new outline color.</param>
        private void ChangeButtonColors(Color bg, Color fg, Color outline) {
            openBtn.BackColor = bg;
            openBtn.ForeColor = fg;
            openBtn.FlatAppearance.BorderColor = outline;
            newBtn.BackColor = bg;
            newBtn.ForeColor = fg;
            newBtn.FlatAppearance.BorderColor = outline;
        }

        /// <summary>
        /// Helper method that updates the textbox colors of the view.
        /// </summary>
        /// <param name="bg">The new background color.</param>
        /// <param name="fg">The new foreground color.</param>
        private void ChangeTextBoxColors(Color bg, Color fg) {
            usernameBox.BackColor = bg;
            passwordBox.BackColor = bg;
            serverBox.BackColor = bg;
            usernameBox.ForeColor = fg;
            passwordBox.ForeColor = fg;
            serverBox.ForeColor = fg;
        }
    }
}
