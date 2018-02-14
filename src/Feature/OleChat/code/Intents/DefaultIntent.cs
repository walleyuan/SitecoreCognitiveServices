﻿using System;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public class DefaultIntent : BaseOleIntent
    {
        protected readonly ITextTranslatorWrapper Translator;
        
        public override string Name => "none";

        public override string Description => "";

        public override bool RequiresConfirmation => false;

        public DefaultIntent(
            ITextTranslatorWrapper translator,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(optionSetFactory, responseFactory, settings) {
            Translator = translator;
        }
        
        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            return ConversationResponseFactory.Create("Sorry, can you try again? I didn't quite understand you.");
        }
    }
}