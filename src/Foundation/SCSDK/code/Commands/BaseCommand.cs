using System;
using System.Web.Mvc;
using Sitecore.Shell.Framework.Commands;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Foundation.SCSDK.Commands
{
    [Serializable]
    public class BaseCommand : Command
    {
        protected static readonly string idParam = "idValue";
        protected static readonly string heightParam = "heightValue";
        protected static readonly string widthParam = "widthValue";
        protected static readonly string languageParam = "language";

        protected readonly ISitecoreDataWrapper DataWrapper;

        public BaseCommand()
        {
            DataWrapper = DependencyResolver.Current.GetService<ISitecoreDataWrapper>();
        }

        public override void Execute(CommandContext context) { }
    }
}