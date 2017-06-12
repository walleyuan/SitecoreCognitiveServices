using System;
using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using Sitecore.SharedSource.CognitiveServices.Controllers;
using Sitecore.SharedSource.CognitiveServices.Factories;
using Sitecore.SharedSource.CognitiveServices.Services.Search;
using Sitecore.SharedSource.CognitiveServices.Wrappers;

namespace Sitecore.SharedSource.CognitiveServices.Tests.Controllers
{
    [TestFixture]
    public class CognitiveAnalysisControllerTests
    {
        private ISearchService SearchService;
        private ICognitiveImageAnalysisFactory ImageAnalysisFactory;
        private ICognitiveTextAnalysisFactory TextAnalysisFactory;
        private IReanalyzeAllFactory ReanalyzeAllFactory;
        private ISitecoreDataWrapper DataWrapper;

        [SetUp]
        public void Setup()
        {
            SearchService = Substitute.For<ISearchService>();
            ImageAnalysisFactory = Substitute.For<ICognitiveImageAnalysisFactory>();
            TextAnalysisFactory = Substitute.For<ICognitiveTextAnalysisFactory>();
            ReanalyzeAllFactory = Substitute.For<IReanalyzeAllFactory>();
            DataWrapper = Substitute.For<ISitecoreDataWrapper>();
        }

        [Test]
        public void Constructor_NullParameters_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => new CognitiveAnalysisController(null, ImageAnalysisFactory, TextAnalysisFactory, ReanalyzeAllFactory, DataWrapper));
            Assert.Throws<InvalidOperationException>(() => new CognitiveAnalysisController(SearchService, null, TextAnalysisFactory, ReanalyzeAllFactory, DataWrapper));
            Assert.Throws<InvalidOperationException>(() => new CognitiveAnalysisController(SearchService, ImageAnalysisFactory, null, ReanalyzeAllFactory, DataWrapper));
            Assert.Throws<InvalidOperationException>(() => new CognitiveAnalysisController(SearchService, ImageAnalysisFactory, TextAnalysisFactory, null, DataWrapper));
            Assert.Throws<InvalidOperationException>(() => new CognitiveAnalysisController(SearchService, ImageAnalysisFactory, TextAnalysisFactory, ReanalyzeAllFactory, null));
        }

        [Test]
        public void ID_Empty_Returns_NullModel()
        {
            //arrange
            CognitiveAnalysisController controller = new CognitiveAnalysisController(SearchService, ImageAnalysisFactory, TextAnalysisFactory, ReanalyzeAllFactory, DataWrapper);

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
            CognitiveAnalysisController controller = new CognitiveAnalysisController(SearchService, ImageAnalysisFactory, TextAnalysisFactory, ReanalyzeAllFactory, DataWrapper);

            //act
            var result = controller.Reanalyze(string.Empty, "en", "master") as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Model);
        }
    }
}
