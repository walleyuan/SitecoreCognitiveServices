using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ClientServices.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.OleChat.Dialog;
using Sitecore.SharedSource.CognitiveServices.OleChat.Factories;
using Sitecore.SharedSource.CognitiveServices.OleChat.Models;
using Sitecore.SharedSource.CognitiveServices.Wrappers;

namespace Sitecore.SharedSource.CognitiveServices.OleChat.Intents
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
            IServiceProvider provider) : base(settings)
        {
            Translator = translator;
            Provider = provider;
        }

        public override string ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation)
        {
            return "Alright let's move on.";
        }
    }
}