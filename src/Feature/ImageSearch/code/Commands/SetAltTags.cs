using Sitecore.Text;
using System;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Foundation.SCSDK.Commands;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Commands
{
    [Serializable]
    public class SetAltTags : BaseImageSearchCommand
    {
        public virtual void Run(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
                return;

            string id = args.Parameters[idParam];
            string db = Sitecore.Context.ContentDatabase.Name;
            Item i = DataWrapper.GetItemByIdValue(id, db);
            string langCode = i.Language.Name;

            ModalDialogOptions mdo = new ModalDialogOptions($"/SitecoreCognitiveServices/CognitiveImageSearch/ViewImageDescription?id={id}&language={langCode}&db={db}")
            {
                Header = "Set Alt Tag",
                Height = "200",
                Width = "250",
                Message = "",
                Response = true
            };
            SheerResponse.ShowModalDialog(mdo);
            args.WaitForPostBack();
        }

        public override CommandState QueryState(CommandContext context)
        {
            if (_settings.MissingKeys())
                return CommandState.Disabled;

            Item ctxItem = DataWrapper?.ExtractItem(context);
            if (ctxItem == null || !DataWrapper.IsMediaFile(ctxItem))
                return CommandState.Hidden;
            
            return _searchService
                .GetImageAnalysis(ctxItem.ID.ToString(), ctxItem.Language.Name, ctxItem.Database.Name)
                .HasAnyAnalysis()
                ? CommandState.Enabled
                : CommandState.Hidden;
        }
    }
}