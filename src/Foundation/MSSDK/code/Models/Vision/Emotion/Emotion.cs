using MicrosoftCognitiveServices.Foundation.MSSDK.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Vision.Emotion {
    public class Emotion {
        public Rectangle FaceRectangle { get; set; }

        public Scores Scores { get; set; }

        public override bool Equals(object o) {
            if (o == null)
                return false;
            Emotion emotion = o as Emotion;
            if (emotion == null)
                return false;
            if (this.FaceRectangle == null) {
                if (emotion.FaceRectangle != null)
                    return false;
            } else if (!this.FaceRectangle.Equals((object)emotion.FaceRectangle))
                return false;
            if (this.Scores == null)
                return emotion.Scores == null;
            return this.Scores.Equals((object)emotion.Scores);
        }

        public override int GetHashCode() {
            return (this.FaceRectangle == null ? 858993459 : this.FaceRectangle.GetHashCode()) ^ (this.Scores == null ? 214748364 : this.Scores.GetHashCode());
        }
    }
}
