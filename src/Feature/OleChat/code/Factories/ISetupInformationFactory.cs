using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Factories
{
    public interface ISetupInformationFactory
    {
        ISetupInformation Create();
    }
}