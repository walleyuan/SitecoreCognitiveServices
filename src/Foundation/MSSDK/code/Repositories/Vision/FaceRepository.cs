using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Globalization;
using SitecoreCognitiveServices.Foundation.MSSDK.Enums;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Face;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Common;
using SitecoreCognitiveServices.Foundation.MSSDK.Models.Vision.Computer;

namespace SitecoreCognitiveServices.Foundation.MSSDK.Repositories.Vision
{
    public class FaceRepository : IFaceRepository
    {
        protected readonly IMicrosoftCognitiveServicesApiKeys ApiKeys;
        protected readonly IMicrosoftCognitiveServicesRepositoryClient RepositoryClient;

        public FaceRepository(
            IMicrosoftCognitiveServicesApiKeys apiKeys,
            IMicrosoftCognitiveServicesRepositoryClient repoClient) {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
        }
        
        public virtual string GetDetectQS(bool returnFaceId, bool returnFaceLandmarks, IEnumerable<FaceAttributeType> returnFaceAttributes) {
            StringBuilder sb = new StringBuilder();
            sb.Append($"?returnFaceId={(returnFaceId ? 1 : 0)}&returnFaceLandmarks={(returnFaceLandmarks ? 1 : 0)}");
            if (returnFaceAttributes != null)
                sb.Append($"&returnFaceAttributes={string.Join(",", returnFaceAttributes.Select(attr => attr.ToString().ToLower()))}");

            return sb.ToString();
        }

        public virtual Face[] Detect(string imageUrl, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null) {
            var qs = GetDetectQS(returnFaceId, returnFaceLandmarks, returnFaceAttributes);

            var response = RepositoryClient.SendJsonPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}detect{qs}", JsonConvert.SerializeObject(new Image { Url = imageUrl }));

            return JsonConvert.DeserializeObject<Face[]>(response);
        }

        public virtual async Task<Face[]> DetectAsync(string imageUrl, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null) {
            var qs = GetDetectQS(returnFaceId, returnFaceLandmarks, returnFaceAttributes);

            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}detect{qs}", JsonConvert.SerializeObject(new Image { Url = imageUrl }));

