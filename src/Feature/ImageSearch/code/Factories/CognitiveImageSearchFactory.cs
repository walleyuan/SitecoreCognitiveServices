using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Feature.ImageSearch.Models;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Factories
{
    public class CognitiveImageSearchFactory : ICognitiveImageSearchFactory
    {
        protected readonly IServiceProvider Provider;

        public CognitiveImageSearchFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual ICognitiveImageSearch Create()
        {
            return Provider.GetService<ICognitiveImageSearch>();
        }

        public virtual ICognitiveImageSearch Create(string db, string language, IImageSearchService searchService)
        {
            var r = Create();
            r.Database = db;
            r.Language = language;
            r.Tags = searchService.GetTags(language, db);

            return r;
        }
        
        public virtual ICognitiveImageSearchJsonResult CreateMediaSearchJsonResult(ISitecoreDataWrapper dataWrapper, ICognitiveImageSearchResult searchResult)
        {
            var obj = Provider.GetService<ICognitiveImageSearchJsonResult>();
            
            MediaItem m = dataWrapper.GetItemByUri(searchResult.UniqueId);

            try
            {
                obj.Url = $"/sitecore/shell/-/media/{m.ID.Guid:N}.ashx";
            }
            catch (Exception ex)
            {
                obj.Url = string.Empty;
            }
            try
            {
                obj.Alt = m.Alt;
            }
            catch (Exception ex)
            {
                obj.Alt = string.Empty;
            }
            try
            {
                obj.Id = m.ID.ToString();
            }
            catch (Exception ex)
            {
                obj.Id = string.Empty;
            }

            return obj;
        }
    }
}