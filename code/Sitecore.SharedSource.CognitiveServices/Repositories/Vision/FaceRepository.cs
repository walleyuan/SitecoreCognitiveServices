using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Services;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision
{
    public class FaceRepository : FaceServiceClient, IFaceRepository
    {
        public IApiService ApiService;

        public FaceRepository(
            IApiKeys apiKeys,
            IApiService apiService) : base(apiKeys.Face)
        {
            ApiService = apiService;
        }
    }
}
