using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.ProjectOxford.Emotion.Contract;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models
{
    public class EmotionResult
    {
        public Emotion[] Result { get; set; }
        public string ImageUrl { get; set; }
    }
}