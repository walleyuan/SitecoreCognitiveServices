using System;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using SitecoreCognitiveServices.Feature.ImageSearch.Factories;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Models.Utility;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Services.Search {
    public class ImageSearchService : IImageSearchService 
    {
        protected readonly ICognitiveImageSearchContext Searcher;
        protected readonly IImageDescriptionFactory ImageDescriptionFactory;
        protected readonly ICognitiveImageAnalysisFactory ImageAnalysisFactory;

        public ImageSearchService(
            ICognitiveImageSearchContext searcher,
            IImageDescriptionFactory imageDescriptionFactory,
            ICognitiveImageAnalysisFactory imageAnalysisFactory)
        {
            Searcher = searcher;
            ImageDescriptionFactory = imageDescriptionFactory;
            ImageAnalysisFactory = imageAnalysisFactory;
        }

        #region Reindexing

        public virtual void UpdateItemInIndex(string itemId, string db)
        {
            Assert.IsTrue(!string.IsNullOrEmpty(itemId), "The id parameter is required");
            Assert.IsTrue(!string.IsNullOrEmpty(db), "The database parameter is required");

            Searcher.UpdateItemInIndex(itemId, db);
        }

        public virtual void UpdateItemInIndex(Item item, string db) {
            Assert.IsNotNull(item, "The item parameter is required");
            Assert.IsTrue(!string.IsNullOrEmpty(db), "The database parameter is required");

            Searcher.UpdateItemInIndex(item, db);
        }

        public virtual int UpdateItemInIndexRecursively(Item item, string db)
        {
            var list = item.Axes.GetDescendants()
                .Where(a => !a.TemplateID.Guid.Equals(Sitecore.TemplateIDs.MediaFolder.Guid))
                .ToList();

            list.ForEach(b => Searcher.UpdateItemInIndex(b, db));

            return list.Count;
        }

        #endregion Reindexing

        #region Querying

        public virtual ICognitiveImageSearchResult GetCognitiveSearchResult(string itemId, string language, string db) {
            Assert.IsTrue(!string.IsNullOrEmpty(itemId), "The item id parameter is required");
            Assert.IsTrue(!string.IsNullOrEmpty(language), "The language parameter is required");
            Assert.IsTrue(!string.IsNullOrEmpty(db), "The database parameter is required");

            return Searcher.GetAnalysis(itemId, language, db);
        }

        public virtual ICognitiveImageAnalysis GetImageAnalysis(string id, string language, string db)
        {
            ICognitiveImageSearchResult csr = GetCognitiveSearchResult(id, language, db);

            return ImageAnalysisFactory.Create(csr);
        }

        public virtual IImageDescription GetImageDescription(MediaItem m, string language) {

            ICognitiveImageSearchResult csr = Searcher.GetAnalysis(m.ID.ToString(), language, m.Database.Name);
            
            Description d = csr
                ?.VisionAnalysis
                ?.Description;

            if (d == null)
                return null;

            return ImageDescriptionFactory.Create(d, m.Alt, m.ID.ToString(), m.Database.Name, language);
        }

        public virtual Caption GetTopImageCaption(MediaItem m, string language, double threshold)
        {
            var csr = GetCognitiveSearchResult(m.ID.ToString(), language, m.Database.Name);

            try
            {
                return csr
                    .VisionAnalysis
                    .Description
                    .Captions
                    .OrderByDescending(a => a.Confidence)
                    .First(c => c.Confidence >= threshold);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion Querying
    }
}