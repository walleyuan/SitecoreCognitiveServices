using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Models;
using Sitecore.SharedSource.CognitiveServices.ImageSearch.Search;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Factories
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

        public virtual ICognitiveImageSearch Create(string db, string language, ICognitiveImageSearchContext searcher)
        {
            var r = Create();
            r.Database = db;
            r.Language = language;
            r.Tags = searcher.GetTags(language, db);

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

            return obj;
        }
    }
}