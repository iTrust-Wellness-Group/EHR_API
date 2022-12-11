using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHR.Shared.Utils.MongoDB
{
    internal interface IMongoDBContext
    {
        // Get the specified database
        IMongoDatabase GetDatabase(string databaseName);

        // Get the specified collection in the specified database
        IMongoCollection<T> GetCollection<T>(string databaseName, string collectionName);

        // Insert a single document
        void InsertOne<T>(string databaseName, string collectionName, T document);

        // Insert multiple documents
        void InsertMany<T>(string databaseName, string collectionName, IEnumerable<T> documents);

        // Update a single document
        void UpdateOne<T>(string databaseName, string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> update);

        // Update multiple documents
        void UpdateMany<T>(string databaseName, string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> update);

        // Delete a single document
        void DeleteOne<T>(string databaseName, string collectionName, FilterDefinition<T> filter);

        // Delete multiple documents
        void DeleteMany<T>(string databaseName, string collectionName, FilterDefinition<T> filter);
    }
}
