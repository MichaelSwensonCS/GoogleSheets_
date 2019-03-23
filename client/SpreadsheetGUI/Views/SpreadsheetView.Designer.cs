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
            this.newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.autoSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.darkModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.navMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changingCellsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formulaBox = new System.Windows.Forms.TextBox();
            this.fxLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.valueBox = new System.Windows.Forms.TextBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spreadsheetPanel = new SS.SpreadsheetPanel();
            this.featuresMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.newMenuItem,
            this.openMenuItem,
            this.toolStripSeparator1,
            this.autoSaveMenuItem,
            this.toolStripSeparator4,
            this.saveMenuItem,
            this.saveAsMenuItem,
            this.toolStripSeparator2,
            this.closeMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(50, 29);
            this.fileMenu.Text = "File";
            // 
            // newMenuItem
            // 
            this.newMenuItem.Name = "newMenuItem";
            this.newMenuItem.Size = new System.Drawing.Size(229, 30);
            this.newMenuItem.Text = "New";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(229, 30);
            this.openMenuItem.Text = "Open";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(226, 6);
            // 
            // autoSaveMenuItem
            // 
            this.autoSaveMenuItem.Name = "autoSaveMenuItem";
            this.autoSaveMenuItem.Size = new System.Drawing.Size(229, 30);
            this.autoSaveMenuItem.Text = "Enable AutoSave";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(226, 6);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(229, 30);
            this.saveMenuItem.Text = "Save";
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.Size = new System.Drawing.Size(229, 30);
            this.saveAsMenuItem.Text = "Save As...";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(226, 6);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(229, 30);
            this.closeMenuItem.Text = "Close";
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutMenuItem,
            this.copyMenuItem,
            this.pasteMenuItem});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(54, 29);
            this.editMenu.Text = "Edit";
            // 
            // cutMenuItem
            // 
            this.cutMenuItem.Name = "cutMenuItem";
            this.cutMenuItem.Size = new System.Drawing.Size(138, 30);
            this.cutMenuItem.Text = "Cut";
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.Name = "copyMenuItem";
            this.copyMenuItem.Size = new System.Drawing.Size(138, 30);
            this.copyMenuItem.Text = "Copy";
            // 
            // pasteMenuItem
            // 
            this.pasteMenuItem.Name = "pasteMenuItem";
            this.pasteMenuItem.Size = new System.Drawing.Size(138, 30);
            this.pasteMenuItem.Text = "Paste";
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
            this.fxLabel.Size = new System.Drawing.Size(37, 35);
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
            this.nameLabel.Size = new System.Drawing.Size(70, 35);
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
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(127, 94);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(126, 30);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(126, 30);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(126, 30);
            this.pasteToolStripMenuItem.Text = "Paste";
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
            this.spreadsheetPanel.Size = new System.Drawing.Size(1002, 399);
            this.spreadsheetPanel.TabIndex = 3;
            // 
            // featuresMenuItem
            // 
            this.featuresMenuItem.Name = "featuresMenuItem";
            this.featuresMenuItem.Size = new System.Drawing.Size(281, 30);
            this.featuresMenuItem.Text = "Additional Features";
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
        private System.Windows.Forms.ToolStripMenuItem newMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
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
        private System.Windows.Forms.ToolStripMenuItem cutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkModeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoSaveMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem featuresMenuItem;
    }
}

