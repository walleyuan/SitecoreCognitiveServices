using System;
using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using SitecoreCognitiveServices.Feature.ImageSearch.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Controllers;
using SitecoreCognitiveServices.Feature.ImageSearch.Factories;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Tests.Controllers
{
    [TestFixture]
    public class CognitiveImageSearchControllerTests
    {
        protected IImageSearchService SearchService;
        protected ISitecoreDataWrapper DataWrapper;
        protected IWebUtilWrapper WebUtil;
        protected ICognitiveImageSearchFactory MediaSearchFactory;
        protected ISetAltTagsAllFactory SetAltTagsAllFactory;
        protected ICognitiveImageAnalysisFactory ImageAnalysisFactory;
        protected IAnalyzeAllFactory AnalyzeAllFactory;
        protected IImageAnalysisService ImageAnalysisService;

        [SetUp]
        public void Setup()
        {
            SearchService = Substitute.For<IImageSearchService>();
            DataWrapper = Substitute.For<ISitecoreDataWrapper>();
            WebUtil = Substitute.For<IWebUtilWrapper>();
            MediaSearchFactory = Substitute.For<ICognitiveImageSearchFactory>();
            SetAltTagsAllFactory = Substitute.For<ISetAltTagsAllFactory>();
            ImageAnalysisFactory = Substitute.For<ICognitiveImageAnalysisFactory>();
            AnalyzeAllFactory = Substitute.For<IAnalyzeAllFactory>();
        }

        [Test]
        public void Constructor_NullParameters_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(null, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, ImageAnalysisFactory, AnalyzeAllFactory, ImageAnalysisService));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, ImageAnalysisFactory, AnalyzeAllFactory, ImageAnalysisService));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, null, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, ImageAnalysisFactory, AnalyzeAllFactory, ImageAnalysisService));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, DataWrapper, null, MediaSearchFactory, SetAltTagsAllFactory, ImageAnalysisFactory, AnalyzeAllFactory, ImageAnalysisService));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, null, SetAltTagsAllFactory, ImageAnalysisFactory, AnalyzeAllFactory, ImageAnalysisService));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, MediaSearchFactory, null, ImageAnalysisFactory, AnalyzeAllFactory, ImageAnalysisService));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, null, AnalyzeAllFactory, ImageAnalysisService));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, ImageAnalysisFactory, null, ImageAnalysisService));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, ImageAnalysisFactory, AnalyzeAllFactory, null));
        }

        [Test]
        public void ID_Empty_Returns_NullModel()
        {
            //arrange
            CognitiveImageSearchController controller = new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, ImageAnalysisFactory, AnalyzeAllFactory, ImageAnalysisService);

            //act
            var result = controller.Analyze(string.Empty, "en", "master") as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Model);
        }

        [Test]
        public void ValidID_Returns_NoChoices()
        {
            //arrange
            CognitiveImageSearchController controller = new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, ImageAnalysisFactory, AnalyzeAllFactory, ImageAnalysisService);

            //act
            var result = controller.Analyze(string.Empty, "en", "master") as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Model);
        }
    }
}
