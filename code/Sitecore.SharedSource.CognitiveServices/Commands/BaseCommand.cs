using Sitecore.Text;
using System;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Foundation;

namespace Sitecore.SharedSource.CognitiveServices.Commands
{
    [Serializable]
    public class BaseCommand : Command
    {
        protected static readonly string idParam = "idValue";
        protected static readonly string heightParam = "heightValue";
        protected static readonly string widthParam = "widthValue";
        protected static readonly string languageParam = "language";

        protected readonly ISitecoreDataService DataService;

        public BaseCommand()
        {
            DataService = DependencyResolver.Current.GetService<ISitecoreDataService>();
        }

        public override void Execute(CommandContext context) { }
    }
}