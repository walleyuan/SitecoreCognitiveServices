using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;

namespace Sitecore.SharedSource.CognitiveServices.Ole.Intents {
    public class VersionIntent : IIntent {
        public string Name => "version";

        public string Respond(ITextTranslator translator, QueryResult result, Dictionary<string, string> parameters) {

            var path = HttpContext.Current.Server.MapPath("~/sitecore/shell/sitecore.version.xml");
            if (!System.IO.File.Exists(path))
                return string.Empty;

            string xmlText = System.IO.File.ReadAllText(path);
            XDocument xdoc = XDocument.Parse(xmlText);

            var version = xdoc.Descendants("version").First();
            var major = version.Descendants("major").First().Value;
            var minor = version.Descendants("minor").First().Value;
            var revision = version.Descendants("revision").First().Value;

            return $"My version is {major}.{minor} rev {revision}";
        }
    }
}