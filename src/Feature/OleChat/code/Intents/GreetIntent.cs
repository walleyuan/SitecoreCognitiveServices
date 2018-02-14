using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public class GreetIntent : BaseOleIntent
    {
        protected readonly ITextTranslatorWrapper Translator;
        protected readonly IAuthenticationWrapper AuthenticationWrapper;

        public override string Name => "greet";

        public override string Description => "Greet a user";

        public GreetIntent(
            ITextTranslatorWrapper translator,
            IAuthenticationWrapper authWrapper,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(optionSetFactory, responseFactory, settings) {
            Translator = translator;
            AuthenticationWrapper = authWrapper;
        }

        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            string fullName = AuthenticationWrapper.GetCurrentUser().Profile.FullName;

            List<string> responses = new List<string>()
            {
                $"Hi {fullName}, how can I help you?",
                "What's up?",
                "What can I do for you?",
                "Hey.",
                "Hi.",
                "Can I help you with something?"
            };

            return ConversationResponseFactory.Create(responses[new Random().Next(0, responses.Count)]);
        }
    }
}