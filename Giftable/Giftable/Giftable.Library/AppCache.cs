using System.Collections.ObjectModel;
using Giftable.Library.Model;

namespace Giftable.Library
{
    public static class AppCache
    {
        private static ObservableCollection<UserModel> _userList = new ObservableCollection<UserModel>();
        public static ObservableCollection<UserModel> UserList
        {
            get { return _userList; }
            set { _userList = value; }
        }
    }
}
