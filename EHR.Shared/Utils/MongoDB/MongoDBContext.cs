using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Shared.Utils.MongoDB
{
    internal class MongoDBContext:IMongoDBContext
    {
        // Define a MongoClient object
        private  readonly MongoClient? _mongoClient = null;

        // Static constructor, used to initialize MongoClient object
        public MongoDBContext(IConfiguration configuration)
        {
            // Use MongoClient to connect to MongoDB database
            if(_mongoClient==null)
                _mongoClient = new MongoClient( "mongodb://localhost:27017");
        }

        public IMongoDatabase GetDatabase(string databaseName)
        {
            return _mongoClient!.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string databaseName, string collectionName)
        {
            var database = GetDatabase(databaseName);
            return database.GetCollection<T>(collectionName);
        }

        public void InsertOne<T>(string databaseName, string collectionName, T document)
        {
            var collection = GetCollection<T>(databaseName, collectionName);
            collection.InsertOne(document);
        }

        public void InsertMany<T>(string databaseName, string collectionName, IEnumerable<T> documents)
        {
            var collection = GetCollection<T>(databaseName, collectionName);
            collection.InsertMany(documents);
        }

        public void UpdateOne<T>(string databaseName, string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            var collection = GetCollection<T>(databaseName, collectionName);
            collection.UpdateOne(filter, update);
        }

        public void UpdateMany<T>(string databaseName, string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            var collection = GetCollection<T>(databaseName, collectionName);
            collection.UpdateMany(filter, update);
        }

        public void DeleteOne<T>(string databaseName, string collectionName, FilterDefinition<T> filter)
        {
            var collection = GetCollection<T>(databaseName, collectionName);
            collection.DeleteOne(filter);
        }

        public void DeleteMany<T>(string databaseName, string collectionName, FilterDefinition<T> filter)
        {
            var collection = GetCollection<T>(databaseName, collectionName);
            collection.DeleteMany(filter);
        }

    }
}
