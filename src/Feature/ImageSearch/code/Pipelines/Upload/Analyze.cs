using System.Linq;
using System.Web;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Pipelines.Attach;
using Sitecore.Pipelines.Upload;
using SitecoreCognitiveServices.Feature.ImageSearch.Analysis;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Pipelines.Upload
{
    public class Analyze : UploadProcessor
    {
        protected readonly IImageSearchSettings Settings;
        protected readonly IImageAnalysisService AnalysisService;

        public Analyze(
            IImageSearchSettings settings,
            IImageAnalysisService analysisService)
        {
            Settings = settings;
            AnalysisService = analysisService;
        }

        public void Process(UploadArgs args)
        {
            var Database = args.UploadedItems.Any() 
                ? args.UploadedItems.First().Database 
                : null;
            if (Database == null)
                return;
            
            foreach (Item mediaItem in args.UploadedItems)
            {
                var searchRoot = Database.GetItem(Settings.ImageSearchFolderId);
                CheckboxField f = searchRoot.Fields[Settings.AnalyzeNewImageField];
                if (f == null || !f.Checked)
                    return;
                
                AnalysisService.AnalyzeImage(mediaItem);
            }
        }
    }
}