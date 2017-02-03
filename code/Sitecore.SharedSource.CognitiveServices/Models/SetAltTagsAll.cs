
namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public class SetAltTagsAll : ISetAltTagsAll
    {
        public int ItemCount { get; set; }
        public int ItemsModified { get; set; }
        public string Database { get; set; }
        public string Language { get; set; }
        public string ItemId { get; set; }
    }
}