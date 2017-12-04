using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Linguistic;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Language
{
    public class LinguisticRepository : ILinguisticRepository
    {
        public static readonly string textAnalysisUrl = "analyze";

        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMicrosoftCognitiveServicesRepositoryClient RepositoryClient;

        public LinguisticRepository(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMicrosoftCognitiveServicesRepositoryClient repoClient) {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }

        protected enum AnalyzerType { PartsOfSpeech, ConstituencyTree, Token }
        protected readonly Dictionary<AnalyzerType, string> AnalyzerIds = new Dictionary<AnalyzerType, string>()
        {
            { AnalyzerType.PartsOfSpeech, "4fa79af1-f22c-408d-98bb-b7d7aeef7f04" },
            { AnalyzerType.ConstituencyTree, "22a6b758-420f-4745-8a3c-46835a67c0d2" },
            { AnalyzerType.Token, "08ea174b-bfdb-4e64-987e-602f85da7f72" }
        };

        public virtual POSTagsTextAnalysisResponse GetPOSTagsTextAnalysis(TextAnalysisRequest request)
        {
            request.AnalyzerIds = new[] { AnalyzerIds[AnalyzerType.PartsOfSpeech] };
            var response = RepositoryClient.SendJsonPost(ApiKeys.LinguisticAnalysis, $"{ApiKeys.LinguisticAnalysisEndpoint}{textAnalysisUrl}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<List<POSTagsTextAnalysisResponse>>(response).First();
        }

        /// <summary>
        /// kind: POSTags
        /// specification: PennTreebank3
        /// implementation: cmm
        /// </summary>
        public virtual async Task<POSTagsTextAnalysisResponse> GetPOSTagsTextAnalysisAsync(TextAnalysisRequest request)
        {
            request.AnalyzerIds = new [] { AnalyzerIds[AnalyzerType.PartsOfSpeech] };
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.LinguisticAnalysis, $"{ApiKeys.LinguisticAnalysisEndpoint}{textAnalysisUrl}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<List<POSTagsTextAnalysisResponse>>(response).First();
        }
        
        public virtual ConstituencyTreeTextAnalysisResponse GetConstituencyTreeTextAnalysis(TextAnalysisRequest request)
        {
            request.AnalyzerIds = new[] { AnalyzerIds[AnalyzerType.ConstituencyTree] };
            var response = RepositoryClient.SendJsonPost(ApiKeys.LinguisticAnalysis, $"{ApiKeys.LinguisticAnalysisEndpoint}{textAnalysisUrl}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<List<ConstituencyTreeTextAnalysisResponse>>(response).First();
        }

        /// <summary>
        /// kind: ConstituencyTree
        /// specification: PennTreebank3
        /// implementation: SplitMerge
        /// </summary>
        public virtual async Task<ConstituencyTreeTextAnalysisResponse> GetConstituencyTreeTextAnalysisAsync(TextAnalysisRequest request)
        {
            request.AnalyzerIds = new [] { AnalyzerIds[AnalyzerType.ConstituencyTree] };
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.LinguisticAnalysis, $"{ApiKeys.LinguisticAnalysisEndpoint}{textAnalysisUrl}", JsonConvert.SerializeObject(request));
            
            return JsonConvert.DeserializeObject<List<ConstituencyTreeTextAnalysisResponse>>(response).First();
        }
        
        public virtual TokensTextAnalysisResponse GetTokensTextAnalysis(TextAnalysisRequest request)
        {
            request.AnalyzerIds = new[] { AnalyzerIds[AnalyzerType.Token] };
            var response = RepositoryClient.SendJsonPost(ApiKeys.LinguisticAnalysis, $"{ApiKeys.LinguisticAnalysisEndpoint}{textAnalysisUrl}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<List<TokensTextAnalysisResponse>>(response).First();
        }

        /// <summary>
        /// specification: PennTreebank3
        /// implementation: regexes
        /// </summary>
        public virtual async Task<TokensTextAnalysisResponse> GetTokensTextAnalysisAsync(TextAnalysisRequest request)
        {
            request.AnalyzerIds = new [] { AnalyzerIds[AnalyzerType.Token] };
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.LinguisticAnalysis, $"{ApiKeys.LinguisticAnalysisEndpoint}{textAnalysisUrl}", JsonConvert.SerializeObject(request));

            return JsonConvert.DeserializeObject<List<TokensTextAnalysisResponse>>(response).First();
        }
    }
}
