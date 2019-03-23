// Written by Joe Zachary for CS 3500, September 2011.
// Updated by Josh Perkins

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS {

    /// <summary>
    /// The type of delegate used to register for SelectionChanged events
    /// </summary>
    /// <param name="sender"></param>

    public delegate void SelectionChangedHandler(SpreadsheetPanel sender);


    /// <summary>
    /// A panel that displays a spreadsheet with 26 columns (labeled A-Z) and 99 rows
    /// (labeled 1-99).  Each cell on the grid can display a non-editable string.  One 
    /// of the cells is always selected (and highlighted).  When the selection changes, a 
    /// SelectionChanged event is fired.  Clients can register to be notified of
    /// such events.
    /// 
    /// None of the cells are editable.  They are for display purposes only.
    /// </summary>

    public partial class SpreadsheetPanel : UserControl {
        // The SpreadsheetPanel is composed of a DrawingPanel (where the grid is drawn),
        // a horizontal scroll bar, and a vertical scroll bar.
        private DrawingPanel drawingPanel;
        private HScrollBar hScroll;
        private VScrollBar vScroll;

        // These constants control the layout of the spreadsheet grid.  The height and
        // width measurements are in pixels.
        private const int DATA_COL_WIDTH = 80;
        private const int DATA_ROW_HEIGHT = 20;
        private const int LABEL_COL_WIDTH = 30;
        private const int LABEL_ROW_HEIGHT = 30;
        private const int PADDING = 2;
        private const int SCROLLBAR_WIDTH = 20;
        private const int COL_COUNT = 26;
        private const int ROW_COUNT = 99;


        /// <summary>
        /// Creates an empty SpreadsheetPanel
        /// </summary>

        public SpreadsheetPanel() {

            InitializeComponent();

            // The DrawingPanel is quite large, since it has 26 columns and 99 rows.  The
            // SpreadsheetPanel itself will usually be smaller, which is why scroll bars
            // are necessary.
            drawingPanel = new DrawingPanel(this);
            drawingPanel.Location = new Point(0, 0);
            drawingPanel.AutoScroll = false;

            // A custom vertical scroll bar.  It is designed to scroll in multiples of rows.
            vScroll = new VScrollBar();
            vScroll.SmallChange = 1;
            vScroll.Maximum = ROW_COUNT;

            // A custom horizontal scroll bar.  It is designed to scroll in multiples of columns.
            hScroll = new HScrollBar();
            hScroll.SmallChange = 1;
            hScroll.Maximum = COL_COUNT;

            // Add the drawing panel and the scroll bars to the SpreadsheetPanel.
            Controls.Add(drawingPanel);
            Controls.Add(vScroll);
            Controls.Add(hScroll);

            // Arrange for the drawing panel to be notified when it needs to scroll itself.
            hScroll.Scroll += drawingPanel.HandleHScroll;
            vScroll.Scroll += drawingPanel.HandleVScroll;
        }

        /// <summary>
        /// Handles any keypresses on the spreadsheet panel.
        /// </summary>
        /// <param name="keyData">The key type</param>
        /// <returns>bool</returns>
        protected override bool ProcessDialogKey(Keys keyData) {
            drawingPanel.GetSelection(out int col, out int row);

            switch (keyData) {
                case Keys.Right:
                    if (col == COL_COUNT) { return true; }
                    else {
                        drawingPanel.SetSelection(col + 1, row);
                        return true;
                    }
                case Keys.Left:
                    if (col == 0) { return true; }
                    else {
                        drawingPanel.SetSelection(col - 1, row);
                        return true;
                    }
                case Keys.Up:
                    if (row == 0) { return true; }
                    else {
                        drawingPanel.SetSelection(col, row - 1);
                        return true;
                    }
                case Keys.Down:
                    if (row == ROW_COUNT) { return true; }
                    else {
                        drawingPanel.SetSelection(col, row + 1);
                        return true;
                    }
                case Keys.Enter:
                    drawingPanel.SetSelection(col, row + 1);
                    return false;
                case Keys.Tab:
                    drawingPanel.SetSelection(col + 1, row);
                    return false;
            }

            return false;
        }

        /// <summary>
        /// Clears the display.
        /// </summary>

        public void Clear() {
            drawingPanel.Clear();
        }


        /// <summary>
        /// If the zero-based column and row are in range, sets the value of that
        /// cell and returns true.  Otherwise, returns false.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <param name="value"></param>
        /// <returns></returns>

        public bool SetValue(int col, int row, string value) {
            return drawingPanel.SetValue(col, row, value);
        }


        /// <summary>
        /// If the zero-based column and row are in range, assigns the value
        /// of that cell to the out parameter and returns true.  Otherwise,
        /// returns false.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <param name="value"></param>
        /// <returns></returns>

        public bool GetValue(int col, int row, out string value) {
            return drawingPanel.GetValue(col, row, out value);
        }


        /// <summary>
        /// If the zero-based column and row are in range, uses them to set
        /// the current selection and returns true.  Otherwise, returns false.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>

        public bool SetSelection(int col, int row) {
            return drawingPanel.SetSelection(col, row);
        }


        /// <summary>
        /// Assigns the column and row of the current selection to the
        /// out parameters.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>

        public void GetSelection(out int col, out int row) {
            drawingPanel.GetSelection(out col, out row);
        }

        public void CellBeingEdited(bool state) {
            drawingPanel.CellBeingEdited(state);
        }

        public void DarkMode(bool state) {
            drawingPanel.DarkMode(state);
        }


        /// <summary>
        /// When the SpreadsheetPanel is resized, we set the size and locations of the three
        /// components that make it up.
        /// </summary>
        /// <param name="eventargs"></param>

        protected override void OnResize(EventArgs eventargs) {
            base.OnResize(eventargs);
            if (FindForm() == null || FindForm().WindowState != FormWindowState.Minimized) {
                drawingPanel.Size = new Size(Width - SCROLLBAR_WIDTH, Height - SCROLLBAR_WIDTH);
                vScroll.Location = new Point(Width - SCROLLBAR_WIDTH, 0);
                vScroll.Size = new Size(SCROLLBAR_WIDTH, Height - SCROLLBAR_WIDTH);
                vScroll.LargeChange = (Height - SCROLLBAR_WIDTH) / DATA_ROW_HEIGHT;
                hScroll.Location = new Point(0, Height - SCROLLBAR_WIDTH);
                hScroll.Size = new Size(Width - SCROLLBAR_WIDTH, SCROLLBAR_WIDTH);
                hScroll.LargeChange = (Width - SCROLLBAR_WIDTH) / DATA_COL_WIDTH;
            }
        }

        /// <summary>
        /// The event used to send notifications of a selection change
        /// </summary>

        public event SelectionChangedHandler SelectionChanged;


        /// <summary>
        /// Used internally to keep track of cell addresses
        /// </summary>

        private class Address {

            public int Col { get; set; }
            public int Row { get; set; }

            public Address(int c, int r) {
                Col = c;
                Row = r;
            }

            public override int GetHashCode() {
                return Col.GetHashCode() ^ Row.GetHashCode();
            }

            public override bool Equals(object obj) {
                if ((obj == null) || !(obj is Address)) {
                    return false;
                }
                Address a = (Address)obj;
                return Col == a.Col && Row == a.Row;
            }

        }


        /// <summary>
        /// The panel where the spreadsheet grid is drawn.  It keeps track of the
        /// current selection as well as what is supposed to be drawn in each cell.
        /// </summary>

        private class DrawingPanel : Panel {
            // Definition of colors for light and dark themes
            private Color _colorLow = Color.FromArgb(215, 215, 215);
            private Color _colorMid = Color.FromArgb(221, 221, 221);
            private Color _colorHi = Color.FromArgb(255, 255, 255);
            private Color _colorSelect = Color.FromArgb(29, 130, 212);

            private Color _colorLowAlt = Color.FromArgb(37, 37, 38);
            private Color _colorMidAlt = Color.FromArgb(50, 50, 50);
            private Color _colorHiAlt = Color.FromArgb(255, 255, 255);
            private Color _colorSelectAlt = Color.FromArgb(0, 122, 204);

            // For rendering a custom caret on a cell being edited.
            [DllImport("User32.dll")]
            static extern bool CreateCaret(IntPtr hWnd, int hBitmap, int nWidth, int nHeight);

            [DllImport("User32.dll")]
            static extern bool SetCaretPos(int x, int y);

            [DllImport("User32.dll")]
            static extern bool DestroyCaret();

            [DllImport("User32.dll")]
            static extern bool ShowCaret(IntPtr hWnd);

            // Columns and rows are numbered beginning with 0.  This is the coordinate
            // of the selected cell.
            private int _selectedCol;
            private int _selectedRow;

            // Coordinate of cell in upper-left corner of display
            private int _firstColumn = 0;
            private int _firstRow = 0;

            // The strings contained by the spreadsheet
            private Dictionary<Address, String> _values;

            // The containing panel
            private SpreadsheetPanel _ssp;

            private bool _editing;
            private bool _darkMode;


            public DrawingPanel(SpreadsheetPanel ss) {
                DoubleBuffered = true;
                _values = new Dictionary<Address, String>();
                _ssp = ss;
                _editing = false;
            }


            private bool InvalidAddress(int col, int row) {
                return col < 0 || row < 0 || col >= COL_COUNT || row >= ROW_COUNT;
            }


            public void Clear() {
                _values.Clear();
                Invalidate();
            }


            public bool SetValue(int col, int row, string c) {
                if (InvalidAddress(col, row)) {
                    return false;
                }

                Address a = new Address(col, row);
                if (c == null || c == "") {
                    _values.Remove(a);
                }
                else {
                    _values[a] = c;
                }
                Invalidate();
                return true;
            }


            public bool GetValue(int col, int row, out string c) {
                if (InvalidAddress(col, row)) {
                    c = null;
                    return false;
                }
                if (!_values.TryGetValue(new Address(col, row), out c)) {
                    c = "";
                }
                return true;
            }


            public bool SetSelection(int col, int row) {
                if (InvalidAddress(col, row)) {
                    return false;
                }
                _selectedCol = col;
                _selectedRow = row;

                _ssp.SelectionChanged?.Invoke(_ssp);

                Invalidate();
                return true;
            }


            public void GetSelection(out int col, out int row) {
                col = _selectedCol;
                row = _selectedRow;
            }


            public void HandleHScroll(Object sender, ScrollEventArgs args) {
                _firstColumn = args.NewValue;
                Invalidate();
            }

            public void HandleVScroll(Object sender, ScrollEventArgs args) {
                _firstRow = args.NewValue;
                Invalidate();
            }


            public void CellBeingEdited(bool state) {
                _editing = state;
                if (_editing) {
                    CreateCaret(this.Handle, 0, 1, 12);
                }
                else {
                    DestroyCaret();
                }
            }

            public void DarkMode(bool state) {
                _darkMode = state;
            }

            protected override void OnPaint(PaintEventArgs e) {
                // Clip based on what needs to be refreshed.
                Region clip = new Region(e.ClipRectangle);
                e.Graphics.Clip = clip;

                // Color the background of the data area white
                e.Graphics.FillRectangle(
                    _darkMode ? new SolidBrush(_colorLowAlt) : new SolidBrush(_colorHi),
                    LABEL_COL_WIDTH,
                    LABEL_ROW_HEIGHT,
                    (COL_COUNT - _firstColumn) * DATA_COL_WIDTH,
                    (ROW_COUNT - _firstRow) * DATA_ROW_HEIGHT);

                // Pen, brush, and fonts to use
                Brush brush = _darkMode ? new SolidBrush(_colorMidAlt) : new SolidBrush(_colorMid);
                Brush fillBrush = _darkMode ? new SolidBrush(_colorMidAlt) : new SolidBrush(_colorLow);
                Pen pen = new Pen(brush);
                Font regularFont = Font;
                Font boldFont = new Font(regularFont, FontStyle.Bold);
                
                // Draw the column lines
                int bottom = LABEL_ROW_HEIGHT + (ROW_COUNT - _firstRow) * DATA_ROW_HEIGHT;
                e.Graphics.DrawLine(pen, new Point(0, 0), new Point(0, bottom));
                for (int x = 0; x <= (COL_COUNT - _firstColumn); x++) {
                    e.Graphics.DrawLine(
                        pen,
                        new Point(LABEL_COL_WIDTH + x * DATA_COL_WIDTH, 0),
                        new Point(LABEL_COL_WIDTH + x * DATA_COL_WIDTH, bottom));
                }

                // Draw the column labels
                for (int x = 0; x < COL_COUNT - _firstColumn; x++) {
                    Font f;

                    if (_selectedCol - _firstColumn == x) {
                        f = boldFont;

                        int colX = LABEL_COL_WIDTH + (_selectedCol - _firstColumn) * DATA_COL_WIDTH + 1;
                        int rowY = LABEL_ROW_HEIGHT + (_selectedRow - _firstRow) * DATA_ROW_HEIGHT + 1;

                        e.Graphics.FillRectangle(fillBrush, new Rectangle(
                                                    colX,
                                                    0,
                                                    DATA_COL_WIDTH,
                                                    LABEL_ROW_HEIGHT));

                        e.Graphics.FillRectangle(fillBrush, new Rectangle(
                                                    0,
                                                    rowY,
                                                    LABEL_COL_WIDTH,
                                                    DATA_ROW_HEIGHT));

                        // Set brush to green
                        fillBrush = new SolidBrush(Color.FromArgb(85, 170, 85));

                        e.Graphics.FillRectangle(fillBrush, new Rectangle(
                                                    colX,
                                                    LABEL_ROW_HEIGHT - 2,
                                                    DATA_COL_WIDTH,
                                                    2));

                        e.Graphics.FillRectangle(fillBrush, new Rectangle(
                                                    LABEL_COL_WIDTH - 2,
                                                    rowY,
                                                    2,
                                                    DATA_ROW_HEIGHT));
                    } else {
                        f = Font;
                    }
                    
                    DrawColumnLabel(e.Graphics, x, f);
                }

                // Draw the row lines
                int right = LABEL_COL_WIDTH + (COL_COUNT - _firstColumn) * DATA_COL_WIDTH;
                e.Graphics.DrawLine(pen, new Point(0, 0), new Point(right, 0));
                for (int y = 0; y <= ROW_COUNT - _firstRow; y++) {
                    e.Graphics.DrawLine(
                        pen,
                        new Point(0, LABEL_ROW_HEIGHT + y * DATA_ROW_HEIGHT),
                        new Point(right, LABEL_ROW_HEIGHT + y * DATA_ROW_HEIGHT));
                }

                // Draw the row labels
                for (int y = 0; y < (ROW_COUNT - _firstRow); y++) {
                    Font f = (_selectedRow - _firstRow == y) ? boldFont : Font;
                    DrawRowLabel(e.Graphics, y, f);
                }

                // Set pen to selection color
                pen.Color = _darkMode ? _colorSelectAlt : _colorSelect;
                pen.Width = 2;

                // Highlight the selection, if it is visible
                if ((_selectedCol - _firstColumn >= 0) && (_selectedRow - _firstRow >= 0)) {
                    int x = LABEL_COL_WIDTH + (_selectedCol - _firstColumn) * DATA_COL_WIDTH + 1;
                    int y = LABEL_ROW_HEIGHT + (_selectedRow - _firstRow) * DATA_ROW_HEIGHT + 1;

                    e.Graphics.DrawRectangle(pen, new Rectangle(x, y, DATA_COL_WIDTH - 2, DATA_ROW_HEIGHT - 2));
                }

                // Set brush color to text color
                brush = _darkMode ? new SolidBrush(_colorHiAlt) : new SolidBrush(Color.Black);
                pen.Width = 1;

                // Draw the text
                foreach (KeyValuePair<Address, String> address in _values) {
                    String text = address.Value;

                    int col = address.Key.Col;
                    int row = address.Key.Row;

                    int x = col - _firstColumn;
                    int y = row - _firstRow;

                    float height = e.Graphics.MeasureString(text, regularFont).Height;
                    float width = e.Graphics.MeasureString(text, regularFont).Width;

                    int xCoord = LABEL_COL_WIDTH + x * DATA_COL_WIDTH + PADDING;
                    int yCoord = LABEL_ROW_HEIGHT + y * DATA_ROW_HEIGHT;

                    if (col == _selectedCol && row == _selectedRow) {
                        if (_editing) {
                            int w = (int)width;

                            SetCaretPos(xCoord + w, yCoord + 3);
                            ShowCaret(this.Handle);
                        }
                    }

                    if (x >= 0 && y >= 0) {
                        Region cellClip = new Region(new Rectangle(xCoord,
                                                                   yCoord,
                                                                   DATA_COL_WIDTH - 2 * PADDING,
                                                                   DATA_ROW_HEIGHT));
                        cellClip.Intersect(clip);
                        e.Graphics.Clip = cellClip;
                        e.Graphics.DrawString(
                            text,
                            regularFont,
                            brush,
                            LABEL_COL_WIDTH + x * DATA_COL_WIDTH + PADDING,
                            LABEL_ROW_HEIGHT + y * DATA_ROW_HEIGHT + (DATA_ROW_HEIGHT - height) / 2);
                    }
                }


            }


            /// <summary>
            /// Draws a column label.  The columns are indexed beginning with zero.
            /// </summary>
            /// <param name="g"></param>
            /// <param name="x"></param>
            /// <param name="f"></param>
            private void DrawColumnLabel(Graphics g, int x, Font f) {
                String label = ((char)('A' + x + _firstColumn)).ToString();
                float height = g.MeasureString(label, f).Height;
                float width = g.MeasureString(label, f).Width;
                g.DrawString(
                      label,
                      f,
                      _darkMode ? new SolidBrush(_colorHiAlt) : new SolidBrush(Color.Black),
                      LABEL_COL_WIDTH + x * DATA_COL_WIDTH + (DATA_COL_WIDTH - width) / 2,
                      (LABEL_ROW_HEIGHT - height) / 2);
            }


            /// <summary>
            /// Draws a row label.  The rows are indexed beginning with zero.
            /// </summary>
            /// <param name="g"></param>
            /// <param name="y"></param>
            /// <param name="f"></param>
            private void DrawRowLabel(Graphics g, int y, Font f) {
                String label = (y + 1 + _firstRow).ToString();
                float height = g.MeasureString(label, f).Height;
                float width = g.MeasureString(label, f).Width;
                g.DrawString(
                    label,
                    f,
                    _darkMode ? new SolidBrush(_colorHiAlt) : new SolidBrush(Color.Black),
                    LABEL_COL_WIDTH - width - PADDING,
                    LABEL_ROW_HEIGHT + y * DATA_ROW_HEIGHT + (DATA_ROW_HEIGHT - height) / 2);
            }


            /// <summary>
            /// Determines which cell, if any, was clicked.  Generates a SelectionChanged event.  All of
            /// the indexes are zero based.
            /// </summary>
            /// <param name="e"></param>

            protected override void OnMouseClick(MouseEventArgs e) {
                base.OnClick(e);
                int x = (e.X - LABEL_COL_WIDTH) / DATA_COL_WIDTH;
                int y = (e.Y - LABEL_ROW_HEIGHT) / DATA_ROW_HEIGHT;

                if (e.X > LABEL_COL_WIDTH && e.Y > LABEL_ROW_HEIGHT && (x + _firstColumn < COL_COUNT) && (y + _firstRow < ROW_COUNT)) {
                    _selectedCol = x + _firstColumn;
                    _selectedRow = y + _firstRow;
                    if (_ssp.SelectionChanged != null) {
                        _ssp.SelectionChanged(_ssp);
                    }
                }
                Invalidate();
            }
        }
    }
}
