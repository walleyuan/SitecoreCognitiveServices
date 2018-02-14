using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using Sitecore.ContentSearch;
using Sitecore.Data;
using Sitecore.Data.Managers;
using SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Models;
using SitecoreCognitiveServices.Feature.OleChat.Dialog;
using SitecoreCognitiveServices.Feature.OleChat.Factories;
using SitecoreCognitiveServices.Feature.OleChat.Models;
using SitecoreCognitiveServices.Feature.OleChat.Setup;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis.Connector;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Controllers {

    public class CognitiveOleChatController : Controller
    {
        #region Constructor

        protected readonly IConversationService ConversationService;
        protected readonly IWebUtilWrapper WebUtil;
        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly IOleSettings ChatSettings;
        protected readonly ISetupInformationFactory SetupFactory;
        protected readonly ISetupService SetupService;

        protected readonly ItemContextParameters Parameters;
        
        public CognitiveOleChatController(
            IConversationService conversationService, 
            IWebUtilWrapper webUtil,
            ISitecoreDataWrapper dataWrapper,
            IOleSettings chatSettings,
            ISetupInformationFactory setupFactory,
            ISetupService setupService)
        {
            ConversationService = conversationService;
            WebUtil = webUtil;
            DataWrapper = dataWrapper;
            ChatSettings = chatSettings;
            SetupFactory = setupFactory;
            SetupService = setupService;

            Parameters = new ItemContextParameters()
            {
                Id = WebUtil.GetQueryString("id"),
                Language = WebUtil.GetQueryString("language"),
                Database = WebUtil.GetQueryString("db")
            };

            ThemeManager.GetImage("Office/32x32/man_8.png", 32, 32);
        }

        #endregion

        #region Chat

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
                    Selections = response.Selections,
                    Action = response.Action
                };

                return Json(reply);
            }

            return null;
        }

        #endregion

        #region Setup

        public ActionResult Setup()
        {
            if (!IsSitecoreUser())
                return LoginPage();
            
            var db = Sitecore.Configuration.Factory.GetDatabase(ChatSettings.MasterDatabase);
            using (new DatabaseSwitcher(db))
            {
                ISetupInformation info = SetupFactory.Create();

                return View("Setup", info);
            }
        }
        
        public ActionResult SetupSubmit(bool overwriteOption, string luisApi, string luisApiEndpoint, string textAnalyticsApi, string textAnalyticsApiEndpoint)
        {
            if (!IsSitecoreUser())
                return LoginPage();

            List<string> items = new List<string>();

            SetupService.SaveKeys(luisApi, luisApiEndpoint, textAnalyticsApi, textAnalyticsApiEndpoint);
            
            var restoreResult = SetupService.RestoreOle(overwriteOption);
            if(!restoreResult)
                items.Add("Restore Ole");

            var queryResult = SetupService.QueryOle();
            if(!queryResult)
                items.Add("Query Ole");

            SetupService.PublishOleContent();

            return Json(new
            {
                Failed = items.Count > 0,
                Items = string.Join(",", items)
            });
        }
        
        #endregion

        #region Shared

        public bool IsSitecoreUser()
        {
            return DataWrapper.ContextUser.IsAuthenticated
                   && DataWrapper.ContextUser.Domain.Name.ToLower().Equals("sitecore");
        }

        public ActionResult LoginPage()
        {
            return new RedirectResult("/sitecore/login");
        }

        #endregion
    }
}