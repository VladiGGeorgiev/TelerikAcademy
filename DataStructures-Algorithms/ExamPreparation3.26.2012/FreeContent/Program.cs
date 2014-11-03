using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace FreeContent
{
    class Content : IComparable
    {
        public Content(string title, string author, long size, string url, string type)
        {
            this.Title = title;
            this.Author = author;
            this.Size = size;
            this.Url = url;
            this.Type = type;
        }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        public string Url { get; set; }

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo((obj as Content).ToString());
        }

        public override string ToString()
        {
            return this.Type + ": " + this.Title + "; " + this.Author + "; " + this.Size + "; " + this.Url;
        }
    }

    class Program
    {
        static OrderedMultiDictionary<string, Content> contents = new OrderedMultiDictionary<string, Content>(true);
        static MultiDictionary<string, Content> contentUrls = new MultiDictionary<string, Content>(true);
        static StringBuilder sb = new StringBuilder();

        private static void CommandParser()
        {
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] tokens = line.Split(new char[] {':'}, 2);

                if (tokens[0] == "Find")
                {
                    FindCommandProcess(tokens[1]);
                }
                else if (tokens[0].Contains("Add"))
                {
                    AddCommandProcess(tokens);
                }
                else if (tokens[0] == "Update")
                {
                    UpdateCommandProcess(tokens[1].Trim());
                }
                else
                {
                    return;
                }

                line = Console.ReadLine();
            }
        }
  
        /// <summary>
        /// Updates the command process.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        private static void UpdateCommandProcess(string line)
        {
            string[] urls = line.Split(';');
            string oldUrl = urls[0].Trim();
            string newUrl = urls[1].Trim();

            if (contentUrls.ContainsKey(oldUrl))
            {
                int count = 0;//contentUrls[oldUrl].Count;
                foreach (var item in contentUrls[oldUrl].ToArray())
                {
                    contents.Remove(item.Title, item);
                    item.Url = newUrl;
                    contents.Add(item.Title, item);
                    count++;
                    contentUrls.Add(item.Url, item);
                }
                contentUrls.Remove(oldUrl);

                sb.AppendLine(count + " items updated");
            }
            else
            {
                sb.AppendLine("0 items updated");
            }
        }
  
        /// <summary>
        /// Adds the command process.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        private static void AddCommandProcess(string[] line)
        {
            string type = line[0].Split(' ')[1].Trim();
            string upperLetterType = char.ToUpper(type[0]) + type.Substring(1);

            string content = line[1].Trim();
            string[] tokens = content.Split(';');

            string title = tokens[0].Trim();
            string author = tokens[1].Trim();
            long size = long.Parse(tokens[2].Trim());
            string url = tokens[3].Trim();

            contents.Add(title, new Content(title, author, size, url, upperLetterType));
            contentUrls.Add(url, new Content(title, author, size, url, upperLetterType));
            string typeOutput = char.ToUpper(type[0]) + type.Substring(1);
            sb.AppendLine(typeOutput + " added");
        }
  
        /// <summary>
        /// Finds the command process.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        private static void FindCommandProcess(string line)
        {
            string[] tokens = line.Split(';');
            string title = tokens[0].Trim();
            int count = int.Parse(tokens[1]);

            if (contents.ContainsKey(title))
            {
                var list = 
                    from content 
                    in contents[title] 
                    select content;
                var firstElements = list.Take(count);

                foreach (var item in firstElements)
                {
                    sb.AppendLine(item.ToString());
                }
            }
            else
            {
                sb.AppendLine("No items found");
            }
        }

        static void Main(string[] args)
        {
            CommandParser();
            Console.WriteLine(sb);
        }
    }
}
