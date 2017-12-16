
namespace SitecoreCognitiveServices.Feature.ImageSearch.Models.Utility
{
    public class SetAltTagsAll : ISetAltTagsAll
    {
        public string ItemId { get; set; }
        public string Database { get; set; }
        public string Language { get; set; }
        public int ItemCount { get; set; }
        public int ItemsModified { get; set; }
        public int Threshold { get; set; }
        public bool Overwrite { get; set; }
    }
}