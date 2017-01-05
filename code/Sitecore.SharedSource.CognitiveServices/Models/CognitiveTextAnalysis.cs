using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.EntityLinking.Contract;
using Microsoft.ProjectOxford.Text.Language;
using Microsoft.ProjectOxford.Text.Sentiment;

namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public class CognitiveTextAnalysis : ICognitiveTextAnalysis
    {
        public CognitiveTextAnalysis()
        {
            LinkAnalysis = new EntityLink[0];
            SentimentAnalysis = new SentimentResponse();
            LanguageAnalysis = new LanguageResponse();
        }

        public EntityLink[] LinkAnalysis { get; set; }
        public SentimentResponse SentimentAnalysis { get; set; }
        public LanguageResponse LanguageAnalysis { get; set; }
    }
}