using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Vision.Emotion {
    public class Scores {
        public float Anger { get; set; }

        public float Contempt { get; set; }

        public float Disgust { get; set; }

        public float Fear { get; set; }

        public float Happiness { get; set; }

        public float Neutral { get; set; }

        public float Sadness { get; set; }

        public float Surprise { get; set; }

        public IEnumerable<KeyValuePair<string, float>> ToRankedList() {
            return (IEnumerable<KeyValuePair<string, float>>)Enumerable.ToList<KeyValuePair<string, float>>((IEnumerable<KeyValuePair<string, float>>)Enumerable.ThenBy<KeyValuePair<string, float>, string>(Enumerable.OrderByDescending<KeyValuePair<string, float>, float>((IEnumerable<KeyValuePair<string, float>>)new Dictionary<string, float>()
            {
        {
          "Anger",
          this.Anger
        },
        {
          "Contempt",
          this.Contempt
        },
        {
          "Disgust",
          this.Disgust
        },
        {
          "Fear",
          this.Fear
        },
        {
          "Happiness",
          this.Happiness
        },
        {
          "Neutral",
          this.Neutral
        },
        {
          "Sadness",
          this.Sadness
        },
        {
          "Surprise",
          this.Surprise
        }
      }, (Func<KeyValuePair<string, float>, float>)(kv => kv.Value)), (Func<KeyValuePair<string, float>, string>)(kv => kv.Key)));
        }

        public override bool Equals(object o) {
            if (o == null)
                return false;
            Scores scores = o as Scores;
            if (scores == null || (double)this.Anger != (double)scores.Anger || ((double)this.Disgust != (double)scores.Disgust || (double)this.Fear != (double)scores.Fear) || ((double)this.Happiness != (double)scores.Happiness || (double)this.Neutral != (double)scores.Neutral || (double)this.Sadness != (double)scores.Sadness))
                return false;
            return (double)this.Surprise == (double)scores.Surprise;
        }

        public override int GetHashCode() {
            float num1 = this.Anger;
            int hashCode1 = num1.GetHashCode();
            num1 = this.Disgust;
            int hashCode2 = num1.GetHashCode();
            int num2 = hashCode1 ^ hashCode2;
            num1 = this.Fear;
            int hashCode3 = num1.GetHashCode();
            int num3 = num2 ^ hashCode3;
            num1 = this.Happiness;
            int hashCode4 = num1.GetHashCode();
            int num4 = num3 ^ hashCode4;
            num1 = this.Neutral;
            int hashCode5 = num1.GetHashCode();
            int num5 = num4 ^ hashCode5;
            num1 = this.Sadness;
            int hashCode6 = num1.GetHashCode();
            int num6 = num5 ^ hashCode6;
            num1 = this.Surprise;
            int hashCode7 = num1.GetHashCode();
            return num6 ^ hashCode7;
        }
    }
}
