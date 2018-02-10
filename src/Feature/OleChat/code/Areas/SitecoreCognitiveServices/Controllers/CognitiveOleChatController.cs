using System.Collections.Generic;
using System.Linq;
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
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Language.Luis.Connector;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.OleChat.Areas.SitecoreCognitiveServices.Controllers {

    public class CognitiveOleChatController : Controller
    {
        protected readonly IConversationService ConversationService;
        protected readonly IWebUtilWrapper WebUtil;
        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly IOleSettings ChatSettings;
        protected readonly ISetupInformationFactory SetupFactory;

        protected readonly ItemContextParameters Parameters;


        public CognitiveOleChatController(
            IConversationService conversationService, 
            IWebUtilWrapper webUtil,
            ISitecoreDataWrapper dataWrapper,
            IOleSettings chatSettings,
            ISetupInformationFactory setupFactory)
        {
            ConversationService = conversationService;
            WebUtil = webUtil;
            DataWrapper = dataWrapper;
            ChatSettings = chatSettings;
            SetupFactory = setupFactory;

            Parameters = new ItemContextParameters()
            {
                Id = WebUtil.GetQueryString("id"),
                Language = WebUtil.GetQueryString("language"),
                Database = WebUtil.GetQueryString("db")
            };

            ThemeManager.GetImage("Office/32x32/man_8.png", 32, 32);
        }

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

        public ActionResult SetupSubmit(string indexOption, string emotionApi, string emotionApiEndpoint,
            string faceApi, string faceApiEndpoint, string computerVisionApi, string computerVisionApiEndpoint)
        {
            if (!IsSitecoreUser())
                return LoginPage();

            //try to query version to see if keys work

            //upload the json to service

            //ICognitiveImageAnalysis analysis = SaveKeysAndAnalyze(emotionApi, emotionApiEndpoint, faceApi, faceApiEndpoint, computerVisionApi, computerVisionApiEndpoint);
            //var items = new List<string>();
            //if (analysis == null || analysis.EmotionAnalysis?.Length < 1)
            //    items.Add("Emotion API");
            //if (analysis == null || analysis.FacialAnalysis?.Length < 1)
            //    items.Add("Face API");
            //if (analysis?.TextAnalysis?.Regions == null || analysis?.VisionAnalysis?.Description == null)
            //    items.Add("Computer Vision API");

            //string err = SetFieldsFolderTemplate();
            //if (!string.IsNullOrEmpty(err))
            //    items.Add(err);

            //if (!indexOption.Equals("Skip"))
            //    ConfigureIndexes(indexOption);

            return Json(new
            {
                Failed = false,//(analysis == null || items.Count > 0),
                Items = ""//string.Join(",", items)
            });
        }

        //public ICognitiveImageAnalysis SaveKeysAndAnalyze(string emotionApi, string emotionApiEndpoint, string faceApi, string faceApiEndpoint, string computerVisionApi, string computerVisionApiEndpoint)
        //{
        //    var db = Factory.GetDatabase(SearchSettings.MasterDatabase);
        //    using (new DatabaseSwitcher(db))
        //    {
        //        //save items to fields
        //        if (MSCSApiKeys.Emotion != emotionApi)
        //            MSCSApiKeys.Emotion = emotionApi;
        //        if (MSCSApiKeys.EmotionEndpoint != emotionApiEndpoint)
        //            MSCSApiKeys.EmotionEndpoint = emotionApiEndpoint;
        //        if (MSCSApiKeys.Face != faceApi)
        //            MSCSApiKeys.Face = faceApi;
        //        if (MSCSApiKeys.FaceEndpoint != faceApiEndpoint)
        //            MSCSApiKeys.FaceEndpoint = faceApiEndpoint;
        //        if (MSCSApiKeys.ComputerVision != computerVisionApi)
        //            MSCSApiKeys.ComputerVision = computerVisionApi;
        //        if (MSCSApiKeys.ComputerVisionEndpoint != computerVisionApiEndpoint)
        //            MSCSApiKeys.ComputerVisionEndpoint = computerVisionApiEndpoint;

        //        //get the sample image and analyze it to test responses
        //        Item sampleImage = DataWrapper.ContentDatabase.GetItem(SearchSettings.SampleImageId);
        //        return AnalysisService.AnalyzeImage(sampleImage);
        //    }
        //}

        ///// <summary>
        ///// change the field folder to a sitecore folder from a node
        ///// </summary>
        //public string SetFieldsFolderTemplate()
        //{
        //    var coreDb = Factory.GetDatabase(SearchSettings.CoreDatabase);
        //    if (coreDb == null)
        //        return $"{SearchSettings.CoreDatabase} database";

        //    var template = coreDb.Templates["common/folder"];
        //    var fieldFolderItem = coreDb.GetItem(SearchSettings.ImageSearchFieldFolderId);
        //    if (fieldFolderItem == null)
        //        return "Field Folder in Core";

        //    fieldFolderItem.ChangeTemplate(template);

        //    return string.Empty;
        //}

        //public void ConfigureIndexes(string indexOption)
        //{

        //    //enable index config
        //    var configFormat = "~/App_Config/Include/SitecoreCognitiveServices/SitecoreCognitiveServices.Feature.ImageSearch.{0}.config";

        //    //disable the unselected option config
        //    var unselectedPath = string.Format(configFormat, indexOption == "Lucene" ? "Solr" : "Lucene");
        //    var unselectedDisabledFile = Context.Server.MapPath($"{unselectedPath}.disabled");
        //    var unselectedEnabledFile = Context.Server.MapPath(unselectedPath);
        //    if (System.IO.File.Exists(unselectedEnabledFile))
        //    {
        //        System.IO.File.Copy(unselectedEnabledFile, unselectedDisabledFile, true);
        //        System.IO.File.Delete(unselectedEnabledFile);
        //    }

        //    //enable selected config
        //    var selectedPath = string.Format(configFormat, indexOption);
        //    var selectedDisabledFile = Context.Server.MapPath($"{selectedPath}.disabled");
        //    var selectedEnabledFile = Context.Server.MapPath(selectedPath);
        //    if (System.IO.File.Exists(selectedDisabledFile))
        //    {
        //        System.IO.File.Copy(selectedDisabledFile, selectedEnabledFile, true);
        //        System.IO.File.Delete(selectedDisabledFile);
        //    }

        //    if (indexOption.Equals("Solr"))
        //        return;

        //    //publish the installed content
        //    var imageSearchFolder = DataWrapper.ContentDatabase.GetItem(SearchSettings.ImageSearchFolderId);
        //    SearchService.UpdateItemInIndex(imageSearchFolder, DataWrapper.ContentDatabase.Name);

        //    //get the congitive indexes build for the first time
        //    SearchService.RebuildCognitiveIndexes();
        //}

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