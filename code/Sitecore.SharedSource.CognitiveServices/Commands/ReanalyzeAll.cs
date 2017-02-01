using Sitecore.Text;
using System;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Commands
{
    [Serializable]
    public class ReanalyzeAll : BaseCommand
    {
        public override void Execute(CommandContext context)
        {
            Item ctxItem = DataService.ExtractItem(context);
            if (ctxItem == null)
                return;

            context.Parameters.Add(idParam, ctxItem.ID.ToString());
            
            Sitecore.Context.ClientPage.Start(this, "Run", context.Parameters);
        }
        
        protected static void Run(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
                return;

            string id = args.Parameters[idParam];
            string langCode = args.Parameters[languageParam];
            string db = Sitecore.Context.ContentDatabase.Name;

            UrlString urlString = new UrlString($"/sccogsvcs/CognitiveAnalysis/ViewReanalyzeAll?id={id}&language={langCode}&db={db}");
            SheerResponse.ShowModalDialog(urlString.ToString(), "400", "250", "", true);
            args.WaitForPostBack();
        }

        public override CommandState QueryState(CommandContext context)
        {
            Item ctxItem = DataService?.ExtractItem(context);
            
            return (ctxItem != null && ctxItem.ID.Guid.Equals(Sitecore.TemplateIDs.MediaFolder.Guid))
                ? CommandState.Enabled
                : CommandState.Hidden;
        }
    }
}