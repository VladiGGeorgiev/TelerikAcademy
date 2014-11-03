using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algo_Graph_LinkedOut
{
    public class User
    {
        private string value;
        private List<User> friends;

        public User(string value)
        {
            this.value = value;
            this.friends = new List<User>();
        }

        public string Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public List<User> Friends
        {
            get
            {
                return this.friends;
            }
        }

        public int FriendsNumber
        {
            get
            {
                return friends.Count;
            }
        }

        public void AddFriend(User child)
        {
            friends.Add(child);
        }
    }
}
