using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using SitecoreCognitiveServices.Feature.ImageSearch.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Areas.SitecoreCognitiveServices.Models.Analysis;
using SitecoreCognitiveServices.Feature.ImageSearch.Factories;
using SitecoreCognitiveServices.Feature.ImageSearch.Search;
using SitecoreCognitiveServices.Foundation.MSSDK;
using SitecoreCognitiveServices.Foundation.SCSDK.Wrappers;

namespace SitecoreCognitiveServices.Feature.ImageSearch.Setup
{
    public class SetupService : ISetupService
    {
        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly ISetupInformationFactory SetupFactory;
        protected readonly IMicrosoftCognitiveServicesApiKeys MSCSApiKeys;
        protected readonly IImageSearchSettings SearchSettings;
        protected readonly IImageAnalysisService AnalysisService;
        protected readonly IImageSearchService SearchService;
        protected readonly HttpContextBase Context;

        public SetupService(
            ISitecoreDataWrapper dataWrapper,
            ISetupInformationFactory setupFactory, 
            IMicrosoftCognitiveServicesApiKeys mscsApiKeys,
            IImageSearchSettings searchSettings,
            IImageAnalysisService analysisService,
            IImageSearchService searchService,
            HttpContextBase context)
        {
            DataWrapper = dataWrapper;
            SetupFactory = setupFactory;
            MSCSApiKeys = mscsApiKeys;
            SearchSettings = searchSettings;
            AnalysisService = analysisService;
            SearchService = searchService;
            Context = context;
        }

        public ICognitiveImageAnalysis SaveKeysAndAnalyze(string emotionApi, string emotionApiEndpoint, string faceApi, string faceApiEndpoint, string computerVisionApi, string computerVisionApiEndpoint)
        {
            var db = Factory.GetDatabase(SearchSettings.MasterDatabase);
            using (new DatabaseSwitcher(db))
            {
                //save items to fields
                if (MSCSApiKeys.Emotion != emotionApi)
                    MSCSApiKeys.Emotion = emotionApi;
                if (MSCSApiKeys.EmotionEndpoint != emotionApiEndpoint)
                    MSCSApiKeys.EmotionEndpoint = emotionApiEndpoint;
                if (MSCSApiKeys.Face != faceApi)
                    MSCSApiKeys.Face = faceApi;
                if (MSCSApiKeys.FaceEndpoint != faceApiEndpoint)
                    MSCSApiKeys.FaceEndpoint = faceApiEndpoint;
                if (MSCSApiKeys.ComputerVision != computerVisionApi)
                    MSCSApiKeys.ComputerVision = computerVisionApi;
                if (MSCSApiKeys.ComputerVisionEndpoint != computerVisionApiEndpoint)
                    MSCSApiKeys.ComputerVisionEndpoint = computerVisionApiEndpoint;

                //get the sample image and analyze it to test responses
                Item sampleImage = DataWrapper.ContentDatabase.GetItem(SearchSettings.SampleImageId);
                return AnalysisService.AnalyzeImage(sampleImage);
            }
        }

        /// <summary>
        /// change the field folder to a sitecore folder from a node
        /// </summary>
        public string SetFieldsFolderTemplate()
        {
            var coreDb = Factory.GetDatabase(SearchSettings.CoreDatabase);
            if (coreDb == null)
                return $"{SearchSettings.CoreDatabase} database";

            var template = coreDb.Templates["common/folder"];
            var fieldFolderItem = coreDb.GetItem(SearchSettings.ImageSearchFieldFolderId);
            if (fieldFolderItem == null)
                return "Field Folder in Core";

            fieldFolderItem.ChangeTemplate(template);

            return string.Empty;
        }

        public void ConfigureIndexes(string indexOption)
        {

            //enable index config
            var configFormat = "~/App_Config/Include/SitecoreCognitiveServices/SitecoreCognitiveServices.Feature.ImageSearch.{0}.config";

            //disable the unselected option config
            var unselectedPath = string.Format(configFormat, indexOption == "Lucene" ? "Solr" : "Lucene");
            var unselectedDisabledFile = Context.Server.MapPath($"{unselectedPath}.disabled");
            var unselectedEnabledFile = Context.Server.MapPath(unselectedPath);
            if (System.IO.File.Exists(unselectedEnabledFile))
            {
                System.IO.File.Copy(unselectedEnabledFile, unselectedDisabledFile, true);
                System.IO.File.Delete(unselectedEnabledFile);
            }

            //enable selected config
            var selectedPath = string.Format(configFormat, indexOption);
            var selectedDisabledFile = Context.Server.MapPath($"{selectedPath}.disabled");
            var selectedEnabledFile = Context.Server.MapPath(selectedPath);
            if (System.IO.File.Exists(selectedDisabledFile))
            {
                System.IO.File.Copy(selectedDisabledFile, selectedEnabledFile, true);
                System.IO.File.Delete(selectedDisabledFile);
            }

            if (indexOption.Equals("Solr"))
                return;

            //publish the installed content
            var imageSearchFolder = DataWrapper.ContentDatabase.GetItem(SearchSettings.ImageSearchFolderId);
            SearchService.UpdateItemInIndex(imageSearchFolder, DataWrapper.ContentDatabase.Name);

            //get the congitive indexes build for the first time
            SearchService.RebuildCognitiveIndexes();
        }

    }
}