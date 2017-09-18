using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic.FileIO;

namespace MicrosoftCognitiveServices.Foundation.MSSDK.CSV {
    public class CSVParser : ICSVParser {
        public List<List<string>> ParseCSV(string csv) {

            List<List<string>> result = new List<List<string>>();

            if (string.IsNullOrEmpty(csv))
                return result;

            using (TextFieldParser parser = new TextFieldParser(new StringReader(csv))) {
                parser.CommentTokens = new string[] { "#" };
                parser.SetDelimiters(new string[] { ";" });
                parser.HasFieldsEnclosedInQuotes = true;
                
                while (!parser.EndOfData) {
                    var values = new List<string>();

                    var readFields = parser.ReadFields();
                    if (readFields != null)
                        values.AddRange(readFields);
                    result.Add(values);
                }
            }

            return result;
        }
    }
}