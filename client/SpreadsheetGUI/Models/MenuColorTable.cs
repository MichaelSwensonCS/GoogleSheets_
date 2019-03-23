/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Models/MenuColorTable.cs                                     *
 *                                                                                             *
 *                       Author : Josh Perkins                                                 *
 *                                                                                             *
 *                   Start Date : 10/13/18                                                     *
 *                                                                                             *
 *                      Modtime : 10/13/18                                                     *
 *                                                                                             *
 *---------------------------------------------------------------------------------------------*
 * Functions:                                                                                  *
 * - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

using System.Drawing;
using System.Windows.Forms;

namespace SS.Models {

    /// <summary>
    /// A class used to overwrite the theme of menu strips and their items.
    /// </summary>
    public class MenuColorTable : ProfessionalColorTable {

        /// <summary>
        /// Represents whether the theme is dark or not.
        /// </summary>
        public bool DarkMode { get; set; }

        /// <summary>
        /// Basic constructor.
        /// </summary>
        /// <param name="mode">Sets the theme. Dark if true, light if false.</param>
        public MenuColorTable(bool mode) {
            DarkMode = mode;
        }

        // Please see:
        // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.professionalcolortable?view=netframework-4.7.2
        // For relevant information in regards to these overrides.

        public override Color ButtonCheckedGradientBegin => base.ButtonCheckedGradientBegin;

        public override Color ButtonCheckedGradientMiddle => base.ButtonCheckedGradientMiddle;

        public override Color ButtonCheckedGradientEnd => base.ButtonCheckedGradientEnd;

        public override Color ButtonCheckedHighlight => base.ButtonCheckedHighlight;

        public override Color ButtonCheckedHighlightBorder => base.ButtonCheckedHighlightBorder;

        public override Color ToolStripDropDownBackground => DarkMode ? DialogColors.ColorLowAlt : Color.FromArgb(253, 253, 253);

        public override Color ImageMarginGradientBegin => DarkMode ? DialogColors.ColorLowAlt : Color.FromArgb(248, 248, 248);

        public override Color ImageMarginGradientMiddle => DarkMode ? DialogColors.ColorLowAlt : Color.FromArgb(248, 248, 248);

        public override Color ImageMarginGradientEnd => DarkMode ? DialogColors.ColorLowAlt : Color.FromArgb(248, 248, 248);

        public override Color MenuBorder => DarkMode ? DialogColors.ColorMidAlt : Color.FromArgb(248, 248, 248);

        public override Color MenuItemBorder => DarkMode ? DialogColors.ColorMidAlt : Color.FromArgb(43, 142, 221);

        public override Color MenuItemSelected => DarkMode ? DialogColors.ColorMidAlt : Color.FromArgb(179, 215, 243);

        public override Color MenuStripGradientBegin => DarkMode ? DialogColors.ColorMidAlt : Color.FromArgb(243, 243, 243);

        public override Color MenuStripGradientEnd => DarkMode ? DialogColors.ColorMidAlt : Color.FromArgb(243, 243, 243);

        public override Color MenuItemSelectedGradientBegin => DarkMode ? DialogColors.ColorLowAlt : Color.FromArgb(252, 252, 252);

        public override Color MenuItemSelectedGradientEnd => DarkMode ? DialogColors.ColorLowAlt : Color.FromArgb(252, 252, 252);

        public override Color MenuItemPressedGradientBegin => DarkMode ? DialogColors.ColorLowAlt : Color.FromArgb(179, 215, 243);

        public override Color MenuItemPressedGradientEnd => DarkMode ? DialogColors.ColorLowAlt : Color.FromArgb(179, 215, 243);

        public override Color SeparatorDark => DarkMode ? DialogColors.ColorMidAlt : Color.FromArgb(200, 200, 200);
    }
}
