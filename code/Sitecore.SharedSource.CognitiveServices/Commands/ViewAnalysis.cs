using Sitecore.Text;
using System;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Commands
{
    [Serializable]
    public class ViewAnalysis : BaseCommand
    {
        public override void Execute(CommandContext context)
        {
            Item ctxItem = DataService.ExtractItem(context);
            if (ctxItem == null)
                return;

            context.Parameters.Add(idParam, ctxItem.ID.ToString());
            context.Parameters.Add(heightParam, DataService.GetFieldDimension(ctxItem, "height", 500, 56));
            context.Parameters.Add(widthParam, DataService.GetFieldDimension(ctxItem, "width", 810, 20));
            
            Sitecore.Context.ClientPage.Start(this, "Run", context.Parameters);
        }

        protected void Run(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
                return;

            string id = args.Parameters[idParam];
            string db = Sitecore.Context.ContentDatabase.Name;
            Item i = DataService.GetItemByIdValue(id, db);
            string langCode = i.Language.Name;
            string height = args.Parameters[heightParam];
            string width = args.Parameters[widthParam];
            string action = (i.Paths.IsMediaItem) ? "ImageAnalysis" : "TextAnalysis";

            ModalDialogOptions mdo = new ModalDialogOptions($"/SitecoreCognitiveServices/CognitiveAnalysis/{action}?id={id}&language={langCode}&db={db}")
            {
                Header = "Cognitive Analysis",
                Height = height,
                Width = width,
                Message = "View the cognitive analysis of the current item",
                Response = true
            };
            SheerResponse.ShowModalDialog(mdo);
            args.WaitForPostBack();
        }

        public override CommandState QueryState(CommandContext context)
        {
            Item ctxItem = DataService?.ExtractItem(context);

            return (ctxItem != null && (DataService.IsMediaItem(ctxItem) || ctxItem.Paths.IsContentItem))
                ? CommandState.Enabled
                : CommandState.Hidden;
        }
    }
}