using System.Collections.Generic;
using Microsoft.ProjectOxford.EntityLinking.Contract;
using NUnit.Framework;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Language;

namespace Sitecore.SharedSource.CognitiveServices.Tests.Models
{
    [TestFixture]
    public class LinkAnalysisResultTests
    {
        private ILinkAnalysisResult _LinkAnalysisResult;

        [SetUp]
        public void Setup()
        {
            _LinkAnalysisResult = new LinkAnalysisResult();
            _LinkAnalysisResult.FieldValue = "first 1st second 2nd third 3rd";
            _LinkAnalysisResult.EntityAnalysis = new EntityLink[3];
            _LinkAnalysisResult.EntityAnalysis[0] = BuildEntityLink("first", "1st", 0.1D);
            _LinkAnalysisResult.EntityAnalysis[1] = BuildEntityLink("second", "2nd", 0.2D);
            _LinkAnalysisResult.EntityAnalysis[2] = BuildEntityLink("third", "3rd", 0.3D);
        }

        protected EntityLink BuildEntityLink(string value1, string value2, double score)
        {
            var m1 = new Match() {Text = value1};
            var m2 = new Match() {Text = value2};
            var link = new EntityLink();
            link.Matches = new List<Match>();
            link.Matches.Add(m1);
            link.Matches.Add(m2);
            link.Score = score;

            return link;
        }

        [Test]
        public void HighlightLinks_With_2_Returns_ModifiedMarkup()
        {
            //arrange
            //act
            string result = _LinkAnalysisResult.HighlightLinks("span", "someClass", 0.2D);

            //assert
            Assert.AreEqual("first 1st <span class=\"someClass\">second</span> <span class=\"someClass\">2nd</span> <span class=\"someClass\">third</span> <span class=\"someClass\">3rd</span>", result);
        }

        [Test]
        public void HighlightLinks_With_3_Returns_ModifiedMarkup()
        {
            //arrange
            //act
            string result = _LinkAnalysisResult.HighlightLinks("span", "someClass", 0.3D);

            //assert
            Assert.AreEqual("first 1st second 2nd <span class=\"someClass\">third</span> <span class=\"someClass\">3rd</span>", result);
        }
    }
}
