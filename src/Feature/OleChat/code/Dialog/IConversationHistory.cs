using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Feature.OleChat.Dialog
{
    public interface IConversationHistory
    {
        IList<IConversation> Conversations { get; }
    }
}