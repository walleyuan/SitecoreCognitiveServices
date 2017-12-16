using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Video
{
    public class FaceFragment
    {
        public int Start { get; set; }
        public int Duration { get; set; }
        public int Interval { get; set; }
        public List<List<FragmentLocation>> Events { get; set; }
    }
}