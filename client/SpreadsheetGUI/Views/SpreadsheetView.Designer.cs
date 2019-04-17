namespace SS {
    partial class SpreadsheetView {
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.undoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revertMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.darkModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.navMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changingCellsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.featuresMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formulaBox = new System.Windows.Forms.TextBox();
            this.fxLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.valueBox = new System.Windows.Forms.TextBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spreadsheetPanel = new SS.SpreadsheetPanel();
            this.menuStrip.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.viewMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1002, 33);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.closeMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(50, 29);
            this.fileMenu.Text = "File";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(182, 30);
            this.openMenuItem.Text = "New/Open";
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(182, 30);
            this.closeMenuItem.Text = "Close";
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoMenuItem,
            this.revertMenuItem});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(54, 29);
            this.editMenu.Text = "Edit";
            // 
            // undoMenuItem
            // 
            this.undoMenuItem.Name = "undoMenuItem";
            this.undoMenuItem.Size = new System.Drawing.Size(252, 30);
            this.undoMenuItem.Text = "Undo";
            // 
            // revertMenuItem
            // 
            this.revertMenuItem.Name = "revertMenuItem";
            this.revertMenuItem.Size = new System.Drawing.Size(252, 30);
            this.revertMenuItem.Text = "Revert";
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.darkModeMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(61, 29);
            this.viewMenu.Text = "View";
            // 
            // darkModeMenuItem
            // 
            this.darkModeMenuItem.Name = "darkModeMenuItem";
            this.darkModeMenuItem.Size = new System.Drawing.Size(185, 30);
            this.darkModeMenuItem.Text = "Dark Mode";
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.navMenuItem,
            this.changingCellsMenuItem,
            this.featuresMenuItem,
            this.toolStripSeparator3,
            this.aboutMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(61, 29);
            this.helpMenu.Text = "Help";
            // 
            // navMenuItem
            // 
            this.navMenuItem.Name = "navMenuItem";
            this.navMenuItem.Size = new System.Drawing.Size(281, 30);
            this.navMenuItem.Text = "Navigating Cells";
            // 
            // changingCellsMenuItem
            // 
            this.changingCellsMenuItem.Name = "changingCellsMenuItem";
            this.changingCellsMenuItem.Size = new System.Drawing.Size(281, 30);
            this.changingCellsMenuItem.Text = "Changing Cell Contents";
            // 
            // featuresMenuItem
            // 
            this.featuresMenuItem.Name = "featuresMenuItem";
            this.featuresMenuItem.Size = new System.Drawing.Size(281, 30);
            this.featuresMenuItem.Text = "Additional Features";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(278, 6);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(281, 30);
            this.aboutMenuItem.Text = "About";
            // 
            // formulaBox
            // 
            this.formulaBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formulaBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formulaBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formulaBox.Location = new System.Drawing.Point(216, 85);
            this.formulaBox.Name = "formulaBox";
            this.formulaBox.Size = new System.Drawing.Size(786, 30);
            this.formulaBox.TabIndex = 2;
            // 
            // fxLabel
            // 
            this.fxLabel.BackColor = System.Drawing.SystemColors.Window;
            this.fxLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fxLabel.Location = new System.Drawing.Point(180, 85);
            this.fxLabel.Name = "fxLabel";
            this.fxLabel.Size = new System.Drawing.Size(36, 34);
            this.fxLabel.TabIndex = 5;
            this.fxLabel.Text = "Fx";
            // 
            // nameLabel
            // 
            this.nameLabel.BackColor = System.Drawing.SystemColors.Window;
            this.nameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(0, 85);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(70, 34);
            this.nameLabel.TabIndex = 6;
            // 
            // valueBox
            // 
            this.valueBox.BackColor = System.Drawing.SystemColors.Window;
            this.valueBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.valueBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueBox.Location = new System.Drawing.Point(69, 85);
            this.valueBox.Name = "valueBox";
            this.valueBox.ReadOnly = true;
            this.valueBox.Size = new System.Drawing.Size(90, 30);
            this.valueBox.TabIndex = 7;
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.reverToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(127, 94);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(126, 30);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // reverToolStripMenuItem
            // 
            this.reverToolStripMenuItem.Name = "reverToolStripMenuItem";
            this.reverToolStripMenuItem.Size = new System.Drawing.Size(126, 30);
            this.reverToolStripMenuItem.Text = "Revert";
            // 
            // spreadsheetPanel
            // 
            this.spreadsheetPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spreadsheetPanel.ContextMenuStrip = this.contextMenu;
            this.spreadsheetPanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.spreadsheetPanel.Location = new System.Drawing.Point(0, 120);
            this.spreadsheetPanel.Name = "spreadsheetPanel";
            this.spreadsheetPanel.Size = new System.Drawing.Size(1002, 398);
            this.spreadsheetPanel.TabIndex = 3;
            // 
            // SpreadsheetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1002, 520);
            this.Controls.Add(this.valueBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.fxLabel);
            this.Controls.Add(this.spreadsheetPanel);
            this.Controls.Add(this.formulaBox);
            this.Controls.Add(this.menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "SpreadsheetView";
            this.Text = "Form1";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.TextBox formulaBox;
        private SpreadsheetPanel spreadsheetPanel;
        private System.Windows.Forms.Label fxLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox valueBox;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changingCellsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revertMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkModeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem featuresMenuItem;
    }
}

