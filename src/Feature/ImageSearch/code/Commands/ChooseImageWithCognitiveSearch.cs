using System;
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Shell.Applications.WebEdit.Commands;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web;
using Sitecore.Web.UI.Sheer;

// Original location: (Sitecore.Shell.Applications.WebEdit.Commands.ChooseImage, Sitecore.ExperienceEditor)
namespace SitecoreCognitiveServices.Feature.ImageSearch.Commands
{
    [Serializable]
    public class ChooseImageWithCognitiveSearch : WebEditImageCommand
    {
        private static Language ContentLanguage
        {
            get
            {
                Language result;
                if (!Language.TryParse(Context.Request.QueryString["la"], out result))
                    result = Context.ContentLanguage;
                return result;
            }
        }

        public override void Execute(CommandContext context)
        {
            Assert.ArgumentNotNull((object)context, "context");
            WebEditCommand.ExplodeParameters(context);
            string formValue = WebUtil.GetFormValue("scPlainValue");
            context.Parameters.Add("fieldValue", formValue);
            Context.ClientPage.Start((object)this, "Run", context.Parameters);
        }

        protected static void Run(ClientPipelineArgs args)
        {
            Assert.ArgumentNotNull((object)args, "args");
            string langParam = args.Parameters["language"];
            Language language = string.IsNullOrEmpty(langParam) ? ContentLanguage : Language.Parse(langParam);
            string controlIdParam = args.Parameters["controlid"];
            
            if (args.IsPostBack)
            {
                if (args.Result.Equals(string.Empty))
                    return;

                var imgValue = $"<image mediaid=\"{args.Result}\" />";

                SheerResponse.SetAttribute("scHtmlValue", "value", RenderImage(args, imgValue));
                SheerResponse.SetAttribute("scPlainValue", "value", imgValue);
                SheerResponse.Eval($"scSetHtmlValue('{controlIdParam}')");
                
                return;
            }

            SheerResponse.ShowModalDialog("/SitecoreCognitiveServices/CognitiveImageSearch/SearchForm?src=FieldEditor&lang=" + language + "&db=" + Client.ContentDatabase.Name, "1000px", "600px", string.Empty, true);
            args.WaitForPostBack();
        }
    }
    public static class ClientPipelineArgsExtensions { 

        public static string GetArg(this ClientPipelineArgs args, string paramName)
        {
            return args.Parameters[paramName];
        }
    }
}