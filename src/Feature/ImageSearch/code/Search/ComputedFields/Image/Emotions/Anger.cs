﻿using System.Linq;
using Sitecore.Data.Items;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Search.ComputedFields.Image.Emotions
{
    public class Anger : BaseComputedField
    {
        protected override object GetFieldValue(Item cognitiveIndexable)
        {
            return (Emotions != null && Emotions.Length > 0)
                ? (object)Emotions?.Average(x => x.Scores.Anger)
                : null;
        }
    }
}