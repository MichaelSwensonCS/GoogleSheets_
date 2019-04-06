namespace SS.Views {
    partial class OpenNewView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.usernameLbl = new System.Windows.Forms.Label();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.openNewBtn = new System.Windows.Forms.Button();
            this.authLbl = new System.Windows.Forms.Label();
            this.spreadsheetLbl = new System.Windows.Forms.Label();
            this.spreadsheetBox = new System.Windows.Forms.TextBox();
            this.spreadsheetList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // usernameBox
            // 
            this.usernameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameBox.Location = new System.Drawing.Point(17, 68);
            this.usernameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(238, 26);
            this.usernameBox.TabIndex = 0;
            // 
            // passwordBox
            // 
            this.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordBox.Location = new System.Drawing.Point(332, 68);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(238, 26);
            this.passwordBox.TabIndex = 1;
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.Location = new System.Drawing.Point(13, 43);
            this.usernameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(83, 20);
            this.usernameLbl.TabIndex = 51;
            this.usernameLbl.Text = "Username";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(328, 43);
            this.passwordLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(78, 20);
            this.passwordLbl.TabIndex = 52;
            this.passwordLbl.Text = "Password";
            // 
            // openNewBtn
            // 
            this.openNewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openNewBtn.Location = new System.Drawing.Point(434, 528);
            this.openNewBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openNewBtn.Name = "openNewBtn";
            this.openNewBtn.Size = new System.Drawing.Size(136, 35);
            this.openNewBtn.TabIndex = 4;
            this.openNewBtn.Text = "Open / New";
            this.openNewBtn.UseVisualStyleBackColor = true;
            // 
            // authLbl
            // 
            this.authLbl.AutoSize = true;
            this.authLbl.Location = new System.Drawing.Point(12, 9);
            this.authLbl.Name = "authLbl";
            this.authLbl.Size = new System.Drawing.Size(558, 20);
            this.authLbl.TabIndex = 50;
            this.authLbl.Text = "A username and password must be provided to open or create a spreadsheet.";
            // 
            // spreadsheetLbl
            // 
            this.spreadsheetLbl.AutoSize = true;
            this.spreadsheetLbl.Location = new System.Drawing.Point(13, 101);
            this.spreadsheetLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.spreadsheetLbl.Name = "spreadsheetLbl";
            this.spreadsheetLbl.Size = new System.Drawing.Size(101, 20);
            this.spreadsheetLbl.TabIndex = 53;
            this.spreadsheetLbl.Text = "Spreadsheet";
            // 
            // spreadsheetBox
            // 
            this.spreadsheetBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spreadsheetBox.Location = new System.Drawing.Point(17, 126);
            this.spreadsheetBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.spreadsheetBox.Name = "spreadsheetBox";
            this.spreadsheetBox.Size = new System.Drawing.Size(553, 26);
            this.spreadsheetBox.TabIndex = 2;
            // 
            // spreadsheetList
            // 
            this.spreadsheetList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.spreadsheetList.FormattingEnabled = true;
            this.spreadsheetList.ItemHeight = 20;
            this.spreadsheetList.Location = new System.Drawing.Point(17, 170);
            this.spreadsheetList.Name = "spreadsheetList";
            this.spreadsheetList.Size = new System.Drawing.Size(553, 342);
            this.spreadsheetList.TabIndex = 3;
            // 
            // OpenNewView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 577);
            this.Controls.Add(this.spreadsheetList);
            this.Controls.Add(this.spreadsheetLbl);
            this.Controls.Add(this.spreadsheetBox);
            this.Controls.Add(this.authLbl);
            this.Controls.Add(this.openNewBtn);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.usernameLbl);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenNewView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open/New Spreadsheet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label usernameLbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Button openNewBtn;
        private System.Windows.Forms.Label authLbl;
        private System.Windows.Forms.Label spreadsheetLbl;
        private System.Windows.Forms.TextBox spreadsheetBox;
        private System.Windows.Forms.ListBox spreadsheetList;
    }
}