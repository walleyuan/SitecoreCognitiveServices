using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Video
{
    public class MotionDetectionRegion
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<XYPoint> Points { get; set; }
    }
}