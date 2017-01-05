using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public interface IVisionService
    {
        Description GetDescription(MediaItem mediaItem);
        void SetImageAlt(MediaItem mediaItem);
    }
}