using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Burnout.Helpers
{
    class ColorHelper
    {
        public static readonly Color Default_Red = HexToColor("AF1313");
        public static readonly Color Default_Blue = HexToColor("0766B4");
        public static Color HexToColor(string hex)
        {
            hex = hex.Replace("#", "");
            if (hex.Length < 6) return Color.white;

            float col_r = Convert.ToInt32(hex.Substring(0, 2), 16) / 255f;
            float col_g = Convert.ToInt32(hex.Substring(2, 2), 16) / 255f;
            float col_b = Convert.ToInt32(hex.Substring(4, 2), 16) / 255f;
            return new Color(col_r, col_g, col_b);
        }

        public static string ColorToHex(Color col)
        {
            string total = "#";
            int col_r = (int)Math.Floor(col.r * 255);
            int col_g = (int)Math.Floor(col.g * 255);
            int col_b = (int)Math.Floor(col.b * 255);
            total += $"{col_r:X2}{col_g:X2}{col_b:X2}";
            return total;
        }

    }
}
