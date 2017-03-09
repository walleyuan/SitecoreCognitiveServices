using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Vision
{
    public class ScreenUrl
    {
        public string URL { get; set; }
        public ScreenCategory Categories { get; set; }
    }
}