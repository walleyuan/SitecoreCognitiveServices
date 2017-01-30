using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using Sitecore.Data;
using Sitecore.SharedSource.CognitiveServices.Controllers.Modals;
using Sitecore.SharedSource.CognitiveServices.Factories;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Search;

namespace Sitecore.SharedSource.CognitiveServices.Tests.Controllers
{
    [TestFixture]
    public class CognitiveAnalysisModalControllerTests
    {
        private IWebUtilWrapper WebUtil;
        private ICognitiveSearchContext Searcher;
        private ICognitiveImageAnalysisFactory ImageAnalysisFactory;
        private ICognitiveTextAnalysisFactory TextAnalysisFactory;
        private ISitecoreDataService DataService;

        [SetUp]
        public void Setup()
        {
            WebUtil = Substitute.For<IWebUtilWrapper>();
            Searcher = Substitute.For<ICognitiveSearchContext>();
            ImageAnalysisFactory = Substitute.For<ICognitiveImageAnalysisFactory>();
            TextAnalysisFactory = Substitute.For<ICognitiveTextAnalysisFactory>();
            DataService = Substitute.For<ISitecoreDataService>();
        }

        [Test]
        public void Constructor_NullParameters_Throws()
        {
            Assert.Throws<InvalidOperationException>(() => new CognitiveAnalysisModalController(null, Searcher, ImageAnalysisFactory, TextAnalysisFactory, DataService));
            Assert.Throws<InvalidOperationException>(() => new CognitiveAnalysisModalController(WebUtil, null, ImageAnalysisFactory, TextAnalysisFactory,DataService));
            Assert.Throws<InvalidOperationException>(() => new CognitiveAnalysisModalController(WebUtil, Searcher, null, TextAnalysisFactory, DataService));
            Assert.Throws<InvalidOperationException>(() => new CognitiveAnalysisModalController(WebUtil, Searcher, ImageAnalysisFactory, null, DataService));
            Assert.Throws<InvalidOperationException>(() => new CognitiveAnalysisModalController(WebUtil, Searcher, ImageAnalysisFactory, TextAnalysisFactory, null));
        }

        [Test]
        public void ID_Empty_Returns_NullModel()
        {
            //arrange
            WebUtil.GetQueryString("id", string.Empty).Returns(string.Empty);
            WebUtil.GetQueryString("lang", "en").Returns("en");
            WebUtil.GetQueryString("db", "master").Returns("master");

            CognitiveAnalysisModalController controller = new CognitiveAnalysisModalController(WebUtil, Searcher, ImageAnalysisFactory, TextAnalysisFactory, DataService);

            //act
            var result = controller.Reanalyze() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Model);
        }

        [Test]
        public void ValidID_Returns_NoChoices()
        {
            //arrange
            WebUtil.GetQueryString("id", string.Empty).Returns(string.Empty);
            WebUtil.GetQueryString("lang", "en").Returns("en");
            WebUtil.GetQueryString("db", "master").Returns("master");

            CognitiveAnalysisModalController controller = new CognitiveAnalysisModalController(WebUtil, Searcher, ImageAnalysisFactory, TextAnalysisFactory, DataService);

            //act
            var result = controller.Reanalyze() as ViewResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.Model);
        }
    }
}
