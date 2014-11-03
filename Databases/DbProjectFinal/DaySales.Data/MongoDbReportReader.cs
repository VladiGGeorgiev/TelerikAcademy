using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections;
using MongoDB.Bson;
using Supermarket.Model;

namespace Supermarket.Data
{
    public class MongoDbReportReader
    {
        public static string DbName { get; private set; }
        public static string CollectionNaMe
        {
            get { return collectionName; }
            set
            {
                collectionName = value;
                entries = database.GetCollection<JSonReport>(collectionName);
            }
        }

        private static string collectionName;
        private static string connectionString;
        private static MongoClient client;
        private static MongoServer server;
        private static MongoDatabase database;
        private static MongoCollection<JSonReport> entries;

        public static void SetInitialData(string connStr, string dbName, string initialCollection)
        {
            connectionString = connStr;
            DbName = dbName;
            collectionName = initialCollection;
        }

        public static void EstablishConnection()
        {
            client = new MongoClient(connectionString);
            server = client.GetServer();
            database = server.GetDatabase(DbName);
            entries = database.GetCollection<JSonReport>(collectionName);
        }

        public static IList<JSonReport> GetReportList()
        {
            return ToList(entries.FindAllAs<JSonReport>());
        }

        private static IList<JSonReport> ToList(MongoCursor<JSonReport> cursor)
        {
            List<JSonReport> resultAsList = new List<JSonReport>();

            foreach (var item in cursor)
            {
                resultAsList.Add(item);
            }

            return resultAsList;
        }
    }
}


