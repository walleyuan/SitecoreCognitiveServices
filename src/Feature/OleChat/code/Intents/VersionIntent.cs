using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
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
            IOleSettings settings) : base(settings) {
            Translator = translator;
            Context = context;
        }

        public override ConversationResponse ProcessResponse(LuisResult result, ItemContextParameters parameters, IConversation conversation) {

            var path = Context.Server.MapPath("~/sitecore/shell/sitecore.version.xml");
            if (!File.Exists(path))
                return CreateConversationResponse(string.Empty);

            string xmlText = File.ReadAllText(path);
            XDocument xdoc = XDocument.Parse(xmlText);

            var version = xdoc.Descendants("version").First();
            var major = version.Descendants("major").First().Value;
            var minor = version.Descendants("minor").First().Value;
            var revision = version.Descendants("revision").First().Value;
            
            return CreateConversationResponse($"My version is {major}.{minor} rev {revision}");
        }
    }
}