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
    public class Reanalyze : Command
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
            string langCode = args.Parameters["language"];
            
            UrlString urlString = new UrlString($"/sccogsvcs/CognitiveAnalysisModal/Reanalyze?id={idValue}&lang={langCode}");
            SheerResponse.ShowModalDialog(urlString.ToString(), "810", "500", "", true);
            args.WaitForPostBack();
        }

        public override CommandState QueryState(CommandContext context)
        {
            return CommandState.Enabled;
        }
    }
}