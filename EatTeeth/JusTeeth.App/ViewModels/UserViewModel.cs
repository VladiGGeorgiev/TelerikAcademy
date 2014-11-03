using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JusTeeth.Data;
using JusTeeth.Models;

namespace JusTeeth.App.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string Avatar { get; set; }

        public string FacebookProfile { get; set; }

        public string Department { get; set; }

        public string Workplace { get; set; }

        public ICollection<PlaceViewModel> LastPlaces { get; set; }

        public ICollection<UserFriendModel> Friends { get; set; }

        public ICollection<HungryGroupViewModel> GroupHistory { get; set; }

        public bool IsFriend(string username)
        {
            return this.Friends.Any(user => user.UserName == username);
        }

        public bool IsTogetherFriends(string username, string friend)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.FirstOrDefault(x => x.UserName == username);
                var dbFriend = context.Users.FirstOrDefault(x => x.UserName == friend);

                if (user.Friends.Any(x => x.UserName == friend) && dbFriend.Friends.Any(x => x.UserName == username))
                {
                    return true;
                }
            }

            return false;
        }
    }
}