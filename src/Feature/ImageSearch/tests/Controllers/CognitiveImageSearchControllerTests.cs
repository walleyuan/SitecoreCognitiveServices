using System;
using System.Web;
using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using SitecoreCognitiveServices.Feature.ImageSearch.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Controllers;
using SitecoreCognitiveServices.Feature.ImageSearch.Factories;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;
using SitecoreCognitiveServices.Feature.ImageSearch.Setup;
using SitecoreCognitiveServices.Foundation.MSSDK;

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
        protected IAnalysisJobResultFactory JobResultFactory;
        protected ISetupInformationFactory SetupInformationFactory;
        protected IImageSearchSettings ImageSearchSettings;
        protected ISetupService SetupService;

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
            SetupService = Substitute.For<ISetupService>();
        }

        [Test]
        public void Constructor_NullParameters_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(null, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, AnalyzeAllFactory, ImageAnalysisService, JobResultFactory, SetupInformationFactory, SetupService, ImageSearchSettings));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, null, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, AnalyzeAllFactory, ImageAnalysisService, JobResultFactory, SetupInformationFactory, SetupService, ImageSearchSettings));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, DataWrapper, null, MediaSearchFactory, SetAltTagsAllFactory, AnalyzeAllFactory, ImageAnalysisService, JobResultFactory, SetupInformationFactory, SetupService, ImageSearchSettings));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, null, SetAltTagsAllFactory, AnalyzeAllFactory, ImageAnalysisService, JobResultFactory, SetupInformationFactory, SetupService, ImageSearchSettings));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, MediaSearchFactory, null, AnalyzeAllFactory, ImageAnalysisService, JobResultFactory, SetupInformationFactory, SetupService, ImageSearchSettings));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, null, ImageAnalysisService, JobResultFactory, SetupInformationFactory, SetupService, ImageSearchSettings));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, AnalyzeAllFactory, null, JobResultFactory, SetupInformationFactory, SetupService, ImageSearchSettings));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, AnalyzeAllFactory, ImageAnalysisService, null, SetupInformationFactory, SetupService, ImageSearchSettings));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, AnalyzeAllFactory, ImageAnalysisService, JobResultFactory, null, SetupService, ImageSearchSettings));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, AnalyzeAllFactory, ImageAnalysisService, JobResultFactory, SetupInformationFactory, null, ImageSearchSettings));
            Assert.Throws<InvalidOperationException>(() => new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, AnalyzeAllFactory, ImageAnalysisService, JobResultFactory, SetupInformationFactory, SetupService, null));
        }

        [Test]
        public void ID_Empty_Returns_NullModel()
        {
            //arrange
            CognitiveImageSearchController controller = new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, AnalyzeAllFactory, ImageAnalysisService, JobResultFactory, SetupInformationFactory, SetupService, ImageSearchSettings);

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
            CognitiveImageSearchController controller = new CognitiveImageSearchController(SearchService, DataWrapper, WebUtil, MediaSearchFactory, SetAltTagsAllFactory, AnalyzeAllFactory, ImageAnalysisService, JobResultFactory, SetupInformationFactory, SetupService, ImageSearchSettings);

            //act
            var result = controller.Analyze(string.Empty, "en", "master") as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Model);
        }
    }
}
