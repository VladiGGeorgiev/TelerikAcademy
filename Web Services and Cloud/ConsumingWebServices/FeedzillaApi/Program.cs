using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace FeedzillaApi
{
    class Program
    {
        private async static Task<HashSet<Article>> GetArticles(HttpClient client, string queryString, int resultsCount)
        {
            var response = await client.GetAsync("?q=" + queryString + "&count=" + resultsCount);
            var jsonArticlesTask = await response.Content.ReadAsStringAsync();
            var articles = DeSerializeArticles(jsonArticlesTask);

            return articles.Articles;
        }

        private static ArticlesCollection DeSerializeArticles(string jsonArticles)
        {
            var articles = JsonConvert.DeserializeObject<ArticlesCollection>(jsonArticles);
            return articles;
        }

        static void Main(string[] args)
        {
            //Read input
            Console.Write("Enter the query sting search: ");
            string queryString = Console.ReadLine();
            Console.Write("Enter the number of results: ");
            int resultsCount = int.Parse(Console.ReadLine());

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.feedzilla.com/v1/articles/search.json");

            var articlesTask = GetArticles(client, queryString, resultsCount);
            foreach (var article in articlesTask.Result)
            {
                Console.WriteLine(article + Environment.NewLine);
            }
        }
    }
}
