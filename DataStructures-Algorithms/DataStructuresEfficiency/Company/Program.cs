using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedMultiDictionary<decimal, Article> articles = 
                new OrderedMultiDictionary<decimal, Article>(true);

            articles.Add(12.43m, new Article("Choco", "123124234", "Milka", 12.43m));
            articles.Add(14.43m, new Article("Natural", "123124234", "Milka", 14.43m));
            articles.Add(15.43m, new Article("Raffy", "123124234", "Milka", 15.43m));
            articles.Add(17.43m, new Article("Milk", "123124234", "Milka", 17.43m));
            articles.Add(18.43m, new Article("Sugar", "123124234", "Milka", 18.43m));
            articles.Add(19.43m, new Article("Bread", "123124234", "Milka", 19.43m));
            articles.Add(20.43m, new Article("Susam", "123124234", "Milka", 20.43m));
            articles.Add(23.43m, new Article("Paper", "123124234", "Milka", 23.43m));
            articles.Add(25.43m, new Article("Grape", "123124234", "Milka", 25.43m));
            articles.Add(54.43m, new Article("Banana", "123124234", "Milka", 54.43m));
            articles.Add(43.43m, new Article("Orange", "123124234", "Milka", 43.43m));
            articles.Add(32.43m, new Article("Melon", "123124234", "Milka", 32.43m));
            articles.Add(24.43m, new Article("WaterMelon", "123124234", "Milka", 24.43m));
            articles.Add(76.43m, new Article("Junk", "123124234", "Milka", 76.43m));

            var rangeArticles = articles.Range(20m, true, 35m, true);
            foreach (var article in rangeArticles)
            {
                foreach (var item in article.Value)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
