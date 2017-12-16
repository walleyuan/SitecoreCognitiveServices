using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Enums
{
    public enum ContentModeratorTag
    {
        None = 0,
        Nudity = 101,
        SexualContent = 102,
        Alcohol = 201,
        Tobacco = 202,
        Drugs = 203,
        ChildExploitation = 301,
        Violence = 401,
        Weapons = 402,
        Gore = 403,
        Profanity = 501,
        Vulgarity = 502,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContentModeratorReviewStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "Failed")]
        Failed,
        [EnumMember(Value = "Complete")]
        Complete
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ContentModeratorReviewType
    {
        [EnumMember(Value = "Text")]
        Text = 0,
        [EnumMember(Value = "Image")]
        Image = 1,
        [EnumMember(Value = "Video")]
        Video = 2
    }

    public enum ContentModeratorVideoModeOptions { Speed, Balance, Quality }

    public enum VideoOutputStyleOptions { Aggregate, PerFrame }

    public enum SensitivityOptions { low, medium, high }

    public enum VisualFeature { ImageType, Color, Faces, Adult, Categories, Tags, Description }

    public enum VideoOperationStatus {
        NotStarted,
        Uploading,
        Running,
        Failed,
        Succeeded,
    }

    public enum Glasses {
        NoGlasses,
        Sunglasses,
        ReadingGlasses,
        SwimmingGoggles,
    }

    public enum FindSimilarMatchMode {
        matchPerson,
        matchFace,
    }

    public enum FaceAttributeType {
        Age,
        Gender,
        FacialHair,
        Smile,
        HeadPose,
        Glasses,
    }
}