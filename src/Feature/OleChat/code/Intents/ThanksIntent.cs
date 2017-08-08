﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;
using Sitecore.SharedSource.CognitiveServices.Wrappers;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents
{
    public interface IThanksIntent : IIntent { }

    public class ThanksIntent : BaseIntent, IThanksIntent
    {
        protected readonly ITextTranslatorWrapper Translator;

        public override string Name => "thanks";

        public override string Description => "";

        public ThanksIntent(
            ITextTranslatorWrapper translator,
            IOleSettings settings) : base(settings)
        {
            Translator = translator;
        }

        public override string ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            List<string> responses = new List<string>()
            {
                "Your're welcome!",
                "It's what I do.",
                "I'm happy to help.",
                "You're too kind.",
                "I aim to please",
                "Anything for you.",
                "If I had a heart, it'd be touched."
            };

            return responses[new Random().Next(0, responses.Count)];
        }
    }
}