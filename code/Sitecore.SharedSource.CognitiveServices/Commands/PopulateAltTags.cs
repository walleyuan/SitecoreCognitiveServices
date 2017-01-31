using Sitecore.Diagnostics;
using Sitecore.Text;
using System;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Shell.Applications.Dialogs.ProgressBoxes;
using Sitecore.Web.UI.Sheer;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Foundation;

namespace Sitecore.SharedSource.CognitiveServices.Commands
{
    [Serializable]
    public class PopulateAltTags : Command
    {
        private static readonly string idParam = "idValue";

        public override void Execute(CommandContext context)
        {
            if (context == null)
                return;

            if (!context.Items.Any())
                return;
            
            Item ctxItem = context.Items[0];
            context.Parameters.Add(idParam, ctxItem.ID.ToString());
            Sitecore.Context.ClientPage.Start(this, "Run", context.Parameters);
        }

        protected static void Run(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
                return;

            string id = args.Parameters[idParam];
            string langCode = Sitecore.Context.Language.Name;
            string db = Sitecore.Context.ContentDatabase.Name;
            Item i = Sitecore.Context.ContentDatabase.GetItem(id);

            UrlString urlString = new UrlString($"/sccogsvcs/CognitiveUtility/ViewImageDescription?id={id}&lang={langCode}&db={db}");
            SheerResponse.ShowModalDialog(urlString.ToString(), "400", "250", "", true);
            args.WaitForPostBack();
        }

        public override CommandState QueryState(CommandContext context)
        {
            var dataService = DependencyResolver.Current.GetService<ISitecoreDataService>();
            Item ctxItem = dataService?.ExtractItem(context);

            return (ctxItem != null && dataService.IsMediaItem(ctxItem))
                ? CommandState.Enabled
                : CommandState.Hidden;
        }
    }
}