            return JsonConvert.DeserializeObject<Face[]>(response);
        }

        public virtual Face[] Detect(Stream imageStream, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null) {

            var qs = GetDetectQS(returnFaceId, returnFaceLandmarks, returnFaceAttributes);

            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}detect{qs}", imageStream);

            return JsonConvert.DeserializeObject<Face[]>(response);
        }
        
        public virtual async Task<Face[]> DetectAsync(Stream imageStream, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null) {

            var qs = GetDetectQS(returnFaceId, returnFaceLandmarks, returnFaceAttributes);

            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}detect{qs}", imageStream);

            return JsonConvert.DeserializeObject<Face[]>(response);
        }

        public virtual VerifyResult Verify(Guid faceId1, Guid faceId2) {

            var response = RepositoryClient.SendJsonPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}verify", JsonConvert.SerializeObject(new FaceToFaceVerifyRequest { FaceId1 = faceId1, FaceId2 = faceId2 }));

            return JsonConvert.DeserializeObject<VerifyResult>(response);
        }
        
        public virtual async Task<VerifyResult> VerifyAsync(Guid faceId1, Guid faceId2) {
            
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}verify", JsonConvert.SerializeObject(new FaceToFaceVerifyRequest { FaceId1 = faceId1, FaceId2 = faceId2 }));

            return JsonConvert.DeserializeObject<VerifyResult>(response);
        }

        public virtual VerifyResult Verify(Guid faceId, string personGroupId, Guid personId) {

            var response = RepositoryClient.SendJsonPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}verify", JsonConvert.SerializeObject(new FaceToPersonVerifyRequest { FaceId = faceId, PersonGroupId = personGroupId, PersonId = personId }));

            return JsonConvert.DeserializeObject<VerifyResult>(response);
        }
        
        public virtual async Task<VerifyResult> VerifyAsync(Guid faceId, string personGroupId, Guid personId) {

            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}verify", JsonConvert.SerializeObject(new FaceToPersonVerifyRequest { FaceId = faceId, PersonGroupId = personGroupId, PersonId = personId }));

            return JsonConvert.DeserializeObject<VerifyResult>(response);
        }

        public virtual IdentifyResult[] Identify(string personGroupId, Guid[] faceIds, int maxNumOfCandidatesReturned = 1) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}verify", JsonConvert.SerializeObject(new IdentifyRequest { PersonGroupId = personGroupId, FaceIds = faceIds, ConfidenceThreshold = 0.5f, MaxNumOfCandidatesReturned = 1 }));

            return JsonConvert.DeserializeObject<IdentifyResult[]>(response);
        }
        
        public virtual async Task<IdentifyResult[]> IdentifyAsync(string personGroupId, Guid[] faceIds, int maxNumOfCandidatesReturned = 1) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}verify", JsonConvert.SerializeObject(new IdentifyRequest { PersonGroupId = personGroupId, FaceIds = faceIds, ConfidenceThreshold = 0.5f, MaxNumOfCandidatesReturned = 1}));

            return JsonConvert.DeserializeObject<IdentifyResult[]>(response);
        }

        public virtual IdentifyResult[] Identify(string personGroupId, Guid[] faceIds, float confidenceThreshold, int maxNumOfCandidatesReturned = 1) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}identify", JsonConvert.SerializeObject(new IdentifyRequest { PersonGroupId = personGroupId, FaceIds = faceIds, ConfidenceThreshold = confidenceThreshold, MaxNumOfCandidatesReturned = 1 }));

            return JsonConvert.DeserializeObject<IdentifyResult[]>(response);
        }
        
        public virtual async Task<IdentifyResult[]> IdentifyAsync(string personGroupId, Guid[] faceIds, float confidenceThreshold, int maxNumOfCandidatesReturned = 1) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}identify", JsonConvert.SerializeObject(new IdentifyRequest { PersonGroupId = personGroupId, FaceIds = faceIds, ConfidenceThreshold = confidenceThreshold, MaxNumOfCandidatesReturned = 1 }));

            return JsonConvert.DeserializeObject<IdentifyResult[]>(response);
        }

        public virtual void CreatePersonGroup(string personGroupId, string name, string userData = null) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups{personGroupId}", JsonConvert.SerializeObject(new UserDataRequest { Name = name, UserData = userData }));

            return;
        }
        
        public virtual async Task CreatePersonGroupAsync(string personGroupId, string name, string userData = null) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups{personGroupId}", JsonConvert.SerializeObject(new UserDataRequest { Name = name, UserData = userData }));

            return;
        }

        public virtual PersonGroup GetPersonGroup(string personGroupId) {
            var response = RepositoryClient.SendGet(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups{personGroupId}");

            return JsonConvert.DeserializeObject<PersonGroup>(response);
        }
        
        public virtual async Task<PersonGroup> GetPersonGroupAsync(string personGroupId) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups{personGroupId}");

            return JsonConvert.DeserializeObject<PersonGroup>(response);
        }

        public virtual void UpdatePersonGroup(string personGroupId, string name, string userData = null) {
            var response = RepositoryClient.SendJsonPatch(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups{personGroupId}", JsonConvert.SerializeObject(new UserDataRequest { Name = name, UserData = userData }));

            return;
        }
        
        public virtual async Task UpdatePersonGroupAsync(string personGroupId, string name, string userData = null) {
            var response = await RepositoryClient.SendJsonPatchAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups{personGroupId}", JsonConvert.SerializeObject(new UserDataRequest { Name = name, UserData = userData }));

            return;
        }

        public virtual void DeletePersonGroup(string personGroupId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups{personGroupId}");

            return;
        }

        public virtual async Task DeletePersonGroupAsync(string personGroupId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups{personGroupId}");

            return;
        }

        public virtual PersonGroup[] ListPersonGroups(string start = "", int top = 1000) {
            var response = RepositoryClient.SendGet(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups?start={start}$top={top.ToString((IFormatProvider)CultureInfo.InvariantCulture)}");

            return JsonConvert.DeserializeObject<PersonGroup[]>(response);
        }

        public virtual async Task<PersonGroup[]> ListPersonGroupsAsync(string start = "", int top = 1000) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups?start={start}$top={top.ToString((IFormatProvider)CultureInfo.InvariantCulture)}");

            return JsonConvert.DeserializeObject<PersonGroup[]>(response);
        }

        public virtual void TrainPersonGroup(string personGroupId) {
            var response = RepositoryClient.SendGet(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups{personGroupId}/train");

            return;
        }

        public virtual async Task TrainPersonGroupAsync(string personGroupId) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups{personGroupId}/train");

            return;
        }

        public virtual TrainingStatus GetPersonGroupTrainingStatus(string personGroupId) {
            var response = RepositoryClient.SendGet(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/training");

            return JsonConvert.DeserializeObject<TrainingStatus>(response);
        }

        public virtual async Task<TrainingStatus> GetPersonGroupTrainingStatusAsync(string personGroupId) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/training");

            return JsonConvert.DeserializeObject<TrainingStatus>(response);
        }

        public virtual CreatePersonResult CreatePerson(string personGroupId, string name, string userData = null) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons", JsonConvert.SerializeObject(new UserDataRequest { Name = name, UserData = userData }));

            return JsonConvert.DeserializeObject<CreatePersonResult>(response);
        }

        public virtual async Task<CreatePersonResult> CreatePersonAsync(string personGroupId, string name, string userData = null) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons", JsonConvert.SerializeObject(new UserDataRequest { Name = name, UserData = userData }));

            return JsonConvert.DeserializeObject<CreatePersonResult>(response);
        }

        public virtual Person GetPerson(string personGroupId, Guid personId) {
            var response = RepositoryClient.SendGet(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons/{personId}");

            return JsonConvert.DeserializeObject<Person>(response);
        }

        public virtual async Task<Person> GetPersonAsync(string personGroupId, Guid personId) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons/{personId}");

            return JsonConvert.DeserializeObject<Person>(response);
        }

        public virtual void UpdatePerson(string personGroupId, Guid personId, string name, string userData = null) {
            var response = RepositoryClient.SendJsonUpdate(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons/{personId}", JsonConvert.SerializeObject(new UserDataRequest { Name = name, UserData = userData }));

            return;
        }

        public virtual async Task UpdatePersonAsync(string personGroupId, Guid personId, string name, string userData = null) {
            var response = await RepositoryClient.SendJsonUpdateAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons/{personId}", JsonConvert.SerializeObject(new UserDataRequest { Name = name, UserData = userData }));

            return;
        }

        public virtual void DeletePerson(string personGroupId, Guid personId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons/{personId}");

            return;
        }

        public virtual async Task DeletePersonAsync(string personGroupId, Guid personId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons/{personId}");

            return;
        }

        public virtual Person[] GetPersons(string personGroupId) {
            var response = RepositoryClient.SendGet(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons");

            return JsonConvert.DeserializeObject<Person[]>(response);
        }

        public virtual async Task<Person[]> GetPersonsAsync(string personGroupId) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons");

            return JsonConvert.DeserializeObject<Person[]>(response);
        }

        public virtual string GetRectangle(Rectangle rectangle) {
            return (rectangle != null)
                ? $"&targetFace={rectangle.Left},{rectangle.Top},{rectangle.Width},{rectangle.Height}"
                : string.Empty;
        }

        public virtual AddPersistedFaceResult AddPersonFace(string personGroupId, Guid personId, string imageUrl, string userData = "", Rectangle targetFace = null) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons/{personId}/persistedfaces?userData={userData}{GetRectangle(targetFace)}", JsonConvert.SerializeObject(new Image { Url = imageUrl }));

            return JsonConvert.DeserializeObject<AddPersistedFaceResult>(response);
        }

        public virtual async Task<AddPersistedFaceResult> AddPersonFaceAsync(string personGroupId, Guid personId, string imageUrl, string userData = "", Rectangle targetFace = null) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons/{personId}/persistedfaces?userData={userData}{GetRectangle(targetFace)}", JsonConvert.SerializeObject(new Image { Url = imageUrl }));

            return JsonConvert.DeserializeObject<AddPersistedFaceResult>(response);
        }

        public virtual AddPersistedFaceResult AddPersonFace(string personGroupId, Guid personId, Stream imageStream, string userData = "", Rectangle targetFace = null) {
            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons/{personId}/persistedfaces?userData={userData}{GetRectangle(targetFace)}", imageStream);

            return JsonConvert.DeserializeObject<AddPersistedFaceResult>(response);
        }

        public virtual async Task<AddPersistedFaceResult> AddPersonFaceAsync(string personGroupId, Guid personId, Stream imageStream, string userData = "", Rectangle targetFace = null) {
            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons/{personId}/persistedfaces?userData={userData}{GetRectangle(targetFace)}", imageStream);

            return JsonConvert.DeserializeObject<AddPersistedFaceResult>(response);
        }

        public virtual PersonFace GetPersonFace(string personGroupId, Guid personId, Guid persistedFaceId) {
            var response = RepositoryClient.SendGet(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons/{personId}/persistedfaces/{persistedFaceId}");

            return JsonConvert.DeserializeObject<PersonFace>(response);
        }

        public virtual async Task<PersonFace> GetPersonFaceAsync(string personGroupId, Guid personId, Guid persistedFaceId) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons/{personId}/persistedfaces/{persistedFaceId}");

            return JsonConvert.DeserializeObject<PersonFace>(response);
        }

        public virtual void UpdatePersonFace(string personGroupId, Guid personId, Guid persistedFaceId, string userData) {
            var response = RepositoryClient.SendJsonPatch(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons/{personId}/persistedfaces/{persistedFaceId}", JsonConvert.SerializeObject(new UserDataRequest { UserData = userData }));

            return;
        }

        public virtual async Task UpdatePersonFaceAsync(string personGroupId, Guid personId, Guid persistedFaceId, string userData) {
            var response = await RepositoryClient.SendJsonPatchAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons/{personId}/persistedfaces/{persistedFaceId}", JsonConvert.SerializeObject(new UserDataRequest { UserData = userData }));

            return;
        }

        public virtual void DeletePersonFace(string personGroupId, Guid personId, Guid persistedFaceId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons/{personId}/persistedfaces/{persistedFaceId}");

            return;
        }

        public virtual async Task DeletePersonFaceAsync(string personGroupId, Guid personId, Guid persistedFaceId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}persongroups/{personGroupId}/persons/{personId}/persistedfaces/{persistedFaceId}");

            return;
        }

        public virtual SimilarFace[] FindSimilar(Guid faceId, Guid[] faceIds, int maxNumOfCandidatesReturned = 20) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}findsimilars", JsonConvert.SerializeObject(new FaceSimilarityRequest { FaceId = faceId, FaceIds = faceIds, MaxNumOfCandidatesReturned = 20, Mode = FindSimilarMatchMode.matchPerson }));

            return JsonConvert.DeserializeObject<SimilarFace[]>(response);
        }

        public virtual async Task<SimilarFace[]> FindSimilarAsync(Guid faceId, Guid[] faceIds, int maxNumOfCandidatesReturned = 20) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}findsimilars", JsonConvert.SerializeObject(new FaceSimilarityRequest { FaceId = faceId, FaceIds = faceIds, MaxNumOfCandidatesReturned = 20, Mode = FindSimilarMatchMode.matchPerson }));

            return JsonConvert.DeserializeObject<SimilarFace[]>(response);
        }

        public virtual SimilarFace[] FindSimilar(Guid faceId, Guid[] faceIds, FindSimilarMatchMode mode, int maxNumOfCandidatesReturned = 20) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}findsimilars", JsonConvert.SerializeObject(new FaceSimilarityRequest { FaceId = faceId, FaceIds = faceIds, MaxNumOfCandidatesReturned = 20, Mode = mode }));

            return JsonConvert.DeserializeObject<SimilarFace[]>(response);
        }

        public virtual async Task<SimilarFace[]> FindSimilarAsync(Guid faceId, Guid[] faceIds, FindSimilarMatchMode mode, int maxNumOfCandidatesReturned = 20) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}findsimilars", JsonConvert.SerializeObject(new FaceSimilarityRequest { FaceId = faceId, FaceIds = faceIds, MaxNumOfCandidatesReturned = 20, Mode = mode }));

            return JsonConvert.DeserializeObject<SimilarFace[]>(response);
        }

        public virtual SimilarPersistedFace[] FindSimilar(Guid faceId, string faceListId, int maxNumOfCandidatesReturned = 20) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}findsimilars", JsonConvert.SerializeObject(new FaceSimilarityRequest { FaceId = faceId, FaceListId = faceListId, MaxNumOfCandidatesReturned = 20, Mode = FindSimilarMatchMode.matchPerson }));

            return JsonConvert.DeserializeObject<SimilarPersistedFace[]>(response);
        }

        public virtual async Task<SimilarPersistedFace[]> FindSimilarAsync(Guid faceId, string faceListId, int maxNumOfCandidatesReturned = 20) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}findsimilars", JsonConvert.SerializeObject(new FaceSimilarityRequest { FaceId = faceId, FaceListId = faceListId, MaxNumOfCandidatesReturned = 20, Mode = FindSimilarMatchMode.matchPerson }));

            return JsonConvert.DeserializeObject<SimilarPersistedFace[]>(response);
        }

        public virtual SimilarPersistedFace[] FindSimilar(Guid faceId, string faceListId, FindSimilarMatchMode mode, int maxNumOfCandidatesReturned = 20) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}findsimilars", JsonConvert.SerializeObject(new FaceSimilarityRequest { FaceId = faceId, FaceListId = faceListId, MaxNumOfCandidatesReturned = 20, Mode = mode }));

            return JsonConvert.DeserializeObject<SimilarPersistedFace[]>(response);
        }

        public virtual async Task<SimilarPersistedFace[]> FindSimilarAsync(Guid faceId, string faceListId, FindSimilarMatchMode mode, int maxNumOfCandidatesReturned = 20) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}findsimilars", JsonConvert.SerializeObject(new FaceSimilarityRequest { FaceId = faceId, FaceListId = faceListId, MaxNumOfCandidatesReturned = 20, Mode = mode }));

            return JsonConvert.DeserializeObject<SimilarPersistedFace[]>(response);
        }

        public virtual GroupResult Group(Guid[] faceIds) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}group", JsonConvert.SerializeObject(new GroupRequest { FaceIds = faceIds }));

            return JsonConvert.DeserializeObject<GroupResult>(response);
        }

        public virtual async Task<GroupResult> GroupAsync(Guid[] faceIds) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}group", JsonConvert.SerializeObject(new GroupRequest { FaceIds = faceIds }));

            return JsonConvert.DeserializeObject<GroupResult>(response);
        }

        public virtual void CreateFaceList(string faceListId, string name, string userData) {
            var response = RepositoryClient.SendJsonPut(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}facelists/{faceListId}", JsonConvert.SerializeObject(new UserDataRequest { Name = name, UserData = userData }));

            return;
        }

        public virtual async Task CreateFaceListAsync(string faceListId, string name, string userData) {
            var response = await RepositoryClient.SendJsonPutAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}facelists/{faceListId}", JsonConvert.SerializeObject(new UserDataRequest { Name = name, UserData = userData }));

            return;
        }

        public virtual FaceList GetFaceList(string faceListId) {
            var response = RepositoryClient.SendGet(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}facelists/{faceListId}");

            return JsonConvert.DeserializeObject<FaceList>(response);
        }

        public virtual async Task<FaceList> GetFaceListAsync(string faceListId) {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}facelists/{faceListId}");

            return JsonConvert.DeserializeObject<FaceList>(response);
        }

        public virtual FaceListMetadata[] ListFaceLists() {
            var response = RepositoryClient.SendGet(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}facelists");

            return JsonConvert.DeserializeObject<FaceListMetadata[]>(response);
        }

        public virtual async Task<FaceListMetadata[]> ListFaceListsAsync() {
            var response = await RepositoryClient.SendGetAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}facelists");

            return JsonConvert.DeserializeObject<FaceListMetadata[]>(response);
        }

        public virtual void UpdateFaceList(string faceListId, string name, string userData) {
            var response = RepositoryClient.SendJsonPatch(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}facelists", JsonConvert.SerializeObject(new UserDataRequest { Name = name, UserData = userData }));

            return;
        }

        public virtual async Task UpdateFaceListAsync(string faceListId, string name, string userData) {
            var response = await RepositoryClient.SendJsonPatchAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}facelists", JsonConvert.SerializeObject(new UserDataRequest { Name = name, UserData = userData }));

            return;
        }

        public virtual void DeleteFaceList(string faceListId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}facelists/{faceListId}");

            return;
        }

        public virtual async Task DeleteFaceListAsync(string faceListId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}facelists/{faceListId}");

            return;
        }

        public virtual AddPersistedFaceResult AddFaceToFaceList(string faceListId, string imageUrl, string userData = "", Rectangle targetFace = null) {
            var response = RepositoryClient.SendJsonPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}facelists/{faceListId}/persistedfaces/?userData={userData}{GetRectangle(targetFace)}", JsonConvert.SerializeObject(new Image { Url = imageUrl }));

            return JsonConvert.DeserializeObject<AddPersistedFaceResult>(response);
        }

        public virtual async Task<AddPersistedFaceResult> AddFaceToFaceListAsync(string faceListId, string imageUrl, string userData = "", Rectangle targetFace = null) {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}facelists/{faceListId}/persistedfaces/?userData={userData}{GetRectangle(targetFace)}", JsonConvert.SerializeObject(new Image { Url = imageUrl }));

            return JsonConvert.DeserializeObject<AddPersistedFaceResult>(response);
        }

        public virtual AddPersistedFaceResult AddFaceToFaceList(string faceListId, Stream imageStream, string userData = null, Rectangle targetFace = null) {
            var response = RepositoryClient.SendOctetStreamPost(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}facelists/{faceListId}/persistedfaces/?userData={userData}{GetRectangle(targetFace)}", imageStream);

            return JsonConvert.DeserializeObject<AddPersistedFaceResult>(response);
        }

        public virtual async Task<AddPersistedFaceResult> AddFaceToFaceListAsync(string faceListId, Stream imageStream, string userData = null, Rectangle targetFace = null) {
            var response = await RepositoryClient.SendOctetStreamPostAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}facelists/{faceListId}/persistedfaces/?userData={userData}{GetRectangle(targetFace)}", imageStream);

            return JsonConvert.DeserializeObject<AddPersistedFaceResult>(response);
        }

        public virtual void DeleteFaceFromFaceList(string faceListId, Guid persistedFaceId) {
            var response = RepositoryClient.SendJsonDelete(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}facelists/{faceListId}/persistedfaces/{persistedFaceId}");

            return;
        }

        public virtual async Task DeleteFaceFromFaceListAsync(string faceListId, Guid persistedFaceId) {
            var response = await RepositoryClient.SendJsonDeleteAsync(ApiKeys.Face, $"{ApiKeys.FaceEndpoint}facelists/{faceListId}/persistedfaces/{persistedFaceId}");

            return;
        }
    }
}
