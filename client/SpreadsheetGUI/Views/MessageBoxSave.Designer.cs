namespace SS.Views {
    partial class MessageBoxSave {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveBtn = new System.Windows.Forms.Button();
            this.dontSaveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.saveBtn);
            this.panel1.Controls.Add(this.dontSaveBtn);
            this.panel1.Controls.Add(this.cancelBtn);
            this.panel1.Location = new System.Drawing.Point(0, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 43);
            this.panel1.TabIndex = 0;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(146, 10);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // dontSaveBtn
            // 
            this.dontSaveBtn.Location = new System.Drawing.Point(227, 10);
            this.dontSaveBtn.Name = "dontSaveBtn";
            this.dontSaveBtn.Size = new System.Drawing.Size(80, 23);
            this.dontSaveBtn.TabIndex = 1;
            this.dontSaveBtn.Text = "Don\'t Save";
            this.dontSaveBtn.UseVisualStyleBackColor = true;
            this.dontSaveBtn.Click += new System.EventHandler(this.dontSaveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(313, 10);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(12, 18);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(226, 20);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Do you want to save changes?";
            // 
            // MessageBoxSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(400, 100);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageBoxSave";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Spreadsheet has been modified";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button dontSaveBtn;
        private System.Windows.Forms.Label lbl1;
    }
}