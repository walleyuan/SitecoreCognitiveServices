using System.Collections.Generic;
using NUnit.Framework;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Analysis;
using Microsoft.SharedSource.CognitiveServices.Models.Language;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Linguistic;

namespace Sitecore.SharedSource.CognitiveServices.Tests.Models
{
    [TestFixture]
    public class LinguisticAnalysisResultTests
    {
        private ILinguisticAnalysisResult _LinguisticAnalysisResult;

        [SetUp]
        public void Setup()
        {
            _LinguisticAnalysisResult = new LinguisticAnalysisResult();
            _LinguisticAnalysisResult.FieldValue = "Home";
            _LinguisticAnalysisResult.POSTagsAnalysis = new POSTagsTextAnalysisResponse()
            {
                Result = new List<string[]>() { new[] { "NNP" } }
            };
            _LinguisticAnalysisResult.ConstituencyTreeAnalysis = new ConstituencyTreeTextAnalysisResponse()
            {
                Result = new[] {"(NNP (NNP Home))"}
            };
        }

        [Test]
        public void HighlightPOSTags_Returns_ModifiedMarkup()
        {
            //arrange
            //act
            string result = _LinguisticAnalysisResult.HighlightPOSTags("span", "someClass");

            //assert
            Assert.AreEqual("<span class=\"someClass\" title=\"Proper noun, singular\">Home</span>", result);
        }

        [Test]
        public void HighlightConstituencyTree_Returns_ModifiedMarkup()
        {
            //arrange
            //act
            string result = _LinguisticAnalysisResult.HighlightConstituencyTree("span", "someClass");

            //assert
            Assert.AreEqual("<span class=\"someClass\" title=\"Proper noun, singular\">Home</span>", result);
        }

        [Test]
        public void HighlightTokens_Returns_UnmodifiedMarkup()
        {
            //arrange
            //act
            string result = _LinguisticAnalysisResult.HighlightTokens("span", "someClass");

            //assert
            Assert.AreEqual("Home", result);
        }
    }
}
