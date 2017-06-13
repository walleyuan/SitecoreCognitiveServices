using Sitecore.Text;
using System;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Commands;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Commands
{
    [Serializable]
    public class ViewAnalysis : BaseCommand
    {
        public override void Execute(CommandContext context)
        {
            Item ctxItem = DataWrapper.ExtractItem(context);
            if (ctxItem == null)
                return;

            context.Parameters.Add(idParam, ctxItem.ID.ToString());
            context.Parameters.Add(heightParam, DataWrapper.GetFieldDimension(ctxItem, "height", 500, 60));
            context.Parameters.Add(widthParam, DataWrapper.GetFieldDimension(ctxItem, "width", 810, 41));
            
            Sitecore.Context.ClientPage.Start(this, "Run", context.Parameters);
        }

        public virtual void Run(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
                return;

            string id = args.Parameters[idParam];
            string db = Sitecore.Context.ContentDatabase.Name;
            Item i = DataWrapper.GetItemByIdValue(id, db);
            string langCode = i.Language.Name;
            string height = args.Parameters[heightParam];
            string width = args.Parameters[widthParam];

            ModalDialogOptions mdo = new ModalDialogOptions($"/SitecoreCognitiveServices/CognitiveImageSearch/ImageAnalysis?id={id}&language={langCode}&db={db}")
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
            Item ctxItem = DataWrapper?.ExtractItem(context);

            return (ctxItem != null && DataWrapper.IsMediaFile(ctxItem))
                ? CommandState.Enabled
                : CommandState.Hidden;
        }
    }
}