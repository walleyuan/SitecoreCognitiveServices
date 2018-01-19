using System;
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Shell.Applications.WebEdit.Commands;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web;
using Sitecore.Web.UI.Sheer;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Commands
{
    [Serializable]
    public class WebEditCognitiveImageSearch : WebEditImageCommand
    {
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
            Assert.ArgumentNotNull(args, "args");
            
            if (args.IsPostBack)
            {
                if (!args.HasResult || args.Result.Equals(string.Empty))
                    return;

                string controlIdParam = args.Parameters["controlid"];

                var imgValue = $"<image mediaid=\"{args.Result}\" />";

                SheerResponse.SetAttribute("scHtmlValue", "value", RenderImage(args, imgValue));
                SheerResponse.SetAttribute("scPlainValue", "value", imgValue);
                SheerResponse.Eval($"scSetHtmlValue('{controlIdParam}')");
                
                return;
            }

            string langParam = args.Parameters["language"];
            if (string.IsNullOrEmpty(langParam))
                langParam = WebUtil.GetQueryString("la");

            SheerResponse.ShowModalDialog("/SitecoreCognitiveServices/CognitiveImageSearch/SearchForm?src=FieldEditor&lang=" + langParam + "&db=" + Client.ContentDatabase.Name, "1000px", "600px", string.Empty, true);
            args.WaitForPostBack();
        }
    }
}