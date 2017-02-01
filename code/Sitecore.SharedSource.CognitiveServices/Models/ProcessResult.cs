using Microsoft.ProjectOxford.EntityLinking.Contract;
using Microsoft.ProjectOxford.Text.Language;
using Microsoft.ProjectOxford.Text.Sentiment;
using Microsoft.ProjectOxford.Vision.Contract;

namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public class ProcessResult : IProcessResult
    {
        public int ItemCount { get; set; }
        public string ItemId { get; set; }
        public string Database { get; set; }
        public string Language { get; set; }
    }
}