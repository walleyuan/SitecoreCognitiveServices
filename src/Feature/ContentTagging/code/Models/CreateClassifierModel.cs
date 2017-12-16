using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.ContentTagging.Models
{
    public class CreateClassifierModel
    {
        public string Language { get; set; }
        public string Id { get; set; }
        public string Database { get; set; }
    }
}