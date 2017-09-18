using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.Security.Authentication;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;
using Sitecore.Web.Authentication;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {

    public interface ILogoutIntent : IIntent { }

    public class LogoutIntent : BaseIntent, ILogoutIntent
    {
        protected readonly ITextTranslatorWrapper Translator;
        
        public override string Name => "logout";

        public override string Description => "Logout the current user from Sitecore";
        
        public LogoutIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings) : base(settings) {
            Translator = translator;
        }

        public override ConversationResponse ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            AuthenticationManager.Logout();
            
            HttpCookieCollection ResponseCookies = HttpContext.Current.Response.Cookies;
            HttpCookie cookie = ResponseCookies["sitecore_userticket"];
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