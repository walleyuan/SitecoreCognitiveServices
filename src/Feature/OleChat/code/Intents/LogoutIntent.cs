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

namespace SitecoreCognitiveServices.Feature.OleChat.Intents {

    public interface ILogoutIntent : IOleIntent { }

    public class LogoutIntent : BaseOleIntent, ILogoutIntent
    {
        protected readonly ITextTranslatorWrapper Translator;
        protected readonly HttpContextBase Context;
        protected readonly IAuthenticationWrapper AuthenticationWrapper;

        public override string Name => "logout";

        public override string Description => "Logout the current user from Sitecore";
        
        public LogoutIntent(
            ITextTranslatorWrapper translator,
            HttpContextBase context,
            IAuthenticationWrapper authWrapper,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(optionSetFactory, responseFactory, settings) {
            Translator = translator;
            Context = context;
            AuthenticationWrapper = authWrapper;
        }

        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            return ConversationResponseFactory.Create("You have been logged out.", "logout");
        }
    }
}