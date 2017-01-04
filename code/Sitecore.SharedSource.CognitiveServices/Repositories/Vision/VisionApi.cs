using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.SecurityModel;
using Sitecore.SharedSource.CognitiveServices.Services;

namespace Sitecore.SharedSource.CognitiveServices.Repository.Vision
{
    public class VisionApi : VisionServiceClient, IVisionApi
    {
        public VisionApi(IApiKeys apiKeys) : base(apiKeys.ComputerVision)
        {
        }
    }
}
