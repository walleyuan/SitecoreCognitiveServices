using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Moderator {
    public interface IContentModeratorRepository
    {
        string Evaluate(string imageUrl);
    }
}