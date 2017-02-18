using NUnit.Framework;
using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Tests.Models
{
    [TestFixture]
    public class KeyPhraseAnalysisResultTests
    {
        private IKeyPhraseAnalysisResult _KeyPhraseAnalysisResult;

        [SetUp]
        public void Setup()
        {
            _KeyPhraseAnalysisResult = new KeyPhraseAnalysisResult();
            _KeyPhraseAnalysisResult.FieldValue = "one two three";
            _KeyPhraseAnalysisResult.KeyPhraseAnalysis = new SentimentDocumentResult();
            _KeyPhraseAnalysisResult.KeyPhraseAnalysis.KeyPhrases = new[] { "one", "two", "three" };
        }

        [Test]
        public void HighlightPhrases_Returns_ModifiedMarkup()
        {
            //arrange
            //act
            string result = _KeyPhraseAnalysisResult.HighlightPhrases("span", "someClass");

            //assert
            Assert.AreEqual("<span class=\"someClass\">one</span> <span class=\"someClass\">two</span> <span class=\"someClass\">three</span>", result);
        }
    }
}
