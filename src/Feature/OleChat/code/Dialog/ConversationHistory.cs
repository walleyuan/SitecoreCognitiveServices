using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Dialog
{
    public class ConversationHistory : IConversationHistory
    {
        protected readonly HttpContextBase Context;
        protected static readonly string SessionKey = "olechat-conversationhistory";

        public ConversationHistory(HttpContextBase context)
        {
            Context = context;
        }

        public virtual IList<IConversation> Conversations
        {
            get
            {
                if (Context?.Session[SessionKey] == null)
                    Context.Session[SessionKey] = new List<IConversation>();

                return (IList<IConversation>)Context.Session[SessionKey];
            }
        }
    }
}