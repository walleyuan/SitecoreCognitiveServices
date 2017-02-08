using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Search;
using Sitecore.SharedSource.CognitiveServices.Factories;

namespace Sitecore.SharedSource.CognitiveServices.Controllers
{
    public class CognitiveMediaSearchController : Controller
    {
        protected readonly ICognitiveSearchContext Searcher;
        protected readonly ISitecoreDataService DataService;
        protected readonly ICognitiveSearchResultSetFactory ResultSetFactory;
        
        public CognitiveMediaSearchController(
            ICognitiveSearchContext searcher,
            ISitecoreDataService dataService,
            ICognitiveSearchResultSetFactory rsFactory)
        {
            Assert.IsNotNull(searcher, typeof(ICognitiveSearchContext));
            Assert.IsNotNull(dataService, typeof(ISitecoreDataService));
            Assert.IsNotNull(rsFactory, typeof(ICognitiveSearchResultSetFactory));

            Searcher = searcher;
            DataService = dataService;
            ResultSetFactory = rsFactory;
        }
        
        public ActionResult RTESearch(string query, string language, string db)
        {
            List<ICognitiveSearchResult> csr = Searcher.GetMediaResults(query, language, db);
            var resultSet = ResultSetFactory.Create(csr);

            return View("RTESearch", resultSet);
        }
    }
}