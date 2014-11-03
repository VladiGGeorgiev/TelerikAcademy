using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Giftable.Library.Model;
using Giftable.Library.Services;

namespace Giftable.Library.Design
{
    public class DesignDataService : IDataService
    {
        //private static readonly Random Random = new Random();

        //public Task<IList<string>> GetAnalysisFileList()
        //{
        //    var result = new List<string>();

        //    for (var index = 0; index < 30; index++)
        //    {
        //        result.Add(GetFileName(index));
        //    }

        //    return Task.FromResult((IList<string>)result);
        //}

        //public Task<ObservableCollection<AnalysisModel>> GetAnalysisData(string fileName)
        //{
        //    var result = new ObservableCollection<AnalysisModel>();

        //    for (var index = 0; index < 30; index++)
        //    {
        //        var analysis = new AnalysisModel()
        //        {
        //            Number = Random.Next(1, int.MaxValue).ToString(),
        //            Time = DateTime.Now.TimeOfDay.ToString()
        //        };

        //        result.Add(analysis);
        //    }

        //    return Task.FromResult(result);
        //}

        //public void SaveNewAnalysisData(AnalysisModel analysis, string selectedFile)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task SaveAnalysisDataFile(ObservableCollection<AnalysisModel> analysis, string fileName)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task DeleteFile(string fileName)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<string> GenerateNewFileName()
        //{
        //    throw new NotImplementedException();
        //}

        //private static string GetFileName(int index)
        //{
        //    return string.Format("{0}_{1}_{2}_{3}.txt", "Studie", DateTime.Now.Date, "name", index);
        //}
        public Task<ObservableCollection<GiftModel>> GetWishList()
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<GiftModel>> GetWishListForUser(string email)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> RegisterUser(string username, string password, string email)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> LogoutUser(string accessToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<FriendModel>> GetFriends()
        {
            throw new NotImplementedException();
        }

        public Task<FriendModel> GetFriendDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<GiftModel>> GetLocatedGifts()
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<GiftModel>> GetUnseenSuggestedGifts()
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<GiftModel>> GetSuggestedList()
        {
            throw new NotImplementedException();
        }

        public Task<GiftModel> GetGiftDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> AddGift(NewGiftModel model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> AddSuggestedGift(NewSuggestedGift model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> MakeFriendsWith(string email)
        {
            throw new NotImplementedException();
        }
    }
}
