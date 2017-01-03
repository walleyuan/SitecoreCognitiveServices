using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Api;

namespace Sitecore.SharedSource.CognitiveServices.Controllers.Editors
{
    public class BaseEditorController : Controller
    {
        public ICognitiveContext CognitiveContext { get; set; }

        #region Querystring Params

        public string Database { get; set; }
        public string ItemIdValue  { get; set; }
        public Sitecore.Data.ID ItemId { get; set; }
        public string Language { get; set; }
        public string Version { get; set; }
        
        #endregion Querystring Params

        public BaseEditorController(
            ICognitiveContext cognitiveContext)
        {
            
            CognitiveContext = cognitiveContext;

            /* Querystring Params available
		        id=%7b59A62A95-9E5D-4478-BDC9-1E793823C48F%7d
		        la=en
		        language=en
		        vs=1
		        version=1
		        database=master
		        readonly=0
		        db=master
	        */

            Database = Request.Params["id"];
            ItemIdValue = Request.Params["id"];
            ItemId = ID.Parse(ItemIdValue);
            Language = Request.Params["Language"];
            Version = Request.Params["version"];
        }
    }
}