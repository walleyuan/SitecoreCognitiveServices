using SitecoreCognitiveServices.Foundation.MSSDK.Models.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer {
    public class Region {
        public string BoundingBox { get; set; }

        public Line[] Lines { get; set; }

        [JsonIgnore]
        public Rectangle Rectangle => Rectangle.FromString(BoundingBox);
    }
}
