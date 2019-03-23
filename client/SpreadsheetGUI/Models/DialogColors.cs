/***********************************************************************************************
 *                                                                                             *
 *                 Project Name : PS6                                                          *
 *                                                                                             *
 *                        File  : Models/DialogColors.cs                                       *
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

namespace SS.Models {

    /// <summary>
    /// Used as a lookup for colors when switching between themes.
    /// Standard color names are the "light" theme and the alt colors are the "dark" theme.
    /// </summary>
    public static class DialogColors {
        public static Color ColorLow = Color.FromArgb(215, 215, 215);
        public static Color ColorMid = Color.FromArgb(221, 221, 221);
        public static Color ColorHi = Color.FromArgb(255, 255, 255);
        public static Color ColorSelect = Color.FromArgb(29, 130, 212);

        public static Color ColorLowAlt = Color.FromArgb(37, 37, 38);
        public static Color ColorMidAlt = Color.FromArgb(50, 50, 50);
        public static Color ColorHiAlt = Color.FromArgb(255, 255, 255);
        public static Color ColorSelectAlt = Color.FromArgb(0, 122, 204);
    }
}
