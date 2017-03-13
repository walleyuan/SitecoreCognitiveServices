using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Security;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Foundation;

namespace Sitecore.SharedSource.CognitiveServices.Search
{
    public class CognitiveSearchContext : ICognitiveSearchContext
    {
        protected readonly ISitecoreDataService DataService;
        
        protected static readonly string IndexNameFormat = Sitecore.Configuration.Settings.GetSetting("CognitiveService.Search.IndexNameFormat");
        
        public CognitiveSearchContext(
            ISitecoreDataService dataService)
        {
            DataService = dataService;
        }

        public virtual ICognitiveSearchResult GetAnalysis(string itemId, string languageCode, string dbName)
        {
            var index = ContentSearchManager.GetIndex(GetIndexName(dbName));
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                return context.GetQueryable<CognitiveSearchResult>()
                    .Where(a => 
                        a.UniqueId.Contains(itemId.ToLower()) 
                        && a.Language == languageCode)
                    .Take(1)
                    .FirstOrDefault();
            }
        }

        public virtual List<ICognitiveSearchResult> GetMediaResults(string query, string languageCode, string dbName)
        {
            var index = ContentSearchManager.GetIndex(GetIndexName(dbName));
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                return context.GetQueryable<CognitiveSearchResult>()
                    .Where(a => a.Language == languageCode &&
                    (a.Name.Contains(query) 
                    || a.EmotionAnalysisValue.Contains(query) 
                    || a.FacialAnalysisValue.Contains(query)
                    || a.TextAnalysisValue.Contains(query)
                    || a.VisionAnalysisValue.Contains(query)
                    ))
                    .ToList<ICognitiveSearchResult>();
            }
        }

        /// <summary>
        /// Default filters in query predicate
        /// </summary>
        /// <param name="parameterValues"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public virtual Expression<Func<CognitiveSearchResult, bool>> GetDefaultFilter(string[] parameterValues, string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName) || parameterValues == null || !parameterValues.Any())
            {
                return null;
            }

            Expression<Func<CognitiveSearchResult, bool>> innerPredicate = PredicateBuilder.True<CognitiveSearchResult>();
            foreach (string val in parameterValues.Where(d => !string.IsNullOrEmpty(d)))
            {
                string parameterValue = val;
                innerPredicate = innerPredicate.Or(i => (string)i[(ObjectIndexerKey)fieldName] == parameterValue);
            }

            return innerPredicate;
        }

        public virtual Expression<Func<CognitiveSearchResult, bool>> GetRangeFilter(string[] parameterValues, string fieldName)
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

            Expression<Func<CognitiveSearchResult, bool>> innerPredicate = PredicateBuilder.True<CognitiveSearchResult>();

            //scientific notation
            double min = double.Parse(parameterValues[0]);
            double max = double.Parse(parameterValues[1]);

            if (fieldName != "age_td")
            {
                min = min * .01;
                max = max * .01;
            }

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

        public virtual List<ICognitiveSearchResult> GetMediaResults(Dictionary<string, string[]> tagParameters, Dictionary<string, string[]> rangeParameters, int gender, int glasses, string languageCode, string dbName)
        {
            var index = ContentSearchManager.GetIndex(GetIndexName(dbName));
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                IQueryable<CognitiveSearchResult> queryable = context.GetQueryable<CognitiveSearchResult>()
                    .Where(a => a.Language == languageCode);
                
                if (gender != 0)
                {
                    queryable = queryable.Where(x => x.Gender == gender);
                }

                if (glasses >= 0)
                {
                    queryable = queryable.Where(x => x.Glasses.Contains(glasses));
                }

                foreach (var parameter in tagParameters)
                {
                    var thisParamPredicate = GetDefaultFilter(parameter.Value, parameter.Key);
                    if (thisParamPredicate != null)
                    {
                        queryable = queryable.Where(thisParamPredicate);
                    }
                }

                foreach (var parameter in rangeParameters)
                {
                    var thisParamPredicate = GetRangeFilter(parameter.Value, parameter.Key);
                    if (thisParamPredicate != null)
                    {
                        queryable = queryable.Where(thisParamPredicate);
                    }
                }

                return queryable.ToList<ICognitiveSearchResult>();
            }
        }

        public virtual string[] GetAutocompleteResults(string term, string languageCode, string dbName)
        {
            var index = ContentSearchManager.GetIndex(GetIndexName(dbName));
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                return context.GetQueryable<CognitiveSearchResult>()
                    .Where(a => a.Language == languageCode && a.Tags.Contains(term))
                    .Take(25)
                    .SelectMany(x => x.Tags)
                    .ToArray<string>();
            }
        }

        public virtual List<KeyValuePair<string, int>> GetTags(string languageCode, string dbName)
        {
            var index = ContentSearchManager.GetIndex(GetIndexName(dbName));
            
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck)) {
                var results = context.GetQueryable<CognitiveSearchResult>()
                        .Where(a => a.Language == languageCode)
                        .ToArray<CognitiveSearchResult>();

                var tags = results
                        .Where(x => x.Tags != null)
                        .SelectMany(x => x.Tags)
                        .ToArray();

                return tags.GroupBy(x => x)
                    .Select(x => new KeyValuePair<string, int>(x.Key, x.Count()))
                    .OrderByDescending(x => x.Value)
                    .ToList();
            }
        }

        public virtual void AddItemToIndex(string itemId, string dbName)
        {
            ID id = DataService.GetID(itemId);
            if (id.IsNull)
                return;

            Item i = DataService.GetDatabase(dbName).GetItem(id);
            if (i == null)
                return;

            AddItemToIndex(i, dbName);
        }

        public virtual void AddItemToIndex(Item item, string dbName)
        {
            if (item == null)
                return;

            var tempItem = (SitecoreIndexableItem)item;
            ContentSearchManager.GetIndex(GetIndexName(dbName)).Refresh(tempItem);
        }

        public virtual void UpdateItemInIndex(string itemId, string dbName)
        {
            ID id = DataService.GetID(itemId);
            if (id.IsNull)
                return;

            Item i = DataService.GetDatabase(dbName).GetItem(id);
            if (i == null)
                return;

            UpdateItemInIndex(i, dbName);
        }

        public virtual void UpdateItemInIndex(Item item, string dbName)
        {
            if (item == null)
                return;

            var tempItem = (SitecoreIndexableItem)item;

            var index = ContentSearchManager.GetIndex(GetIndexName(dbName));
                
            index.Update(tempItem.UniqueId);
        }

        protected string GetIndexName(string dbName)
        {
            if (dbName == null)
            {
                dbName = "master";
            }
            return string.Format(IndexNameFormat, dbName);
        }
    }
}