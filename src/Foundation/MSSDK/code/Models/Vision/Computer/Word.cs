﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharedSource.CognitiveServices.Models.Common;

namespace Microsoft.SharedSource.CognitiveServices.Models.Vision.Computer
{
    public class Word
    {
        public string BoundingBox { get; set; }
        public string Text { get; set; }
        public Rectangle Rectangle => Rectangle.FromString(BoundingBox);
    }
}
