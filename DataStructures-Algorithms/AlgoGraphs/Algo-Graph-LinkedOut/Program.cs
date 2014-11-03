using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_Graph_LinkedOut
{
    class Program
    {
        static Dictionary<string, User> users = new Dictionary<string, User>();
        static List<string> searchedFriends = new List<string>();
        static HashSet<string> visitedFriends = new HashSet<string>();
        static int searchedFriendsCount;
        static Queue<int> results;
        
        static void Main(string[] args)
        {
            #region Parse input
            string user = Console.ReadLine();

            int Nconnections = int.Parse(Console.ReadLine());

            for (int i = 0; i < Nconnections; i++)
            {
                string[] connection = Console.ReadLine().Split(' ');
                string firstUser = connection[0];
                string secondUser = connection[1];

                if (users.ContainsKey(firstUser) && users.ContainsKey(secondUser))
                {
                    users[firstUser].AddFriend(users[secondUser]);
                    users[secondUser].AddFriend(users[firstUser]);
                }
                else if (users.ContainsKey(firstUser))
                {
                    User childUser = new User(secondUser);
                    users.Add(childUser.Value, childUser);
                    users[firstUser].AddFriend(users[secondUser]);
                    users[secondUser].AddFriend(users[firstUser]);
                }
                else if (users.ContainsKey(secondUser))
                {
                    User parentUser = new User(firstUser);
                    users.Add(parentUser.Value, parentUser);
                    users[firstUser].AddFriend(users[secondUser]);
                    users[secondUser].AddFriend(users[firstUser]);
                }
                else
                {
                    User childUser = new User(secondUser);
                    User parentUser = new User(firstUser);
                    users.Add(childUser.Value, childUser);
                    users.Add(parentUser.Value, parentUser);
                    users[firstUser].AddFriend(users[secondUser]);
                    users[secondUser].AddFriend(users[firstUser]);
                }
            }

            searchedFriendsCount = int.Parse(Console.ReadLine());
            results = new Queue<int>(searchedFriendsCount);
            for (int i = 0; i < searchedFriendsCount; i++)
            {
                searchedFriends.Add(Console.ReadLine());
            }
            #endregion

            for (int i = 0; i < searchedFriends.Count; i++)
            {
                if (!users.ContainsKey(user))
                {
                    for (int j = 0; j < searchedFriends.Count; j++)
                    {
                        Console.WriteLine(-1);
                    }
                    return;
                }

                DFS(users[user], searchedFriends[i], 0);
                if (results.Count > 0)
                {
                    Console.WriteLine(results.Dequeue());
                }
                else
                {
                    Console.WriteLine(-1);
                }
                visitedFriends.Clear();
            }
        }
  
        /// <summary>
        /// DFSs the specified users.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <param name="searchedFriends">The searched friends.</param>
        private static void DFS(User user, string searchedFriend, int level)
        {
            Queue<Tuple<User, int>> queue = new Queue<Tuple<User, int>>();
            queue.Enqueue(new Tuple<User, int>(user, 0));
            visitedFriends.Add(user.Value);

            while (queue.Count > 0)
            {
                var curentFriend = queue.Dequeue();

                if (curentFriend.Item1.Value == searchedFriend)
                {
                    results.Enqueue(curentFriend.Item2);
                    break;
                }

                foreach (var friend in curentFriend.Item1.Friends)
                {
                    if (!visitedFriends.Contains(friend.Value))
                    {
                        queue.Enqueue(new Tuple<User, int>(friend, curentFriend.Item2 + 1));
                        visitedFriends.Add(friend.Value);
                    }
                }
            }
        }
    }
}
