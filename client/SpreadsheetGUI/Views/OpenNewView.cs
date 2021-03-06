﻿/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : CS3505 Final                                                 *
 *                                                                                             *
 *                        File  : Views/OpenNewView.cs                                         *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 03/28/19                                                     *
 *                                                                                             *
 *                      Modtime : 04/21/19                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using SS.Models;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;

namespace SS.Views {

    /// <summary>
    /// Represents the Open/New view.
    /// </summary>
    public partial class OpenNewView : Form {

        private const char KEY_ENTER = (char)0xD;

        public event EventHandler OpenClicked;

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
        /// The name of the spreadsheet to open/create.
        /// </summary>
        public string Spreadsheet {
            get { return spreadsheetBox.Text; }
            set { spreadsheetBox.Text = value; }
        }

        public List<string> SpreadsheetList {
            get {
                List<string> items = new List<string>();
                foreach (string e in spreadsheetList.Items) {
                    items.Add(e);
                }
                return items;
            }
            set {
                spreadsheetList.Items.Clear();
                foreach (string e in value) {
                    spreadsheetList.Items.Add(e);
                }
            }
        }

        /// <summary>
        /// Basic constructor.
        /// </summary>
        /// <param name="mode">Determines whether the theme is set to dark mode.</param>
        public OpenNewView(bool mode) {
            InitializeComponent();
            DarkMode(mode);

            openNewBtn.Click += (o, e) => OpenClicked?.Invoke(o, e);
            spreadsheetList.MouseDoubleClick += OnListDoubleClick;

            this.KeyPress += OnMainWindowKeyPress;
            usernameBox.KeyPress += OnMainWindowKeyPress;
            passwordBox.KeyPress += OnMainWindowKeyPress;
            spreadsheetBox.KeyPress += OnMainWindowKeyPress;
            spreadsheetList.KeyPress += OnMainWindowKeyPress;
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
            spreadsheetBox.Enabled = enable;
            openNewBtn.Enabled = enable;
        }

        /// <summary>
        /// Helper method that updates the text colors of the view.
        /// </summary>
        /// <param name="c">The new text color.</param>
        private void ChangeTextColors(Color c) {
            authLbl.ForeColor = c;
            usernameLbl.ForeColor = c;
            passwordLbl.ForeColor = c;
            spreadsheetLbl.ForeColor = c;
        }

        /// <summary>
        /// Helper method that updates the button colors of the view.
        /// </summary>
        /// <param name="bg">The new background color.</param>
        /// <param name="fg">The new foreground color.</param>
        /// <param name="outline">The new outline color.</param>
        private void ChangeButtonColors(Color bg, Color fg, Color outline) {
            openNewBtn.BackColor = bg;
            openNewBtn.ForeColor = fg;
            openNewBtn.FlatAppearance.BorderColor = outline;
        }

        /// <summary>
        /// Helper method that updates the textbox colors of the view.
        /// </summary>
        /// <param name="bg">The new background color.</param>
        /// <param name="fg">The new foreground color.</param>
        private void ChangeTextBoxColors(Color bg, Color fg) {
            usernameBox.BackColor = bg;
            passwordBox.BackColor = bg;
            spreadsheetBox.BackColor = bg;
            usernameBox.ForeColor = fg;
            passwordBox.ForeColor = fg;
            spreadsheetBox.ForeColor = fg;

            spreadsheetList.BackColor = bg;
            spreadsheetList.ForeColor = fg;
        }

        private void OnMainWindowKeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == KEY_ENTER) {
                OpenClicked?.Invoke(sender, e);
                e.Handled = true;
            }
        }

        private void OnListDoubleClick(object sender, EventArgs e) {
            var s = sender as System.Windows.Forms.ListBox;
            if (s != null) {
                spreadsheetBox.Text = s.Text;
                OpenClicked?.Invoke(sender, e);
            }
        }

        /// <summary>
        /// Action method when a user selects an object in the spreadsheet listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spreadsheetList_SelectedValueChanged(object sender, EventArgs e) {
            var s = sender as System.Windows.Forms.ListBox;
            if (s != null) {
                spreadsheetBox.Text = s.Text;
            }
        }
    }
}
