﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using Sitecore.Data.Managers;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis.Connector;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Controllers {

    public class CognitiveBotController : Controller
    {
        protected readonly IConversationService ConversationService;
        protected readonly IWebUtilWrapper WebUtil;

        protected readonly ItemContextParameters Parameters;


        public CognitiveBotController(
            IConversationService conversationService, 
            IWebUtilWrapper webUtil)
        {
            ConversationService = conversationService;
            WebUtil = webUtil;
            
            Parameters = new ItemContextParameters()
            {
                Id = WebUtil.GetQueryString("id"),
                Language = WebUtil.GetQueryString("language"),
                Database = WebUtil.GetQueryString("db")
            };

            ThemeManager.GetImage("Office/32x32/man_8.png", 32, 32);
        }

        public ActionResult OleChat()
        {
            return View("OleChat", Parameters);
        }

        public ActionResult Post([FromBody] Activity activity)
        {
            var s = JsonConvert.SerializeObject(activity.ChannelData);
            var d = JsonConvert.DeserializeObject<List<string>>(s);
            ItemContextParameters parameters = (d.Any())
                ? JsonConvert.DeserializeObject<ItemContextParameters>(d[0])
                : new ItemContextParameters();

            if (activity.Type == ActivityTypes.Message)
            {
                var response = ConversationService.HandleMessage(activity, parameters);
                var reply = activity.CreateReply(response.Message, "en-US");
                reply.ChannelData = new ChannelData
                {
                    OptionSet = response.OptionsSet,
                    Action = response.Action
                };

                return Json(reply);
            }

            return null;
        }
    }
}