using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Search
{
    public interface ICognitiveMediaSearchJsonResult
    {
        string Url { get; set; }
        string Alt { get; set; }
    }
}