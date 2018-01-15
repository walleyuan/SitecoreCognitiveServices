using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Models
{
    public interface ICognitiveImageSearchJsonResult
    {
        string Url { get; set; }
        string Alt { get; set; }
        string Id { get; set; }
    }
}