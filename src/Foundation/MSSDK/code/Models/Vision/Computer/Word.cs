using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Common;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Computer
{
    public class Word
    {
        public string BoundingBox { get; set; }
        public string Text { get; set; }
        public Rectangle Rectangle => Rectangle.FromString(BoundingBox);
    }
}
