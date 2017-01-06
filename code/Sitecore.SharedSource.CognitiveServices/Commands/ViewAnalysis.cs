using Sitecore.Diagnostics;
using Sitecore.Text;
using System;
using Sitecore.Shell.Framework.Commands;

namespace Sitecore.SharedSource.CognitiveServices.Commands
{
    [Serializable]
    public class ViewAnalysis : Command
    {
        public override void Execute(CommandContext context)
        {
            UrlString urlString = new UrlString();
            urlString.Append("en", context.Items[0].ID.ToString());
            Sitecore.Shell.Framework.Windows.RunApplication("Security/Security Editor", urlString.ToString());
        }

        public override CommandState QueryState(CommandContext context)
        {
            Error.AssertObject((object)context, "context");
            if (Context.Database.Items["/sitecore/content/Applications/Security/SecurityEditor"] == null)
                return CommandState.Hidden;
            return base.QueryState(context);
        }
    }
}