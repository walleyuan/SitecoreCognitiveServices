using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Models;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language
{
    public class LinguisticRepository : TextClient, ILinguisticRepository
    {
        public static readonly string textAnalysisUrl = "https://westus.api.cognitive.microsoft.com/linguistics/v1.0/analyze";

        public LinguisticRepository(
            IApiKeys apiKeys)
            : base(apiKeys.LinguisticAnalysis)
        {
        }
        
        public POSTagsTextAnalysisResponse GetPOSTagsTextAnalysis(TextAnalysisRequest request)
        {
            return Task.Run(async () => await GetPOSTagsTextAnalysisAsync(request)).Result;
        }

        /// <summary>
        /// kind: POSTags
        /// specification: PennTreebank3
        /// implementation: cmm
        /// </summary>
        public async Task<POSTagsTextAnalysisResponse> GetPOSTagsTextAnalysisAsync(TextAnalysisRequest request)
        {
            request.AnalyzerIds = new string[] { "4fa79af1-f22c-408d-98bb-b7d7aeef7f04" };
            return JsonConvert.DeserializeObject<List<POSTagsTextAnalysisResponse>>(await this.SendPostAsync(textAnalysisUrl, JsonConvert.SerializeObject((object)request))).First();
        }
        
        public ConstituencyTreeTextAnalysisResponse GetConstituencyTreeTextAnalysis(TextAnalysisRequest request)
        {
            return Task.Run(async () => await GetConstituencyTreeTextAnalysisAsync(request)).Result;
        }

        /// <summary>
        /// kind: ConstituencyTree
        /// specification: PennTreebank3
        /// implementation: SplitMerge
        /// </summary>
        public async Task<ConstituencyTreeTextAnalysisResponse> GetConstituencyTreeTextAnalysisAsync(TextAnalysisRequest request)
        {
            request.AnalyzerIds = new string[] { "22a6b758-420f-4745-8a3c-46835a67c0d2" };
            return JsonConvert.DeserializeObject<List<ConstituencyTreeTextAnalysisResponse>>(await this.SendPostAsync(textAnalysisUrl, JsonConvert.SerializeObject((object)request))).First();
        }
        
        public TokensTextAnalysisResponse GetTokensTextAnalysis(TextAnalysisRequest request)
        {
            return Task.Run(async () => await GetTokensTextAnalysisAsync(request)).Result;
        }

        /// <summary>
        /// specification: PennTreebank3
        /// implementation: regexes
        /// </summary>
        public async Task<TokensTextAnalysisResponse> GetTokensTextAnalysisAsync(TextAnalysisRequest request)
        {
            request.AnalyzerIds = new string[] { "08ea174b-bfdb-4e64-987e-602f85da7f72" };
            return JsonConvert.DeserializeObject<List<TokensTextAnalysisResponse>>(await this.SendPostAsync(textAnalysisUrl, JsonConvert.SerializeObject((object)request))).First();
        }
    }
}
