﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.ProjectOxford.Face;
using Sitecore.Data.Items;
using Sitecore.SharedSource.CognitiveServices.Foundation;
using Sitecore.SharedSource.CognitiveServices.Repositories;

namespace Sitecore.SharedSource.CognitiveServices.Search.ComputedFields.Image
{
    public class FacialAnalysis : BaseComputedField
    {
        protected override object GetFieldValue(Item indexItem)
        {
            var dataService = DependencyResolver.Current.GetService<ISitecoreDataService>();
            if (dataService == null)
                return string.Empty;

            if (!dataService.IsMediaFile(indexItem))
                return string.Empty;

            MediaItem m = indexItem;

            var crContext = DependencyResolver.Current.GetService<ICognitiveRepositoryContext>();
            if (crContext == null)
                return string.Empty;
            
            try {
                var result = Task.Run(async () => await crContext.FaceRepository.DetectAsync(m.GetMediaStream(), true, true, new List<FaceAttributeType>()
                {
                    FaceAttributeType.Age,
                    FaceAttributeType.FacialHair,
                    FaceAttributeType.Gender,
                    FaceAttributeType.Glasses,
                    FaceAttributeType.HeadPose,
                    FaceAttributeType.Smile
                })).Result;
                var json = new JavaScriptSerializer().Serialize(result);

                return json;
            } catch (Exception ex) { LogError(ex, indexItem); }
            
            return string.Empty;
        }
    }
}