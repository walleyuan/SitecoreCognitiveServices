using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Models
{
    public interface ICognitiveImageSearchJsonResult
    {
        string Url { get; set; }
        string Alt { get; set; }
    }
}