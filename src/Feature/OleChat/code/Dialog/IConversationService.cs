using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis.Connector;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Dialog
{
    public interface IConversationService
    {
        ConversationResponse HandleMessage(Activity activity, ItemContextParameters parameters);
    }
}