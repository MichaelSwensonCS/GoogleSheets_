namespace SS.Views {
    partial class HelpNavView {
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
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.tabEnterNavGif = new System.Windows.Forms.PictureBox();
            this.arrowKeysNavGif = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tabEnterNavGif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowKeysNavGif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(12, 9);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(431, 22);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Navigation of cells can be done in one of three ways:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(44, 54);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(137, 20);
            this.lbl2.TabIndex = 1;
            this.lbl2.Text = "By the arrow keys:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(488, 54);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(186, 20);
            this.lbl3.TabIndex = 2;
            this.lbl3.Text = "By the Tab or Enter keys:";
            // 
            // lbl4
            // 
            this.lbl4.Location = new System.Drawing.Point(48, 315);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(850, 40);
            this.lbl4.TabIndex = 3;
            this.lbl4.Text = "Note: Whatever has been enetered in a cell will be evaluated after leaving that c" +
    "ell.";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(930, 54);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(196, 20);
            this.lbl5.TabIndex = 4;
            this.lbl5.Text = "By clicking the desired cell:";
            // 
            // okBtn
            // 
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Location = new System.Drawing.Point(48, 368);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(1292, 42);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // tabEnterNavGif
            // 
            this.tabEnterNavGif.Image = global::SS.Properties.Resources.enterTabNavigation;
            this.tabEnterNavGif.Location = new System.Drawing.Point(490, 88);
            this.tabEnterNavGif.Name = "tabEnterNavGif";
            this.tabEnterNavGif.Size = new System.Drawing.Size(408, 215);
            this.tabEnterNavGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.tabEnterNavGif.TabIndex = 7;
            this.tabEnterNavGif.TabStop = false;
            // 
            // arrowKeysNavGif
            // 
            this.arrowKeysNavGif.Image = global::SS.Properties.Resources.arrowsNavigation;
            this.arrowKeysNavGif.Location = new System.Drawing.Point(48, 88);
            this.arrowKeysNavGif.Name = "arrowKeysNavGif";
            this.arrowKeysNavGif.Size = new System.Drawing.Size(408, 215);
            this.arrowKeysNavGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.arrowKeysNavGif.TabIndex = 6;
            this.arrowKeysNavGif.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SS.Properties.Resources.mouseNavigation;
            this.pictureBox1.Location = new System.Drawing.Point(932, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(408, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // HelpNavView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 420);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabEnterNavGif);
            this.Controls.Add(this.arrowKeysNavGif);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpNavView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Navigating Cells";
            ((System.ComponentModel.ISupportInitialize)(this.tabEnterNavGif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowKeysNavGif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.PictureBox arrowKeysNavGif;
        private System.Windows.Forms.PictureBox tabEnterNavGif;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}