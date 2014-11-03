using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Giftable.Library.Model;
using Giftable.Library.Services;
using Newtonsoft.Json;

namespace Giftable.Library.ViewModel
{
    public class ItemsPageViewModel: ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;
        private string inviteEmail;
        private RelayCommand _inviteCommand;
        private RelayCommand<object> _selectedUser;
        private string _avatar;

        public ObservableCollection<GiftModel> Wishlist { get; set; }

        public string Avatar
        {
            get { return _avatar; }
            set { _avatar = value; RaisePropertyChanged(() => Avatar); }
        }

        //public ObservableCollection<UserModel> UserList { get { return AppCache.UserList; } }

        public ObservableCollection<FriendModel> Friends { get; set; }

        public string InviteEmail
        {
            get { return inviteEmail; }
            set
            {
                inviteEmail = value; RaisePropertyChanged(() => InviteEmail);
            }
        }


        public RelayCommand InviteCommand
        {
            get
            {
                return _inviteCommand
                    ?? (_inviteCommand = new RelayCommand(ExecuteInviteCommand));
            }
        }

        private async void  ExecuteInviteCommand()
        {
            //Friends.Add(new FriendModel()
            //    {
            //        Email = this.inviteEmail
            //    });
            var response = await _dataService.MakeFriendsWith(this.inviteEmail);
            if (response.IsSuccessStatusCode)
            {
                Friends.Add(JsonConvert.DeserializeObject<FriendModel>(await response.Content.ReadAsStringAsync()));
            }
        }

        public RelayCommand<object> SelectedUserCommand
        {
            get
            {
                return _selectedUser
                    ?? (_selectedUser = new RelayCommand<object>(ExecuteSelectedUserCommand));
            }
        }

        private void ExecuteSelectedUserCommand(object obj)
        {
            _navigationService.Navigate("SplitPage", obj);
        }


        public ItemsPageViewModel(INavigationService navigationService, IDataService dataService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            Wishlist = new ObservableCollection<GiftModel>();
            Friends = new ObservableCollection<FriendModel>();
            LoadData();
        }

        private async void LoadData()
        {
            var friends = await _dataService.GetFriends();
            foreach (var friendModel in friends)
            {
                Friends.Add(friendModel);
            }

            var result = await _dataService.GetWishList();
            foreach (var giftModel in result)
            {
                Wishlist.Add(giftModel);
            }
        }
    }
}
