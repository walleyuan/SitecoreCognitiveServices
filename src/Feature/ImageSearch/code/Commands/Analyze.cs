using System;
using System.Web.Mvc;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using Sitecore.Data.Items;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Commands
{
    [Serializable]
    public class Analyze : BaseImageSearchCommand
    {
        public virtual void Run(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
                return;

            string id = args.Parameters[idParam];
            string db = Sitecore.Context.ContentDatabase.Name;
            Item i = DataWrapper.GetItemByIdValue(id, db);
            string langCode = i.Language.Name;
            
            ModalDialogOptions mdo = new ModalDialogOptions($"/SitecoreCognitiveServices/CognitiveImageSearch/Analyze?id={id}&language={langCode}&db={db}")
            {
                Header = "Cognitive Analysis",
                Height = DataWrapper.GetFieldDimension(i, "height", 500, 56),
                Width = DataWrapper.GetFieldDimension(i, "width", 810, 20),
                Message = "View the cognitive analysis of the current item",
                Response = true
            };
            SheerResponse.ShowModalDialog(mdo);
            args.WaitForPostBack();
        }

        public override CommandState QueryState(CommandContext context)
        {
            if(_settings.MissingKeys())
                return CommandState.Disabled;

            Item ctxItem = DataWrapper?.ExtractItem(context);
            if (ctxItem == null || !DataWrapper.IsMediaFile(ctxItem))
                return CommandState.Hidden;
            
            return _searchService
                .GetImageAnalysis(ctxItem.ID.ToString(), ctxItem.Language.Name, ctxItem.Database.Name)
                .HasNoAnalysis()
                ? CommandState.Enabled
                : CommandState.Hidden;
        }
    }
}