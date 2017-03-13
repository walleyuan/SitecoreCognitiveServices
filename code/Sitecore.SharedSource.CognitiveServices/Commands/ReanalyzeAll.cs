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

        public virtual void Run(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
                return;

            string id = args.Parameters[idParam];
            string db = Sitecore.Context.ContentDatabase.Name;
            Item i = DataService.GetItemByIdValue(id, db);
            string langCode = i.Language.Name;
            
            ModalDialogOptions mdo = new ModalDialogOptions($"/SitecoreCognitiveServices/CognitiveAnalysis/ViewReanalyzeAll?id={id}&language={langCode}&db={db}")
            {
                Header = "Reanalyze Descendents",
                Height = "200",
                Width = "350",
                Message = "",
                Response = true
            };
            SheerResponse.ShowModalDialog(mdo);
            args.WaitForPostBack();
        }

        public override CommandState QueryState(CommandContext context)
        {
            Item ctxItem = DataService?.ExtractItem(context);
            
            return (ctxItem != null && (DataService.IsMediaFolder(ctxItem) || ctxItem.Paths.IsContentItem))
                ? CommandState.Enabled
                : CommandState.Hidden;
        }
    }
}