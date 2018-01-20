using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Web.UI.Sheer;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Fields
{
    public class ImageSearch : Sitecore.Shell.Applications.ContentEditor.Image
    {
        public ImageSearch() : base() { }
        
        public override void HandleMessage(Message message)
        {
            Assert.ArgumentNotNull(message, "message");

            if (message["id"] != ID)
                return;

            if (message.Name.Equals("cognitiveimagesearch:browse"))
                BrowseCognitive();
            else
                base.HandleMessage(message);
        }

        protected void BrowseCognitive()
        {
            if (!Disabled)
                Sitecore.Context.ClientPage.Start(this, "BrowseCognitiveImage");
        }

        protected void BrowseCognitiveImage(ClientPipelineArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (!args.IsPostBack)
            {
                Language language = Language.Parse(this.ItemLanguage);
                SheerResponse.ShowModalDialog("/SitecoreCognitiveServices/CognitiveImageSearch/SearchForm?src=FieldEditor&lang=" + language.Name + "&db=" + Client.ContentDatabase.Name, "1000px", "600px", string.Empty, true);
                args.WaitForPostBack();

                return;
            }

            if (!args.HasResult || string.IsNullOrEmpty(args.Result) || args.Result == "undefined")
                return;

            MediaItem mediaItem = Client.ContentDatabase.Items[args.Result];
            if (mediaItem == null)
            {
                SheerResponse.Alert("Item not found.");
                return;
            }

            TemplateItem template = mediaItem.InnerItem.Template;
            if (template != null && !IsImageMedia(template))
            {
                SheerResponse.Alert("The selected item does not contain an image.");
                return;
            }

            XmlValue.SetAttribute("mediaid", mediaItem.ID.ToString());
            Value = mediaItem.MediaPath;
            Update();
            SetModified();
        }
        
        protected bool IsImageMedia(TemplateItem template)
        {
            Assert.ArgumentNotNull(template, "template");
            if (template.ID == TemplateIDs.VersionedImage || template.ID == TemplateIDs.UnversionedImage)
                return true;

            foreach (TemplateItem baseTemplate in template.BaseTemplates)
            {
                if (IsImageMedia(baseTemplate))
                    return true;
            }

            return false;
        }
    }
}