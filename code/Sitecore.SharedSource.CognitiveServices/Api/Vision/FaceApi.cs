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

namespace Sitecore.SharedSource.CognitiveServices.Api.Vision
{
    public class FaceApi : FaceServiceClient, IFaceApi
    {
        public FaceApi(IApiKeys apiKeys) : base(apiKeys.Face)
        {
        }
    }
}
