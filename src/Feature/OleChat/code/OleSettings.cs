using System;

namespace SitecoreCognitiveServices.Feature.OleChat {
    public class OleSettings : IOleSettings
    {
        public virtual Guid OleApplicationId => new Guid(Sitecore.Configuration.Settings.GetSetting("CognitiveService.OleApplicationId"));
    }
}