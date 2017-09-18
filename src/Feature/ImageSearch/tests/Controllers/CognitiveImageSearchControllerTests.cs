using System;
using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using SitecoreCognitiveServices.Feature.ImageSearch.Controllers;
using SitecoreCognitiveServices.Feature.ImageSearch.Factories;
using SitecoreCognitiveServices.Feature.ImageSearch.Services.Search;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Tests.Controllers
{
    [TestFixture]
    public class CognitiveImageSearchControllerTests
    {
        protected IImageSearchService SearchService;
        protected ICognitiveImageSearchContext Searcher;
        protected ISitecoreDataWrapper DataWrapper;
        protected IWebUtilWrapper WebUtil;
        protected ICognitiveImageSearchFactory MediaSearchFactory;
        protected ISetAltTagsAllFactory SetAltTagsAllFactory;
        protected ICognitiveImageAnalysisFactory ImageAnalysisFactory;
        protected IReanalyzeAllFactory ReanalyzeAllFactory;

        [SetUp]
        public void Setup()
        {
            SearchService = Substitute.For<IImageSearchService>();
            Searcher = Substitute.For<ICognitiveImageSearchContext>();
            DataWrapper = Substitute.For<ISitecoreDataWrapper>();
            WebUtil = Substitute.For<IWebUtilWrapper>();
            MediaSearchFactory = Substitute.For<ICognitiveImageSearchFactory>();
            SetAltTagsAllFactory = Substitute.For<ISetAltTagsAllFactory>();
            ImageAnalysisFactory = Substitute.For<ICognitiveImageAnalysisFactory>();
            ReanalyzeAllFactory = Substitute.For<IReanalyzeAllFactory>();
        }

        [Test]
        public void Constructor_NullParameters_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(null, Searcher, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, ImageAnalysisFactory, ReanalyzeAllFactory));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, null, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, ImageAnalysisFactory, ReanalyzeAllFactory));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, Searcher, null, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, ImageAnalysisFactory, ReanalyzeAllFactory));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, Searcher, DataWrapper, null, MediaSearchFactory, SetAltTagsAllFactory, ImageAnalysisFactory, ReanalyzeAllFactory));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, Searcher, DataWrapper, WebUtil, null, SetAltTagsAllFactory, ImageAnalysisFactory, ReanalyzeAllFactory));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, Searcher, DataWrapper, WebUtil, MediaSearchFactory, null, ImageAnalysisFactory, ReanalyzeAllFactory));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, Searcher, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, null, ReanalyzeAllFactory));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, Searcher, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, ImageAnalysisFactory, null));
        }

        [Test]
        public void ID_Empty_Returns_NullModel()
        {
            //arrange
            CognitiveImageSearchController controller = new CognitiveImageSearchController(SearchService, Searcher, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, ImageAnalysisFactory, ReanalyzeAllFactory);

            //act
            var result = controller.Reanalyze(string.Empty, "en", "master") as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Model);
        }

        [Test]
        public void ValidID_Returns_NoChoices()
        {
            //arrange
            CognitiveImageSearchController controller = new CognitiveImageSearchController(SearchService, Searcher, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, ImageAnalysisFactory, ReanalyzeAllFactory);

            //act
            var result = controller.Reanalyze(string.Empty, "en", "master") as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Model);
        }
    }
}
