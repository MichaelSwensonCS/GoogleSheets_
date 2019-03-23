namespace SS.Views {
    partial class HelpAdditionalFeatures {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpAdditionalFeatures));
            this.okBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.BackColor = System.Drawing.SystemColors.Control;
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Location = new System.Drawing.Point(7, 306);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(644, 42);
            this.okBtn.TabIndex = 6;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(638, 294);
            this.label1.TabIndex = 5;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // HelpAdditionalFeatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 359);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpAdditionalFeatures";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Additional Features";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
    }
}