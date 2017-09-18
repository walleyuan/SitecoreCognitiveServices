using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Video
{
    public class MotionDetectionAnalysis
    {
        public int Version { get; set; }
        public int Timescale { get; set; }
        public int Offset { get; set; }
        public int Framerate { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<MotionDetectionRegion> Regions { get; set; }
        public List<MotionDetectionFragment> Fragments { get; set; }
    }
}