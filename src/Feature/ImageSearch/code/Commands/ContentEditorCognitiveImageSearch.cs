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
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Sheer;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Commands
{
    [Serializable]
    public class ContentEditorCognitiveImageSearch : Command
    {
        public override void Execute(CommandContext context)
        {
            Context.ClientPage.Start((object)this, "Run", context.Parameters);
        }
        
        protected static void Run(ClientPipelineArgs args)
        {
            Assert.ArgumentNotNull(args, "args");

            var fieldId = args.Parameters["id"];
            var fieldInfo = (FieldInfo) ((Hashtable) args.Properties["Info"])[fieldId];

            if (!args.IsPostBack)
            {
                SheerResponse.ShowModalDialog("/SitecoreCognitiveServices/CognitiveImageSearch/SearchForm?src=FieldEditor&lang=" + fieldInfo.Language + "&db=" + Client.ContentDatabase.Name, "1000px", "600px", string.Empty, true);
                args.WaitForPostBack();

                return;
            }

            if (!args.HasResult || args.Result.Equals(string.Empty))
                return;

            MediaItem m = Sitecore.Configuration.Factory.GetDatabase(Client.ContentDatabase.Name).GetItem(args.Result);
            if (m == null)
                return;
                
            SheerResponse.SetAttribute(fieldId, "value", m.MediaPath);
            SheerResponse.SetAttribute($"{fieldId}_image", "src", MediaManager.GetThumbnailUrl(m));
            var details = $"<div>Dimensions: {m.InnerItem["Width"]} x {m.InnerItem["Height"]}</div><div style=\"padding: 2px 0px 0px 0px\">Default Alternate Text: \"{m.Alt}\"</div>";
            SheerResponse.SetInnerHtml($"{fieldId}_details", details);
            SheerResponse.Eval("scContent.startValidators();");
            SheerResponse.SetModified(true);
        }
        
        public override CommandState QueryState(CommandContext context)
        {
            return CommandState.Enabled;
        }
    }
}