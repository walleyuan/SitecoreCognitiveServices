using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.Models.Common {
    public class Rectangle {
        public int Left { get; set; }

        public int Top { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public override bool Equals(object o) {
            if (o == null)
                return false;
            Rectangle rectangle = o as Rectangle;
            if (rectangle == null || this.Left != rectangle.Left || (this.Top != rectangle.Top || this.Width != rectangle.Width))
                return false;
            return this.Height == rectangle.Height;
        }

        public override int GetHashCode() {
            int num1 = this.Left;
            int hashCode1 = num1.GetHashCode();
            num1 = this.Top;
            int hashCode2 = num1.GetHashCode();
            int num2 = hashCode1 ^ hashCode2;
            num1 = this.Width;
            int hashCode3 = num1.GetHashCode();
            int num3 = num2 ^ hashCode3;
            num1 = this.Height;
            int hashCode4 = num1.GetHashCode();
            return num3 ^ hashCode4;
        }

        public static Rectangle FromString(string @string) {
            if (!string.IsNullOrWhiteSpace(@string)) {
                string[] strArray = @string.Split(',');
                int result1;
                int result2;
                int result3;
                int result4;
                if (strArray.Length == 4 && int.TryParse(strArray[0], out result1) && (int.TryParse(strArray[1], out result2) && int.TryParse(strArray[2], out result3)) && int.TryParse(strArray[3], out result4))
                    return new Rectangle() {
                        Left = result1,
                        Height = result4,
                        Top = result2,
                        Width = result3
                    };
            }
            return (Rectangle)null;
        }
    }
}
