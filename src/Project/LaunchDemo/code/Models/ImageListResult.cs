using System.Collections.Generic;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.ContentModerator;

namespace SitecoreCognitiveServices.Project.LaunchDemo.Models
{
    public class ImageListResult
    {
        public AddImageResponse Image { get; set; }
        public GetImagesResponse Images { get; set; }
        public ListDetails List { get; set; }
        public List<ListDetails> Lists { get; set; }
    }
}