using Sitecore.Text;
using System;
using System.Linq;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using Sitecore.Data.Items;

namespace Sitecore.SharedSource.CognitiveServices.Commands
{
    [Serializable]
    public class ViewAnalysis : Command
    {
        private static readonly string idParam = "idValue";
        private static readonly string heightParam = "heightValue";
        private static readonly string widthParam = "widthValue";

        public override void Execute(CommandContext context)
        {
            if (context == null)
                return;

            if (context.Items.Any())
            {
                Item ctxItem = context.Items[0];
                context.Parameters.Add(idParam, ctxItem.ID.ToString());
                context.Parameters.Add(heightParam, GetFieldDimension(ctxItem, "height", 500, 100));
                context.Parameters.Add(widthParam, GetFieldDimension(ctxItem, "width", 810, 20));
            }

            Sitecore.Context.ClientPage.Start(this, "Run", context.Parameters);
        }

        protected static void Run(ClientPipelineArgs args)
        {
            if (args.IsPostBack)
                return;

            string id = args.Parameters[idParam];
            string height = args.Parameters[heightParam];
            string width = args.Parameters[widthParam];
            string langCode = Sitecore.Context.Language.Name;
            string db = Sitecore.Context.ContentDatabase.Name;
            Item i = Sitecore.Context.ContentDatabase.GetItem(id);

            string action = (i.Paths.IsMediaItem) ? "ImageAnalysis" : "TextAnalysis";

            UrlString urlString = new UrlString($"/sccogsvcs/CognitiveAnalysisModal/{action}?id={id}&lang={langCode}&db={db}");
            SheerResponse.ShowModalDialog(urlString.ToString(), width, height, "", true);
            args.WaitForPostBack();
        }

        public override CommandState QueryState(CommandContext context)
        {
            return CommandState.Enabled;
        }

        protected string GetFieldDimension(Item i, string fieldName, int minimum, int offset)
        {
            if (i.Fields[fieldName] == null)
                return minimum.ToString();

            int size = minimum;
            if (!int.TryParse(i[fieldName], out size))
                return minimum.ToString();

            return (size > minimum)
                ? (size + offset).ToString()
                : minimum.ToString();
        }
    }
}