using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Sitecore.SharedSource.CognitiveServices.Models
{
    public class TokenResponse
    {
        public string Token_Type { get; set; }
        public string Expires_In { get; set; }
        public string Ext_Expires_In { get; set; }
        public string Expires_On { get; set; }
        public string Not_Before { get; set; }
        public string Resource { get; set; }
        public string Access_Token { get; set; }

        public DateTime ExpirationDate
        {
            get
            {
                DateTime startDate = new DateTime(1970, 1, 1);
                return startDate.AddSeconds(int.Parse(Expires_On));
            }
        }
    }
}