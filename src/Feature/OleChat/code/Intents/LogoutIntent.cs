using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Models;

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
            IOleSettings settings) : base(settings) {
            Translator = translator;
            Context = context;
            AuthenticationWrapper = authWrapper;
        }

        public override ConversationResponse ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            AuthenticationWrapper.Logout();
            
            var responseCookies = Context.Response.Cookies;
            var cookie = responseCookies["sitecore_userticket"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-1);
                cookie.Value = null;
            }

            return new ConversationResponse{
                Message = "You have been logged out.",
                Action = new KeyValuePair<string, string>("logout", "")
            };
        }
    }
}