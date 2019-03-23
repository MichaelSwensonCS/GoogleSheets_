namespace SS.Views {
    partial class AboutView {

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
            this.ps6Label = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.aboutText = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ps6Label
            // 
            this.ps6Label.AutoSize = true;
            this.ps6Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ps6Label.Location = new System.Drawing.Point(18, 19);
            this.ps6Label.Name = "ps6Label";
            this.ps6Label.Size = new System.Drawing.Size(85, 40);
            this.ps6Label.TabIndex = 0;
            this.ps6Label.Text = "PS6";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(25, 62);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(46, 20);
            this.versionLabel.TabIndex = 1;
            this.versionLabel.Text = "V 1.0";
            // 
            // aboutText
            // 
            this.aboutText.AutoSize = true;
            this.aboutText.Location = new System.Drawing.Point(25, 112);
            this.aboutText.Name = "aboutText";
            this.aboutText.Size = new System.Drawing.Size(279, 20);
            this.aboutText.TabIndex = 2;
            this.aboutText.Text = "By Josh Perkins for CS3500, Fall 2018";
            // 
            // okBtn
            // 
            this.okBtn.BackColor = System.Drawing.SystemColors.Control;
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Location = new System.Drawing.Point(25, 151);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(752, 42);
            this.okBtn.TabIndex = 3;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // AboutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 205);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.aboutText);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.ps6Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ps6Label;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label aboutText;
        private System.Windows.Forms.Button okBtn;
    }
}