using System;

namespace Sitecore.SharedSource.CognitiveServices {
    public class OleSettings : IOleSettings
    {
        public virtual Guid OleApplicationId => new Guid(Sitecore.Configuration.Settings.GetSetting("CognitiveService.OleApplicationId"));
    }
}