using System;

namespace SitecoreCognitiveServices.Feature.OleChat {
    public interface IOleSettings {
        Guid OleApplicationId { get; }
        string MasterDatabase { get; }
        string DictionaryDomain { get; }
    }
}