using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.Data.Templates;
using Sitecore.Diagnostics;
using Sitecore.Resources.Media;
using Sitecore.Shell.Applications.ContentManager;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Text;
using Sitecore.Web;
using Sitecore.Web.UI.Sheer;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Commands
{
    [Serializable]
    public class ContentEditorCognitiveImageSearch : Command
    {
        public override void Execute(CommandContext context)
        {
            string fieldid = context.Parameters["id"];
            if (string.IsNullOrEmpty(fieldid))
                return;

            NameValueCollection nv = new NameValueCollection();
            nv.Add("fieldid", fieldid);
            
            Context.ClientPage.Start((object)this, "Run", context.Parameters);
        }
        
        protected static void Run(ClientPipelineArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            if (args.IsPostBack)
            {
                if (args.Result.Equals(string.Empty))
                    return;

                MediaItem m = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(args.Result);
                if (m == null)
                    return;

                string fieldId = args.Parameters["id"];

                SheerResponse.Eval($"scForm.browser.getControl('{fieldId}').focus();");
                SheerResponse.Eval($"scForm.browser.getControl('{fieldId}').value = '{m.MediaPath}';");
                SheerResponse.Eval($"scForm.browser.getControl('{fieldId}').blur();");
                SheerResponse.Eval($"scForm.browser.getControl('{fieldId}_image').src = '{MediaManager.GetMediaUrl(m)}';");
                var details = $"<div>Dimensions: {m.InnerItem["Width"]} x {m.InnerItem["Height"]}</div><div style=\"padding: 2px 0px 0px 0px\">Default Alternate Text: \"{m.Alt}\"</div>";
                SheerResponse.Eval($"scForm.browser.getControl('{fieldId}_details').update('{details}');");
                var itemId = ((FieldInfo)((Hashtable)args.Properties["Info"])[fieldId]).ItemID.Guid.ToString("N").ToUpper();
                SheerResponse.Eval("top._scDialogs[0].modified = true;");
                SheerResponse.Eval($"scForm.modifiedItems['{itemId}'] = true;");
                SheerResponse.Eval("scForm.modified = true;");

                return;
            }

            string langParam = args.Parameters["language"];
            if (string.IsNullOrEmpty(langParam))
                langParam = WebUtil.GetQueryString("la");
            if (string.IsNullOrEmpty(langParam))
                langParam = "en";

            SheerResponse.ShowModalDialog("/SitecoreCognitiveServices/CognitiveImageSearch/SearchForm?src=FieldEditor&lang=" + langParam + "&db=" + Client.ContentDatabase.Name, "1000px", "600px", string.Empty, true);
            args.WaitForPostBack();
        }

        public override string GetClick(CommandContext context, string click)
        {
            Assert.ArgumentNotNull((object)context, "context");
            Assert.ArgumentNotNull((object)click, "click");
            return "cognitive:contenteditorimagesearch(id=" + context.Parameters["FieldID"] + ")";
        }

        public override CommandState QueryState(CommandContext context)
        {
            return CommandState.Enabled;
        }

        private static Item GetImageItem(CommandContext context)
        {
            Assert.ArgumentNotNull((object)context, "context");
            string parameter = context.Parameters["FieldID"];
            if (string.IsNullOrEmpty(parameter))
                return (Item)null;
            Item obj = context.Items[0];
            ImageField field = (ImageField)obj.Fields[parameter];
            if (field == null)
                return (Item)null;
            return obj.Database.GetItem(field.MediaID);
        }
    }
}