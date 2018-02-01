using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.DependencyInjection;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public interface IQuitIntent : IIntent { }

    public class QuitIntent : BaseIntent, IQuitIntent
    {
        protected readonly ITextTranslatorWrapper Translator;
        protected readonly IServiceProvider Provider;

        public override string Name => "quit";

        public override string Description => "";

        public QuitIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IServiceProvider provider) : base(optionSetFactory, responseFactory, settings)
        {
            Translator = translator;
            Provider = provider;
        }

        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            return ConversationResponseFactory.Create("Alright let's move on.");
        }
    }
}