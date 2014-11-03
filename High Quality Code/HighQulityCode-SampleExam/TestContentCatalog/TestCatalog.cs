using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContentCatalog;
using ContentCatalog.Enumerations;
using System.Collections;
using System.Collections.Generic;

namespace TestContentCatalog
{
    [TestClass]
    public class TestCatalog
    {
        [TestMethod]
        public void TestAddSingleContentItem()
        {
            Catalog catalog = new Catalog();
            Content content = new Content(ContentType.Book, new string[] {"Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info"});
            catalog.Add(content);

            Assert.AreEqual(1, catalog.Count);
        }

        [TestMethod]
        public void TestAddMultipleDifferentContentItems()
        {
            Catalog catalog = new Catalog();
            Content contentBook = new Content(ContentType.Book, new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            Content contentMovie = new Content(ContentType.Movie, new string[] { "Fast and Furious", "American Movies", "92752320", "http://www.fastandfurious.com" });
            catalog.Add(contentBook);
            catalog.Add(contentMovie);

            Assert.AreEqual(2, catalog.Count);
        }

        [TestMethod]
        public void TestAddMultipleSameContentItems()
        {
            Catalog catalog = new Catalog();
            Content contentBook = new Content(ContentType.Book, 
                new string[] 
                {
                    "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info"
                });
            Content contentBook2 = new Content(ContentType.Book, 
                new string[]
                {
                    "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info"
                });
            Content contentBook3 = new Content(ContentType.Movie, 
                new string[]
                {
                    "Leonardo ciffer", "Dan Brown", "23922539", "http://www.introprogramming.info"
                });
            catalog.Add(contentBook);
            catalog.Add(contentBook3);
            catalog.Add(contentBook2);

            Assert.AreEqual(3, catalog.Count);
            //Count returns 2. I don't know why.
            // MultiDictionary Count Summary:
            //     Gets the number of key-value pairs in the dictionary. Each value associated
            //     with a given key is counted. If duplicate values are permitted, each duplicate
            //     value is included in the count.
        }

        [TestMethod]
        public void TestAddWithOneObjectAddedThreeTimes()
        {
            Catalog catalog = new Catalog();
            Content contentBook = new Content(ContentType.Book,
                new string[] 
                {
                    "Intro C#", "S.Nakova", "12763892", "http://www.introprogramming.info"
                });
            catalog.Add(contentBook);
            catalog.Add(contentBook);
            catalog.Add(contentBook);

            Assert.AreEqual(3, catalog.Count);
            //Count returns 1. I don't know why.
            // MultiDictionary Count Summary:
            //     Gets the number of key-value pairs in the dictionary. Each value associated
            //     with a given key is counted. If duplicate values are permitted, each duplicate
            //     value is included in the count.
        }

        [TestMethod]
        public void TestUpdateContent()
        {
        }

    }
}
