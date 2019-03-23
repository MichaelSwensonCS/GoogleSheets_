/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Views/MessageBoxSave.cs                                      *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/15/18                                                     *
 *                                                                                             *
 *                      Modtime : 10/15/18                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using System;
using System.Windows.Forms;

namespace SS.Views {
    public partial class MessageBoxSave : Form {
        public MessageBoxSave() {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e) {
            SetAndClose(DialogResult.Yes);
        }

        private void dontSaveBtn_Click(object sender, EventArgs e) {
            SetAndClose(DialogResult.No);
        }

        private void cancelBtn_Click(object sender, EventArgs e) {
            SetAndClose(DialogResult.Cancel);
        }

        private void SetAndClose(DialogResult result) {
            DialogResult = result;
            Close();
        }
    }
}
