using Sitecore.Diagnostics;
using Sitecore.Text;
using System;
using System.Linq;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Shell.Applications.Dialogs.ProgressBoxes;
using Sitecore.Web.UI.Sheer;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Commands
{
    [Serializable]
    public class ViewAnalysis : Command
    {
        private static readonly string paramName = "idValue";

        public override void Execute(CommandContext context)
        {
            if (context == null)
                return;

            if (context.Items.Any())
                context.Parameters.Add(paramName, context.Items[0].ID.ToString());

            Sitecore.Context.ClientPage.Start(this, "Run", context.Parameters);
        }

        protected static void Run(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
                return;

            string idValue = args.Parameters[paramName];
            string langCode = Sitecore.Context.Language.Name;
            string db = Sitecore.Context.ContentDatabase.Name;
            Item i = Sitecore.Context.ContentDatabase.GetItem(idValue);

            string action = (i.Paths.IsMediaItem) ? "ImageAnalysis" : "TextAnalysis";

            UrlString urlString = new UrlString($"/sccogsvcs/CognitiveAnalysisModal/{action}?id={idValue}&lang={langCode}&db={db}");
            SheerResponse.ShowModalDialog(urlString.ToString(), "810", "500", "", true);
            args.WaitForPostBack();
        }

        public override CommandState QueryState(CommandContext context)
        {
            return CommandState.Enabled;
        }
    }
}