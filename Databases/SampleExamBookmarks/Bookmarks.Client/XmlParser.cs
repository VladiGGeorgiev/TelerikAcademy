using Bookmarks.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;
using System.Xml.Serialization;

namespace Bookmarks.Client
{
    internal static class XmlParser
    {
        public static void ParseXml()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("../../bookmarks.xml");
            string pathQuery = "/bookmarks/bookmark";

            XmlNodeList xmlBookmarks = xmlDocument.SelectNodes(pathQuery);

            foreach (XmlNode bookmark in xmlBookmarks)
            {
                string username = bookmark.GetInnerText("username");
                if (username == null)
                {
                    throw new ArgumentNullException("The username is null!");
                }

                string title = bookmark.GetInnerText("title");
                if (title == null)
                {
                    throw new ArgumentNullException("The title is null!");
                }

                string url = bookmark.GetInnerText("url");
                if (url == null)
                {
                    throw new ArgumentNullException("The url is null!");
                }

                string tags = bookmark.GetInnerText("tags");
                string notes = bookmark.GetInnerText("notes");
                string[] allTags = {};
                if (tags != null)
                {
                    allTags = tags.Split(',');
                    for (int index = 0; index < allTags.Length; index++)
                    {
                        allTags[index] = allTags[index].Trim();
                    }
                }

                InsertData(username, title, url, allTags, notes);
            }
        }

        public static string GetInnerText(this XmlNode node, string tagName)
        {
            var childNode = node.SelectSingleNode(tagName);
            if (childNode == null)
            {
                return null;
            }

            return childNode.InnerText;
        }

        public static void InsertData(string username, string title, string url, string[] tags, string notes)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, 
                new TransactionOptions{ IsolationLevel = IsolationLevel.RepeatableRead }))
            {
                var context = new BookmarksEntities();
                User user = CreateOrLoadUser(context, username);
                var bookmark = new Bookmark { User = user, Title = title, Notes = notes, Url = url };

                foreach (var tagName in tags)
                {
                    var tag = CreateOrLoadTag(context, tagName);
                    bookmark.Tags.Add(tag);
                }

                context.Bookmarks.Add(bookmark);
                context.SaveChanges();
            }
        }

        private static Tag CreateOrLoadTag(BookmarksEntities context, string tagName)
        {
            var tag = context.Tags.FirstOrDefault(x => x.TagName == tagName);
            if (tag != null)
            {
                return tag;
            }

            var newTag = new Tag()
            {
                TagName = tagName
            };
            context.Tags.Add(newTag);
            context.SaveChanges();
            return newTag;
        }

        private static User CreateOrLoadUser(BookmarksEntities context, string username)
        {
            var user = context.Users.FirstOrDefault(x => x.Username == username);
            if (user != null)
            {
                return user;
            }

            var newUser = new User()
            {
                Username = username
            };
            context.Users.Add(newUser);
            context.SaveChanges();
            return newUser;
        }

        public static void ExecureQueriesFromXml(string filePath)
        {
            BookmarksEntities context = new BookmarksEntities();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("../../query.xml");
            string pathQuery = "/query";

            XmlNodeList xmlQuery = xmlDocument.SelectNodes(pathQuery);

            foreach (XmlNode node in xmlQuery)
            {
                string username = node.GetInnerText("username");
                string tag = node.GetInnerText("tag");

                var query =
                    from b in context.Bookmarks
                    select b;

                if (username != null)
                {
                    query = context.Bookmarks.Where(x => x.User.Username == username);
                }

                query = query.Where(b => b.Tags.Any(t => t.TagName == tag));
                query = query.OrderBy(x => x.Url);

                foreach (var bookmark in query.ToList())
                {
                    Console.WriteLine(bookmark.Url);
                }
            }
        }
    }
}