using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis.Connector;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Dialog
{
    public interface IConversationService
    {
        string HandleMessage(Activity activity, ItemContextParameters parameters);
    }
}