﻿using System;
using System.Collections.Generic;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Feature.OleChat.Statics;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public class GreetIntent : BaseOleIntent
    {
        protected readonly IAuthenticationWrapper AuthenticationWrapper;

        public override string Name => "greet";

        public override string Description => Translator.Text("Chat.Intents.Greet.Name");

        public override bool RequiresConfirmation => false;

        public GreetIntent(
            IAuthenticationWrapper authWrapper,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(optionSetFactory, responseFactory, settings) {
            AuthenticationWrapper = authWrapper;
        }

        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            string fullName = AuthenticationWrapper.GetCurrentUser().Profile.FullName;

            List<string> responses = new List<string>()
            {
                string.Format(Translator.Text("Chat.Intents.Greet.1"), fullName),
                Translator.Text("Chat.Intents.Greet.2"),
                Translator.Text("Chat.Intents.Greet.3"),
                Translator.Text("Chat.Intents.Greet.4"),
                Translator.Text("Chat.Intents.Greet.5"),
                Translator.Text("Chat.Intents.Greet.6")
            };

            return ConversationResponseFactory.Create(responses[new Random().Next(0, responses.Count)]);
        }
    }
}