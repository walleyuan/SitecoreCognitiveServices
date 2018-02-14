using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Statics;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public class LogoutIntent : BaseOleIntent
    {
        protected readonly HttpContextBase Context;
        protected readonly IAuthenticationWrapper AuthenticationWrapper;

        public override string Name => "logout";

        public override string Description => Translator.Text("Chat.Intents.Logout.Name");

        public override bool RequiresConfirmation => false;

        public LogoutIntent(
            HttpContextBase context,
            IAuthenticationWrapper authWrapper,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(optionSetFactory, responseFactory, settings) {
            Context = context;
            AuthenticationWrapper = authWrapper;
        }

        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            return ConversationResponseFactory.Create(Translator.Text("Chat.Intents.Logout.Response"), "logout");
        }
    }
}