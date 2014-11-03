using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using Giftable.Library.Model;
using Giftable.Library.Services;


namespace Giftable.Library.ViewModel
{
    public class SplitPageViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;

        public ObservableCollection<GiftModel> UserWishlist { get; set; }

        public FriendModel SelectedUser { get; set; }

        public SplitPageViewModel(INavigationService navigationService, IDataService dataService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            UserWishlist = new ObservableCollection<GiftModel>();
        }

        public async void LoadData(FriendModel selectedUser)
        {
            this.SelectedUser = selectedUser;
            UserWishlist.Clear();
            var wishlistResult = await _dataService.GetWishListForUser(this.SelectedUser.Email);
            foreach (var giftModel in wishlistResult)
            {
                UserWishlist.Add(giftModel);
            }
        }
    }
}
