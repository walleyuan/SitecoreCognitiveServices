using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.CSV {
    public interface ICSVParser
    {
        List<List<string>> ParseCSV(string csv);
    }
}