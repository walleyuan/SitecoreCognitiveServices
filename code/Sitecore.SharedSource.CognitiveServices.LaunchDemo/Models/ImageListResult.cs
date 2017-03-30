using System.Collections.Generic;
using Microsoft.SharedSource.CognitiveServices.Models.Vision.ContentModerator;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models
{
    public class ImageListResult
    {
        public AddImageResponse Image { get; set; }
        public GetImagesResponse Images { get; set; }
        public ListDetails List { get; set; }
        public List<ListDetails> Lists { get; set; }
    }
}