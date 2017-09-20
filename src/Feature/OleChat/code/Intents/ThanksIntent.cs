using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public interface IThanksIntent : IIntent { }

    public class ThanksIntent : BaseIntent, IThanksIntent
    {
        protected readonly ITextTranslatorWrapper Translator;

        public override string Name => "thanks";

        public override string Description => "";

        public ThanksIntent(
            ITextTranslatorWrapper translator,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(optionSetFactory, responseFactory, settings)
        {
            Translator = translator;
        }

        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            List<string> responses = new List<string>()
            {
                "You're welcome!",
                "It's what I do.",
                "I'm happy to help.",
                "You're too kind.",
                "I aim to please",
                "Anything for you.",
                "If I had a heart, it'd be touched."
            };

            return ConversationResponseFactory.Create(responses[new Random().Next(0, responses.Count)]);
        }
    }
}