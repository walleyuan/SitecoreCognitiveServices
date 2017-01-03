using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.Diagnostics;
using Sitecore.SharedSource.CognitiveServices.Api;
using Sitecore.SharedSource.CognitiveServices.Foundation;

namespace Sitecore.SharedSource.CognitiveServices.Controllers.Editors
{
    public class BaseEditorController : Controller
    {
        public ICognitiveContext CognitiveContext { get; set; }
        public IWebUtilWrapper WebUtil { get; set; }

        #region Querystring Params

        public string Database { get; set; }
        public string ItemIdValue  { get; set; }
        public Sitecore.Data.ID ItemId { get; set; }
        public string Language { get; set; }
        public string Version { get; set; }
        
        #endregion Querystring Params

        public BaseEditorController(
            ICognitiveContext cognitiveContext,
            IWebUtilWrapper webUtil)
        {
            
            CognitiveContext = cognitiveContext;
            WebUtil = webUtil;

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

            Database = WebUtil.GetQueryString("database");
            ItemIdValue = WebUtil.GetQueryString("id");
            ItemId = (!string.IsNullOrEmpty(ItemIdValue)) ? ID.Parse(ItemIdValue) : ID.Null;
            Language = WebUtil.GetQueryString("language"); 
            Version = WebUtil.GetQueryString("version");
        }
    }
}