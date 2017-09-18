using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Feature.OleChat.Factories;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents {

    public interface ILogoutIntent : IIntent { }

    public class LogoutIntent : BaseIntent, ILogoutIntent
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
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(settings, responseFactory) {
            Translator = translator;
            Context = context;
            AuthenticationWrapper = authWrapper;
        }

        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            AuthenticationWrapper.Logout();
            
            var responseCookies = Context.Response.Cookies;
            var cookie = responseCookies["sitecore_userticket"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-1);
                cookie.Value = null;
            }

            return ConversationResponseFactory.Create("You have been logged out.", "logout");
        }
    }
}