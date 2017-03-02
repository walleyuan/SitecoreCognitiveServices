using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Models.Search;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Factories
{
    public class CognitiveMediaSearchFactory : ICognitiveMediaSearchFactory
    {
        protected readonly IServiceProvider Provider;

        public CognitiveMediaSearchFactory(IServiceProvider provider)
        {
            Provider = provider;
        }

        public virtual ICognitiveMediaSearch Create()
        {
            return Provider.GetService<ICognitiveMediaSearch>();
        }

        public virtual ICognitiveMediaSearch Create(string db, string language, ICognitiveSearchContext searcher)
        {
            var r = Create();
            r.Database = db;
            r.Language = language;
            r.Tags = searcher.GetTags(language, db);

            return r;
        }
        
        public virtual ICognitiveMediaSearchJsonResult CreateMediaSearchJsonResult(ISitecoreDataService dataService, ICognitiveSearchResult searchResult)
        {
            var obj = Provider.GetService<ICognitiveMediaSearchJsonResult>();
            
            MediaItem m = dataService.GetItemByUri(searchResult.UniqueId);

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