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

            if (context.Items.Count() > 0)
                context.Parameters.Add(paramName, context.Items[0].ID.ToString());

            Sitecore.Context.ClientPage.Start(this, "Run", context.Parameters);
        }

        protected static void Run(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
                return;

            string idValue = args.Parameters[paramName];
            string langCode = args.Parameters["language"];
            Item i = Sitecore.Context.ContentDatabase.GetItem(idValue);

            string action = (i.Paths.IsMediaItem) ? "ImageAnalysis" : "TextAnalysis";

            UrlString urlString = new UrlString($"/sccogsvcs/CognitiveAnalysisModal/{action}?id={idValue}&lang={langCode}");
            SheerResponse.ShowModalDialog(urlString.ToString(), "810", "290", "", true);
            args.WaitForPostBack();
        }

        public override CommandState QueryState(CommandContext context)
        {
            return CommandState.Enabled;
        }

        public void Refresh(params object[] parameters)
        {
            // Do Stuff
        }
    }
}