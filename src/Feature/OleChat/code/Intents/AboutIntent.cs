using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public class AboutIntent : BaseOleIntent
    {
        protected readonly ITextTranslatorWrapper Translator;
        protected readonly IServiceProvider Provider;
        
        public override string Name => "about";

        public override string Description => "Tell you about my abilities";

        public override bool RequiresConfirmation => false;

        public AboutIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IServiceProvider provider) : base(optionSetFactory, responseFactory, settings) {
            Translator = translator;
            Provider = provider;
        }
        
        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            var intents = Provider.GetServices<IOleIntent>()
                .Where(g => g.ApplicationId.Equals(ApplicationId) && !g.Description.Equals(""));
                
            var list = intents.Select(i => $"<li>{i.Description}</li>");

            var str = string.Join("", list);

            return ConversationResponseFactory.Create($"Here's the list of things I can do: <br/><ul>{str}</ul>");
        }
    }
}