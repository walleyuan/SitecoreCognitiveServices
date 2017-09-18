using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Language.Linguistic;

namespace SitecoreCognitiveServices.Project.LaunchDemo.Models {
    public class LinguisticAnalysisResult : ILinguisticAnalysisResult
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }

        /// <summary>
        /// Parts of Speech Tags. See: https://www.microsoft.com/cognitive-services/en-us/Linguistic-Analysis-API/documentation/POS-tagging
        /// </summary>
        public POSTagsTextAnalysisResponse POSTagsAnalysis { get; set; }

        /// <summary>
        /// Constituency Parsing. See: https://www.microsoft.com/cognitive-services/en-us/Linguistic-Analysis-API/documentation/Constituency-Parsing
        /// </summary>
        public ConstituencyTreeTextAnalysisResponse ConstituencyTreeAnalysis { get; set; }

        /// <summary>
        /// Sentence Tokenization. See: https://www.microsoft.com/cognitive-services/en-us/Linguistic-Analysis-API/documentation/Sentences-and-Tokens
        /// </summary>
        public TokensTextAnalysisResponse TokensAnalysis { get; set; }

        public string HighlightPOSTags(string htmlEntity, string cssClass)
        {
            string[] strArr = FieldValue.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int i = 0;

            foreach (string[] r in POSTagsAnalysis.Result)
            {
                foreach (string s in r)
                {
                    //don't overreach the array
                    if (i >= strArr.Length)
                        break;
                    
                    if (PunctuationAndSymbols.Contains(s))
                        continue;
                    
                    string element = GetSentenceFragment(s);
                    Match m = Regex.Match(strArr[i], @"([a-zA-Z&-/\\]+)");
                    if(!string.IsNullOrEmpty(m.Value))
                        strArr[i] = strArr[i].Replace(m.Value, $"<{htmlEntity} class=\"{cssClass}\" title=\"{element}\">{m.Value}</{htmlEntity}>");

                    i++;
                }
            }

            return strArr.Aggregate((a, b) => $"{a} {b}");
        }

        public string HighlightConstituencyTree(string htmlEntity, string cssClass)
        {
            string[] strArr = FieldValue.Split(new [] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int i = 0;

            foreach (string r in ConstituencyTreeAnalysis.Result)
            {
                MatchCollection mc = Regex.Matches(r, @"([a-zA-Z]+[ ]{1}[a-zA-Z]+)");
                foreach (Match m in mc)
                {
                    //don't overreach the array
                    if (i >= strArr.Length)
                        break;

                    string[] parts = m.Value.Split(new [] {" "}, StringSplitOptions.RemoveEmptyEntries);
                    
                    //check that it's a 2 part array 
                    if (parts.Length < 2)
                        continue;

                    //make sure the ~words~ lines up
                    while (i < strArr.Length && !strArr[i].Contains(parts[1]))
                    {
                        i++;
                    }

                    if (i >= strArr.Length)
                        break;

                    string element = GetSentenceFragment(parts[0]);
                    strArr[i] = strArr[i].Replace(parts[1], $"<{htmlEntity} class=\"{cssClass}\" title=\"{element}\">{parts[1]}</{htmlEntity}>");

                    i++;
                }
            }
            
            return strArr.Aggregate((a,b) => $"{a} {b}");
        }

        public string HighlightTokens(string htmlEntity, string cssClass)
        {
            string s = FieldValue;

            return s;
        }

        public string GetSentenceFragment(string key)
        {
            return (PartsOfSpeech.ContainsKey(key))
                ? PartsOfSpeech[key]
                : "unknown";
        }
        
        protected List<string> PunctuationAndSymbols = new List<string>()
        {
            ".", ",", "?", "!", ":", "'", "\"", ";", "[", "]", "\\", "/", ">", "<", "{", "}", "|", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "-", "+", "="
        };

        protected Dictionary<string, string> PartsOfSpeech = new Dictionary<string, string>()
        {
            {"CC", "Coordinating conjunction"},
            {"CD", "Cardinal number"},
            {"DT", "Determiner"},
            {"EX", "Existential there"},
            {"FW", "Foreign word"},
            {"IN", "Preposition or subordinating conjunction"},
            {"JJ", "Adjective"},
            {"JJR", "Adjective, comparative"},
            {"JJS", "Adjective, superlative"},
            {"LS", "List item marker"},
            {"MD", "Modal"},
            {"NN", "Noun, singular or mass"},
            {"NNS", "Noun, plural"},
            {"NNP", "Proper noun, singular"},
            {"NNPS", "Proper noun, plural"},
            {"PDT", "Predeterminer"},
            {"POS", "Possessive ending"},
            {"PRP", "Personal pronoun"},
            {"PRP$", "Possessive pronoun"},
            {"RB", "Adverb"},
            {"RBR", "Adverb, comparative"},
            {"RBS", "Adverb, superlative"},
            {"RP", "Particle"},
            {"SYM", "Symbol"},
            {"TO", "to"},
            {"UH", "Interjection"},
            {"VB", "Verb, base form"},
            {"VBD", "Verb, past tense"},
            {"VBG", "Verb, gerund or present participle"},
            {"VBN", "Verb, past participle"},
            {"VBP", "Verb, non-3rd person singular present"},
            {"VBZ", "Verb, 3rd person singular present"},
            {"WDT", "Wh-determiner"},
            {"WP", "Wh-pronoun"},
            {"WP$", "Possessive wh-pronoun"},
            {"WRB", "Wh-adverb"},
        };
    }
}