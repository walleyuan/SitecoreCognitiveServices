using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents {

    public interface IVersionIntent : IIntent { }

    public class VersionIntent : BaseIntent, IVersionIntent 
    {
        protected readonly ITextTranslatorWrapper Translator;
        protected readonly HttpContextBase Context;

        public override string Name => "version";

        public override string Description => "Provide my version information";

        public VersionIntent(
            ITextTranslatorWrapper translator,
            HttpContextBase context,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(optionSetFactory, responseFactory, settings) {
            Translator = translator;
            Context = context;
        }

        public override ConversationResponse Respond(LuisResult result, ItemContextParameters parameters, IConversation conversation) {

            var path = Context.Server.MapPath("~/sitecore/shell/sitecore.version.xml");
            if (!File.Exists(path))
                return ConversationResponseFactory.Create(string.Empty);

            string xmlText = File.ReadAllText(path);
            XDocument xdoc = XDocument.Parse(xmlText);

            var version = xdoc.Descendants("version").First();
            var major = version.Descendants("major").First().Value;
            var minor = version.Descendants("minor").First().Value;
            var revision = version.Descendants("revision").First().Value;
            
            return ConversationResponseFactory.Create($"My version is {major}.{minor} rev {revision}");
        }
    }
}