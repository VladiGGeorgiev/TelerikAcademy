using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Giftable.Library.Model;

namespace Giftable.Library.Services
{
    public interface IDataService
    {
        Task<ObservableCollection<GiftModel>> GetWishList();
        Task<ObservableCollection<GiftModel>> GetWishListForUser(string email);
        Task<HttpResponseMessage> RegisterUser(string username, string password, string email);
        Task<HttpResponseMessage> LoginUser(string username, string password);
        Task<HttpResponseMessage> LogoutUser(string accessToken);
        Task<ObservableCollection<FriendModel>> GetFriends();
        Task<FriendModel> GetFriendDetails(int id);
        Task<ObservableCollection<GiftModel>> GetLocatedGifts();
        Task<ObservableCollection<GiftModel>> GetUnseenSuggestedGifts();
        Task<ObservableCollection<GiftModel>> GetSuggestedList();
        Task<GiftModel> GetGiftDetails(int id);
        Task<HttpResponseMessage> AddGift(NewGiftModel model);
        Task<HttpResponseMessage> AddSuggestedGift(NewSuggestedGift model);
        Task<HttpResponseMessage> MakeFriendsWith(string email);
    }
}
