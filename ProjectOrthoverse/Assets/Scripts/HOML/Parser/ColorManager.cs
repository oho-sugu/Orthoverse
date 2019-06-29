using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Homl.Parser
{
    // Management Colors. implemented as Singleton
    public class ColorManager
    {
        private static Dictionary<string, Color> colorDic;
        private static ColorManager instance;

        private ColorManager()
        {
            // Color settings
            colorDic = new Dictionary<string, Color>(10);
            colorDic["white"] = Color.white;
            colorDic["red"] = Color.red;
            colorDic["blue"] = Color.blue;
            colorDic["green"] = Color.green;
            colorDic["gray"] = Color.gray;
            colorDic["yellow"] = Color.yellow;
            colorDic["magenta"] = Color.magenta;
            colorDic["cyan"] = Color.cyan;
            colorDic["black"] = Color.black;
        }

        public static ColorManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ColorManager();
                }
                return instance;
            }
        }

        public Color getColor(string colorString)
        {
            if (colorDic.ContainsKey(colorString))
            {
                return colorDic[colorString];
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(colorString.ToUpper(), @"^#[0-9A-F]{3}$"))
            {
                float r = int.Parse(colorString.ToUpper().Substring(1, 1), System.Globalization.NumberStyles.HexNumber);
                float g = int.Parse(colorString.ToUpper().Substring(2, 1), System.Globalization.NumberStyles.HexNumber);
                float b = int.Parse(colorString.ToUpper().Substring(3, 1), System.Globalization.NumberStyles.HexNumber);

                return new Color(r / 15.0f, g / 15.0f, b / 15.0f);
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(colorString.ToUpper(), @"^#[0-9A-F]{6}$"))
            {
                float r = int.Parse(colorString.ToUpper().Substring(1, 2), System.Globalization.NumberStyles.HexNumber);
                float g = int.Parse(colorString.ToUpper().Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
                float b = int.Parse(colorString.ToUpper().Substring(5, 2), System.Globalization.NumberStyles.HexNumber);

                return new Color(r / 255.0f, g / 255.0f, b / 255.0f);
            }
            // return default color
            return Color.white;
        }
    }
}