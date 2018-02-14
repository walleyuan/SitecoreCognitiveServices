using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Feature.OleChat.Statics;

namespace SitecoreCognitiveServices.Feature.OleChat.Intents
{
    public class VersionIntent : BaseOleIntent
    {
        protected readonly HttpContextBase Context;

        public override string Name => "version";

        public override string Description => Translator.Text("Chat.Intents.Version.Name");

        public override bool RequiresConfirmation => false;

        public VersionIntent(
            HttpContextBase context,
            IIntentOptionSetFactory optionSetFactory,
            IConversationResponseFactory responseFactory,
            IOleSettings settings) : base(optionSetFactory, responseFactory, settings) {
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
            
            return ConversationResponseFactory.Create(string.Format(Translator.Text("Chat.Intents.Version.Response"), major, minor, revision));
        }
    }
}