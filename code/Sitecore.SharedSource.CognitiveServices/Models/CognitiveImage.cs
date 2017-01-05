﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Vision.Contract;

namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public class CognitiveImage : ICognitiveImage
    {
        public CognitiveImage(string database = "", string language = "", string itemId = "")
        {
            Analysis = new AnalysisResult();
            Database = database;
            Language = language;
            ItemId = itemId;
        }

        public AnalysisResult Analysis { get; set; }
        public string ItemId { get; set; }
        public string Language { get; set; }
        public string Database { get; set; }
    }
}