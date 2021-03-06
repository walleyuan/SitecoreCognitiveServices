﻿using System;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using SitecoreCognitiveServices.Feature.ImageSearch.Factories;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Xml;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.Maintenance;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Security;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using Sitecore.Data;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Utility;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Search {
    public class ImageSearchService : IImageSearchService 
    {
        #region Constructor

        protected readonly IContentSearchWrapper ContentSearch;
        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly IImageSearchSettings ImageSearchSettings;
        protected readonly IImageDescriptionFactory ImageDescriptionFactory;
        protected readonly ICognitiveImageAnalysisFactory ImageAnalysisFactory;

        public ImageSearchService(
            IContentSearchWrapper contentSearch,
            ISitecoreDataWrapper dataWrapper,
            IImageSearchSettings imageSearchSettings,
            IImageDescriptionFactory imageDescriptionFactory,
            ICognitiveImageAnalysisFactory imageAnalysisFactory)
        {
            ContentSearch = contentSearch;
            DataWrapper = dataWrapper;
            ImageSearchSettings = imageSearchSettings;
            ImageDescriptionFactory = imageDescriptionFactory;
            ImageAnalysisFactory = imageAnalysisFactory;
        }

        #endregion
        
        #region Indexing

        public virtual void AddItemToIndex(string itemId, string dbName)
        {
            ContentSearch.AddItemToIndex(itemId, dbName, GetCognitiveIndexName(dbName));
        }

        public virtual void AddItemToIndex(Item item, string dbName)
        {
            ContentSearch.AddItemToIndex(item, GetCognitiveIndexName(dbName));
        }

        public virtual void UpdateItemInIndex(string itemId, string dbName)
        {
            ContentSearch.UpdateItemInIndex(itemId, dbName, GetCognitiveIndexName(dbName));
        }

        public virtual void UpdateItemInIndex(Item item, string dbName)
        {
            ContentSearch.UpdateItemInIndex(item, GetCognitiveIndexName(dbName));
        }
        
        public virtual int UpdateMediaItemsInIndexRecursively(Item item, string db)
        {
            var list = GetMediaItems(
                item.Paths.FullPath, 
                item.Language.Name, 
                item.Database.Name);
            
            list.ForEach(b => UpdateItemInIndex(b, db));

            return list.Count;
        }

        public virtual void RebuildCognitiveIndexes()
        {
            List<string> cogIndexes = new List<string>();
            var nodes = Sitecore.Configuration.Factory.GetConfigNodes("contentSearch/configuration/indexes/index");
            foreach (XmlNode n in nodes)
            {
                var id = n.Attributes?["id"];
                if (id == null || !id.Value.StartsWith("cognitive"))
                    continue;
                
                var dbNode = n.SelectSingleNode("locations/crawler/Database");
                var value = dbNode?.FirstChild?.InnerText;
                if (string.IsNullOrEmpty(value))
                    continue;

                cogIndexes.Add(value);    
            }
            
            foreach(var dbName in cogIndexes)
            { 
                var searchIndex = ContentSearch.GetIndex(GetCognitiveIndexName(dbName));
                IndexCustodian.FullRebuild(searchIndex);
            }
        }

        #endregion

        #region Querying
        
        public virtual ICognitiveImageAnalysis GetImageAnalysis(string id, string language, string db)
        {
            ICognitiveImageSearchResult csr = GetCognitiveSearchResult(id, language, db);

            return ImageAnalysisFactory.Create(csr);
        }

        public virtual IImageDescription GetImageDescription(MediaItem m, string language)
        {

            ICognitiveImageSearchResult csr = GetCognitiveSearchResult(m.ID.ToString(), language, m.Database.Name);

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

        public virtual ICognitiveImageSearchResult GetCognitiveSearchResult(string itemId, string language, string dbName) {
            Assert.IsTrue(!string.IsNullOrEmpty(itemId), "The item id parameter is required");
            Assert.IsTrue(!string.IsNullOrEmpty(language), "The language parameter is required");
            Assert.IsTrue(!string.IsNullOrEmpty(dbName), "The database parameter is required");

            var index = ContentSearch.GetIndex(GetCognitiveIndexName(dbName));
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                return context.GetQueryable<CognitiveImageSearchResult>()
                    .Where(a =>
                        a.UniqueId.Contains(itemId.ToLower())
                        && a.Language == language)
                    .Take(1)
                    .FirstOrDefault();
            }
        }

        public virtual List<ICognitiveImageSearchResult> GetFilteredCognitiveSearchResults(Dictionary<string, string[]> tagParameters, Dictionary<string, string[]> rangeParameters, int gender, int glasses, int size, string languageCode, List<string> colors, string dbName)
        {
            var index = ContentSearch.GetIndex(GetCognitiveIndexName(dbName));
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                IQueryable<CognitiveImageSearchResult> queryable = context.GetQueryable<CognitiveImageSearchResult>()
                    .Where(a => a.Language == languageCode);
                
                if(colors != null) {
                    var colorPredicate = GetDefaultFilter(colors.ToArray(), "Colors");
                    if (colorPredicate != null)
                        queryable = queryable.Where(colorPredicate);
                }

                if (gender != 0)
                    queryable = queryable.Where(x => x.Gender == gender);
                
                if (glasses >= 0)
                    queryable = queryable.Where(x => x.Glasses.Contains(glasses));
                
                foreach (var parameter in tagParameters)
                {
                    var thisParamPredicate = GetDefaultFilter(parameter.Value, parameter.Key);
                    if (thisParamPredicate != null)
                        queryable = queryable.Where(thisParamPredicate);
                }

                var hasAge = rangeParameters.Keys.Any(k => k.StartsWith("age"));
                if (hasAge)
                {
                    var ageKey = rangeParameters.ContainsKey("age_td") ? "age_td" : "age";
                    var age = rangeParameters[ageKey];

                    var min = double.Parse(age[0]);
                    var max = double.Parse(age[1]);

                    if (min > 0d)
                        queryable = queryable.Where(r => r.AgeMin >= min);

                    if (max < 100d)
                        queryable = queryable.Where(r => r.AgeMax <= max);

                    rangeParameters.Remove(ageKey);
                }

                if (size > 0)
                    queryable = queryable.Where(r => r.Size >= size);
                
                foreach (var parameter in rangeParameters)
                {
                    var thisParamPredicate = GetRangeFilter(parameter.Value, parameter.Key);
                    if (thisParamPredicate != null)
                        queryable = queryable.Where(thisParamPredicate);
                }

                var results = queryable
                    .ToList()
                    .Where(a => DataWrapper.IsMediaFile(a.TemplateId, dbName))
                    .ToList<ICognitiveImageSearchResult>();

                return results;
            }
        }

        public virtual Item GetImageAnalysisItem(string itemName, string languageCode, string dbName)
        {
            var index = ContentSearch.GetIndex(ContentSearch.GetSitecoreIndexName(dbName));
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                return context.GetQueryable<CognitiveImageSearchResult>()
                    .Where(a =>
                        a.Paths.Contains(ImageSearchSettings.ImageAnalysisFolderId)
                        && a.Name == itemName
                        && a.Language == languageCode)
                    .Take(1)
                    .FirstOrDefault()
                    ?.GetItem();
            }
        }

        public virtual List<Item> GetMediaItems(string folderPath, string languageCode, string dbName)
        {
            var index = ContentSearch.GetIndex(ContentSearch.GetSitecoreIndexName(dbName));
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                return context.GetQueryable<CognitiveImageSearchResult>()
                    .Where(a => a.Language == languageCode)
                    .Select(b => b.GetItem())
                    .ToList()
                    .Where(a => a.Paths.FullPath.StartsWith(folderPath) && DataWrapper.IsMediaFile(a))
                    .ToList();
            }
        }

        public virtual List<KeyValuePair<string, int>> GetTags(string languageCode, string dbName)
        {
            var index = ContentSearch.GetIndex(GetCognitiveIndexName(dbName));

            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                var results = context.GetQueryable<CognitiveImageSearchResult>()
                    .Where(a => a.Language == languageCode)
                    .ToArray();

                var tags = results
                    .Where(x => x.Tags != null)
                    .SelectMany(x => x.Tags)
                    .Select(a => a.Trim())
                    .ToArray();

                return tags.GroupBy(x => x)
                    .Select(x => new KeyValuePair<string, int>(x.Key, x.Count()))
                    .OrderByDescending(x => x.Value)
                    .ToList();
            }
        }

        public virtual List<string> GetColors(string languageCode, string dbName)
        {
            var index = ContentSearch.GetIndex(GetCognitiveIndexName(dbName));

            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                var results = context.GetQueryable<CognitiveImageSearchResult>()
                    .Where(a => a.Language == languageCode)
                    .ToArray();

                var colors = results
                    .Where(x => x.Colors != null)
                    .SelectMany(x => x.Colors)
                    .Distinct()
                    .OrderBy(a => a)
                    .ToList();

                return colors;
            }
        }
        
        #endregion

        #region Helpers
        
        public virtual string GetCognitiveIndexName(string dbName)
        {
            return string.Format(ImageSearchSettings.CognitiveIndexNameFormat, dbName ?? "master");
        }

        /// <summary>
        /// Default filters in query predicate
        /// </summary>
        /// <param name="parameterValues"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public virtual Expression<Func<CognitiveImageSearchResult, bool>> GetDefaultFilter(string[] parameterValues, string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName) || parameterValues == null || !parameterValues.Any())
            {
                return null;
            }

            Expression<Func<CognitiveImageSearchResult, bool>> innerPredicate = PredicateBuilder.True<CognitiveImageSearchResult>();
            foreach (string val in parameterValues.Where(d => !string.IsNullOrEmpty(d)))
            {
                string parameterValue = val;
                innerPredicate = innerPredicate.Or(i => (string)i[(ObjectIndexerKey)fieldName] == parameterValue);
            }

            return innerPredicate;
        }

        public virtual Expression<Func<CognitiveImageSearchResult, bool>> GetRangeFilter(string[] parameterValues, string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName) || !parameterValues.Any())
            {
                return null;
            }

            if (parameterValues[0] == "0" && parameterValues[1] == "100")
            {
                //no need for a query
                return null;
            }

            Expression<Func<CognitiveImageSearchResult, bool>> innerPredicate = PredicateBuilder.True<CognitiveImageSearchResult>();

            //scientific notation
            double min = double.Parse(parameterValues[0]);
            double max = double.Parse(parameterValues[1]);

            if (parameterValues[0] == "0")
            {
                //place limit only on the high end
                return innerPredicate.And(i => (double)i[(ObjectIndexerKey)fieldName] <= max);
            }

            if (parameterValues[1] == "100")
            {
                //place limit only on the low end
                return innerPredicate.And(i => (double)i[(ObjectIndexerKey)fieldName] >= min);
            }

            return innerPredicate.And(i => (double)i[(ObjectIndexerKey)fieldName] >= min && (double)i[(ObjectIndexerKey)fieldName] <= max);
        }

        #endregion
    }
}