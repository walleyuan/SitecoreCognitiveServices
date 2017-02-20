using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.ContentModerator.Contract.Image;
using Microsoft.CognitiveServices.ContentModerator.Contract.Text;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Moderator {
    public class ContentModeratorRepository : TextClient, IContentModeratorRepository
    {
        protected static readonly string moderatorUrl = "https://westus.api.cognitive.microsoft.com/contentmoderator/moderate/v1.0";

        public ContentModeratorRepository(
            IApiKeys apiKeys)
            : base(apiKeys.ContentModerator)
        {
        }        
    }
}