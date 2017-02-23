using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Factories;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Analysis;
using Sitecore.SharedSource.CognitiveServices.Models.Utility;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Services.Search {
    public class SearchService : ISearchService 
    {
        protected readonly ICognitiveSearchContext Searcher;
        protected readonly IImageDescriptionFactory ImageDescriptionFactory;
        protected readonly ICognitiveImageAnalysisFactory ImageAnalysisFactory;
        protected readonly ICognitiveTextAnalysisFactory TextAnalysisFactory;

        public SearchService(
            ICognitiveSearchContext searcher,
            IImageDescriptionFactory imageDescriptionFactory,
            ICognitiveImageAnalysisFactory imageAnalysisFactory,
            ICognitiveTextAnalysisFactory textAnalysisFactory)
        {
            Searcher = searcher;
            ImageDescriptionFactory = imageDescriptionFactory;
            ImageAnalysisFactory = imageAnalysisFactory;
            TextAnalysisFactory = textAnalysisFactory;
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

        public virtual ICognitiveSearchResult GetCognitiveSearchResult(string itemId, string language, string db) {
            Assert.IsTrue(!string.IsNullOrEmpty(itemId), "The item id parameter is required");
            Assert.IsTrue(!string.IsNullOrEmpty(language), "The language parameter is required");
            Assert.IsTrue(!string.IsNullOrEmpty(db), "The database parameter is required");

            return Searcher.GetAnalysis(itemId, language, db);
        }

        public virtual ICognitiveImageAnalysis GetImageAnalysis(string id, string language, string db)
        {
            ICognitiveSearchResult csr = GetCognitiveSearchResult(id, language, db);

            return ImageAnalysisFactory.Create(csr);
        }

        public virtual ICognitiveTextAnalysis GetTextAnalysis(string id, string language, string db) {
            ICognitiveSearchResult csr = GetCognitiveSearchResult(id, language, db);

            return TextAnalysisFactory.Create(csr);
        }

        public virtual IImageDescription GetImageDescription(MediaItem m, string language) {

            ICognitiveSearchResult csr = Searcher.GetAnalysis(m.ID.ToString(), language, m.Database.Name);
            
            Description d = csr
                ?.VisionAnalysis
                ?.Description
                ?? new Description();

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