﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Search.ComputedFields.Image
{
    public class Colors : BaseComputedField
    {
        protected override object GetFieldValue(CognitiveIndexableImageItem cognitiveIndexable)
        {
            var color = cognitiveIndexable.Visions?.Color;
            if (color == null)
                return null;

            List<string> colorList = new List<string>
            {
                color.AccentColor,
                color.DominantColorBackground,
                color.DominantColorForeground
            };
            colorList.AddRange(color.DominantColors);

            return colorList.Select(GetHex).Distinct();
        }

        public virtual string GetHex(string value)
        {
            if (Regex.IsMatch(value, "^(?:[0-9a-fA-F]{3}){1,2}$"))
                return $"#{value}";

            var rgb = System.Drawing.Color.FromName(value).ToArgb() & 0xFFFFFF;

            return $"#{rgb:X6}";
        }
    }
}