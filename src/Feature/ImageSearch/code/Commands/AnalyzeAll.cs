using Sitecore.Text;
using System;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.SCSDK.Commands;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Commands
{
    [Serializable]
    public class AnalyzeAll : BaseImageSearchCommand
    {
        public virtual void Run(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
                return;

            string id = args.Parameters[idParam];
            string db = Sitecore.Context.ContentDatabase.Name;
            Item i = DataWrapper.GetItemByIdValue(id, db);
            string langCode = i.Language.Name;
            
            ModalDialogOptions mdo = new ModalDialogOptions($"/SitecoreCognitiveServices/CognitiveImageSearch/ViewAnalyzeAll?id={id}&language={langCode}&db={db}")
            {
                Header = "Analyze Descendants",
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
            Item ctxItem = DataWrapper?.ExtractItem(context);
            
            return (ctxItem != null && DataWrapper.IsMediaFolder(ctxItem))
                ? CommandState.Enabled
                : CommandState.Hidden;
        }
    }
}