using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;
using Sitecore.SharedSource.CognitiveServices.OleChat.Factories;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents {

    public interface IAboutIntent : IIntent { }

    public class AboutIntent : BaseIntent, IAboutIntent
    {
        protected readonly ITextTranslatorWrapper Translator;
        protected readonly IServiceProvider Provider;
        
        public override string Name => "about";

        public override string Description => "Tell you about my abilities";

        public AboutIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings,
            IServiceProvider provider) : base(settings) {
            Translator = translator;
            Provider = provider;
        }
        
        public override ConversationResponse ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            var intents = Provider.GetServices<IIntentFactory<IIntent>>()
                .Select(a => a.Create())
                .Where(g => g.ApplicationId.Equals(ApplicationId) && !g.Description.Equals(""));
                
            var list = intents.Select(i => $"<li>{i.Description}</li>");

            var str = string.Join("", list);

            return CreateConversationResponse($"Here's the list of things I can do: <br/><ul>{str}</ul>");
        }
    }
}