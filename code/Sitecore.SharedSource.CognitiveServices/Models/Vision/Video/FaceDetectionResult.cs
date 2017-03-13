using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Models.Vision.Video
{
    public class FaceDetectionResult
    {
        public int Version { get; set; }
        public int Timescale { get; set; }
        public int Offset { get; set; }
        public int Framerate { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<FaceFragment> Fragments { get; set; }
        public List<FaceEntity> FacesDetected { get; set; }
    }
}