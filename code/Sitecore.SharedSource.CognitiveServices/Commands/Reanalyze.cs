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
                context.Parameters.Add(heightParam, GetFieldDimension(ctxItem, "height", 500));
                context.Parameters.Add(widthParam, GetFieldDimension(ctxItem, "width", 810));
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
            string langCode = args.Parameters["language"];
            
            UrlString urlString = new UrlString($"/sccogsvcs/CognitiveAnalysisModal/Reanalyze?id={id}&lang={langCode}");
            SheerResponse.ShowModalDialog(urlString.ToString(), width, height, "", true);
            args.WaitForPostBack();
        }

        public override CommandState QueryState(CommandContext context)
        {
            return CommandState.Enabled;
        }

        protected string GetFieldDimension(Item i, string fieldName, int minimum)
        {
            if (i.Fields[fieldName] == null)
                return minimum.ToString();
            
            int size = minimum;
            if (!int.TryParse(i[fieldName], out size))
                return minimum.ToString();
            
            return (size > minimum)
                ? size.ToString()
                : minimum.ToString();
        }
    }
}