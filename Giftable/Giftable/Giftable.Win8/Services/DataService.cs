using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Giftable.Library.Services;
using Newtonsoft.Json;
using Giftable.Library.Model;

namespace Giftable.Win8.Services
{
    public class DataService : IDataService
    {
        private const string BaseRootUri = "http://localhost:30765/api/";
        private string accessToken = "1ROCFvewrlaAVGhYVuqAOjMwauNmzaJzEvLicnRXhCcXQFwCNN";

        public async Task<HttpResponseMessage> RegisterUser(string username, string password, string email)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("The username is null or empty string!");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("The password is null or empty string!");
            }

            var authCode = CalculateSHA1(password);

            var client = new HttpClient();
            var user = new UserModel()
            {
                Username = username,
                AuthCode = authCode,
                Email = email
            };

            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(user));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(BaseRootUri + "users/register", postContent);
            return response;
        }

        public async Task<HttpResponseMessage> LoginUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("The username is null or empty string!");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("The password is null or empty string!");
            }

            var authCode = CalculateSHA1(password);

            var client = new HttpClient();
            var user = new UserModel()
            {
                Username = username,
                AuthCode = authCode
            };

            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(user));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(BaseRootUri + "users/token", postContent);
            var responseString = await response.Content.ReadAsStringAsync();
            LoginResponseModel responseModel = JsonConvert.DeserializeObject<LoginResponseModel>(responseString);
            accessToken = responseModel.AccessToken;
            return response;
        }

        public async Task<HttpResponseMessage> LogoutUser(string accessToken)
        {
            this.accessToken = accessToken;
            var client = new HttpClient();
            
            HttpContent content = new StringContent("");
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            content.Headers.Add("X-accessToken", accessToken);

            var response = await client.PutAsync(BaseRootUri + "users/logout", content);
            return response;
        }

        public async Task<ObservableCollection<FriendModel>> GetFriends()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-accessToken", accessToken);

            var response = await client.GetAsync(BaseRootUri + "users/friends");
            var friendsString = await response.Content.ReadAsStringAsync();
            var friends = await Task.FromResult(JsonConvert.DeserializeObject<ObservableCollection<FriendModel>>(friendsString));
            return friends;
        }

        public async Task<ObservableCollection<GiftModel>> GetWishList()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-accessToken", accessToken);

            var response = await client.GetAsync(BaseRootUri + "gifts/wishlist");
            var wishListString = await response.Content.ReadAsStringAsync();
            var wishList = await Task.FromResult(JsonConvert.DeserializeObject<ObservableCollection<Giftable.Library.Model.GiftModel>>(wishListString));

            return wishList;
        }

        public async Task<ObservableCollection<GiftModel>> GetWishListForUser(string email)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-accessToken", accessToken);

            var response = await client.GetAsync(BaseRootUri + "gifts/user-wishlist?email=" + email);
            var wishListString = await response.Content.ReadAsStringAsync();
            var wishList = await Task.FromResult(JsonConvert.DeserializeObject<ObservableCollection<Giftable.Library.Model.GiftModel>>(wishListString));

            return wishList;
        }

        public async Task<FriendModel> GetFriendDetails(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-accessToken", accessToken);

            var response = await client.GetAsync(BaseRootUri + "users/friend-details/" + id);

            var friendDetailsString = await response.Content.ReadAsStringAsync();
            var friendDetails = await Task.FromResult(JsonConvert.DeserializeObject<FriendModel>(friendDetailsString));

            return friendDetails;
        }

        public async Task<ObservableCollection<GiftModel>> GetLocatedGifts()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-accessToken", accessToken);

            var response = await client.GetAsync(BaseRootUri + "gifts/located-gifts");

            var giftsString = await response.Content.ReadAsStringAsync();
            var gifts = await Task.FromResult(JsonConvert.DeserializeObject<ObservableCollection<GiftModel>>(giftsString));

            return gifts;
        }

        public async Task<ObservableCollection<GiftModel>> GetUnseenSuggestedGifts()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-accessToken", accessToken);

            var response = await client.GetAsync(BaseRootUri + "gifts/get-unseen");

            var giftsString = await response.Content.ReadAsStringAsync();
            var gifts = await Task.FromResult(JsonConvert.DeserializeObject<ObservableCollection<GiftModel>>(giftsString));

            return gifts;
        }

        public async Task<ObservableCollection<GiftModel>> GetSuggestedList()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-accessToken", accessToken);

            var response = await client.GetAsync(BaseRootUri + "gifts/suggested-list");

            var giftsString = await response.Content.ReadAsStringAsync();
            var gifts = await Task.FromResult(JsonConvert.DeserializeObject<ObservableCollection<GiftModel>>(giftsString));
            return gifts;
        }

        public async Task<GiftModel> GetGiftDetails(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-accessToken", accessToken);

            var response = await client.GetAsync(BaseRootUri + "gifts/details/" + id);

            var giftString = await response.Content.ReadAsStringAsync();
            var gift = await Task.FromResult(JsonConvert.DeserializeObject<GiftModel>(giftString));
            return gift;
        }

        public async Task<HttpResponseMessage> AddGift(NewGiftModel model)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-accessToken", accessToken);

            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(model));
            postContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(BaseRootUri + "gifts/new-gift", postContent);
            return response;
        }

        public async Task<HttpResponseMessage> AddSuggestedGift(NewSuggestedGift model)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-accessToken", accessToken);

            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(model));
            postContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(BaseRootUri + "gifts/suggest-gift", postContent);
            return response;
        }

        public async Task<UserModel> SearchFriendByEmail(string email)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-accessToken", accessToken);

            var response = await client.GetAsync(BaseRootUri + "users/search-friends");
            var userString = await response.Content.ReadAsStringAsync();
            var user = await Task.FromResult(JsonConvert.DeserializeObject<UserModel>(userString));
            return user;
        }

        public async Task<HttpResponseMessage> UploadAvatar(string avatarUrl)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-accessToken", accessToken);

            var avatarModel = new AvatarModel()
            {
                Url = avatarUrl
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(avatarModel));

            var response = await client.PutAsync(BaseRootUri + "users/upload-avatar", content);
            return response;
        }

        public async Task<HttpResponseMessage> MakeFriendsWith(string email)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-accessToken", accessToken);

            HttpContent content = new StringContent("{email:"+ email + " }");
            var response = await client.PutAsync(BaseRootUri + "users/make-friends-with", content);

            return response;
        }

        private static string CalculateSHA1(string text)
        {
            IBuffer buffer = CryptographicBuffer.ConvertStringToBinary(text, BinaryStringEncoding.Utf8);
            HashAlgorithmProvider hashAlgorithm = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha1);

            IBuffer hashBuffer = hashAlgorithm.HashData(buffer);
            var hashHex = CryptographicBuffer.EncodeToHexString(hashBuffer);
            return hashHex;
        }

        //private const string CurrentFolder = "analysis";

        //public async Task<IList<string>> GetAnalysisFileList()
        //{
        //    var local = ApplicationData.Current.LocalFolder;
        //    var dataFolder = await local.CreateFolderAsync(CurrentFolder, CreationCollisionOption.OpenIfExists);
        //    var files = await dataFolder.GetFilesAsync();
        //    var result = files.Select(storageFile => storageFile.Name).ToList();
        //    return result;
        //}

        //public async Task<ObservableCollection<AnalysisModel>> GetAnalysisData(string fileName)
        //{
        //    if (string.IsNullOrEmpty(fileName))
        //    {
        //        fileName = await GenerateNewFileName();
        //    }

        //    var result = new ObservableCollection<AnalysisModel>();
            
        //    var local = ApplicationData.Current.LocalFolder;
        //    if (local != null)
        //    {
        //        var dataFolder = await local.CreateFolderAsync(CurrentFolder, CreationCollisionOption.OpenIfExists);
        //        await dataFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
        //        var file = await dataFolder.OpenStreamForReadAsync(fileName);
        //        using (var streamReader = new StreamReader(file))
        //        {
        //            var readLine = streamReader.ReadLine();
        //            while (readLine != null)
        //            {
        //                var line = readLine.Split(';');
        //                result.Add(new AnalysisModel
        //                {
        //                    Number = line[0],
        //                    Time = line[1]
        //                });
        //                readLine = streamReader.ReadLine();
        //            }
        //        }
        //    }

        //    return result;
        //}

        //public async void SaveNewAnalysisData(AnalysisModel analysis, string fileName)
        //{
        //    if (!string.IsNullOrEmpty(analysis.Number))
        //    {
        //        var sb = new StringBuilder();
        //        sb.AppendLine(analysis.Number + ";" + analysis.Time);
        //        await SaveFile(sb, fileName, true);
        //    }
        //}

        //public async Task SaveAnalysisDataFile(ObservableCollection<AnalysisModel> analysis, string fileName)
        //{
        //    if (analysis.Count > 0)
        //    {
        //        var sb = new StringBuilder();
        //        foreach (var analysi in analysis)
        //        {
        //            sb.AppendLine(analysi.Number + ";" + analysi.Time);
        //        }

        //        await SaveFile(sb, fileName, false);
        //    }
        //}

        //public async Task DeleteFile(string fileName)
        //{
        //    if (!string.IsNullOrEmpty(fileName))
        //    {
        //        var local = ApplicationData.Current.LocalFolder;
        //        var dataFolder = await local.CreateFolderAsync(CurrentFolder, CreationCollisionOption.OpenIfExists);
        //        var file = await dataFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
        //        file.DeleteAsync(StorageDeleteOption.PermanentDelete);
        //    }
        //}

        //private static async Task SaveFile(StringBuilder sb, string fileName, bool append)
        //{
        //    var fileBytes = Encoding.UTF8.GetBytes(sb.ToString().ToCharArray());
        //    var local = ApplicationData.Current.LocalFolder;
        //    var dataFolder = await local.CreateFolderAsync(CurrentFolder, CreationCollisionOption.OpenIfExists);
        //    var file = await dataFolder.CreateFileAsync(fileName, append ? CreationCollisionOption.OpenIfExists : CreationCollisionOption.ReplaceExisting);
        //    using (var s = await file.OpenStreamForWriteAsync())
        //    {
        //        if (append)
        //        {
        //            s.Seek(0, SeekOrigin.End);
        //        }
        //        s.Write(fileBytes, 0, fileBytes.Length);
        //    }
        //}

        //public async Task<string> GenerateNewFileName()
        //{
        //    var fileNamesList = await GetAnalysisFileList();
        //    var date = DateTime.Now.Date.ToString("yyyy-MM-dd");
        //    var list = fileNamesList.Select(s => s.Split('_')).ToList();
        //    var count = 0;
        //    if (list.Count > 0)
        //    {
        //        count = int.Parse(list.Where(f => f[1].Equals(date)).Max(f => f[3]).Split('.')[0]);
        //    }
        //    var version = count + 1;
        //    return string.Format("{0}_{1}_{2}_{3}.txt", "Studie", date, "name", version);
        //}
    }
}
