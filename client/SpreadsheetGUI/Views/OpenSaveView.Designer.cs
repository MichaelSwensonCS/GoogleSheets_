namespace SS.Views {
    partial class OpenSaveView {
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
            this.newBtn = new System.Windows.Forms.Button();
            this.openBtn = new System.Windows.Forms.Button();
            this.authLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(17, 68);
            this.usernameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(230, 26);
            this.usernameBox.TabIndex = 0;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(332, 68);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(230, 26);
            this.passwordBox.TabIndex = 1;
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.Location = new System.Drawing.Point(13, 43);
            this.usernameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(83, 20);
            this.usernameLbl.TabIndex = 2;
            this.usernameLbl.Text = "Username";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(328, 43);
            this.passwordLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(78, 20);
            this.passwordLbl.TabIndex = 3;
            this.passwordLbl.Text = "Password";
            // 
            // newBtn
            // 
            this.newBtn.Location = new System.Drawing.Point(458, 135);
            this.newBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(112, 35);
            this.newBtn.TabIndex = 4;
            this.newBtn.Text = "New";
            this.newBtn.UseVisualStyleBackColor = true;
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(332, 135);
            this.openBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(112, 35);
            this.openBtn.TabIndex = 5;
            this.openBtn.Text = "Open";
            this.openBtn.UseVisualStyleBackColor = true;
            // 
            // authLbl
            // 
            this.authLbl.AutoSize = true;
            this.authLbl.Location = new System.Drawing.Point(12, 9);
            this.authLbl.Name = "authLbl";
            this.authLbl.Size = new System.Drawing.Size(558, 20);
            this.authLbl.TabIndex = 6;
            this.authLbl.Text = "A username and password must be provided to open or create a spreadsheet.";
            // 
            // OpenSaveView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 186);
            this.Controls.Add(this.authLbl);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.newBtn);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.usernameLbl);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenSaveView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open/Save Spreadsheet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label usernameLbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Label authLbl;
    }
}