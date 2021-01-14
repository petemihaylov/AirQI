using AirQi.Repository;
using System.Linq;
using AirQi.Settings;
using MongoDB.Driver;
using AirQi.Models.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using MongoDB.Bson;

namespace AirQi.Data
{
    public class MockDataRepository<TDocument> : IMockDataRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MockDataRepository(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            this._collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type type)
        {
            return ((BsonCollectionAttribute) type.GetCustomAttributes(
                typeof(BsonCollectionAttribute), true).FirstOrDefault())?.CollectionName;
        }

        // Returns all objects from the db.
        public IEnumerable<TDocument> GetAll()
        {
            return this._collection.Find(doc => true).ToList();
        }

        // Returns all objects from the db Async.
        public async Task<IEnumerable<TDocument>> GetAllAsync()
        {
            return await this._collection.Find(doc => true).ToListAsync();
        }

        // Returns all latest objects from db based on date.
        public IEnumerable<TDocument> GetAllLatest()
        {
            return this._collection.Find(doc => true).ToList().OrderByDescending(doc => doc.UpdatedAt).GroupBy(doc => new { doc.Coordinates }, (key, group) => group.First());
        }

        // Returns all latest objects from db based on date Async.
        public async Task<IEnumerable<TDocument>> GetAllLatestAsync()
        {
            return await Task.FromResult(GetAllLatest());
        }

        // Returns an object by the bson _id of the record.
        public TDocument GetObjectById(string id)
        {
            var matches = this._collection.Find(doc => doc.Id == new ObjectId(id)).ToList().OrderByDescending(doc => doc.UpdatedAt);
            return matches.FirstOrDefault();
        }

        // Returns an object by the bson _id of the record Async.
        public async Task<TDocument> GetObjectByIdAsync(string id)
        {
            return await Task.FromResult(GetObjectById(id));
        }

        // Creates a record from the model.
        public void CreateObject(TDocument document)
        {
            this._collection.InsertOne(document);
        }

        // Creates a record from the model Async.
        public async Task CreateObjectAsync(TDocument document)
        {
            await this._collection.InsertOneAsync(document);
        }

        // Updates the record from the model by bson _id.
        public void UpdateObject(string id, TDocument document)
        {
            document.UpdatedAt = DateTime.UtcNow;
            this._collection.ReplaceOne(doc => doc.Id == new ObjectId(id), document);
        }

        // Updates the record from the model by bson _id Async.
        public async Task UpdateObjectAsync(string id, TDocument document)
        {
            document.UpdatedAt = DateTime.UtcNow;
            await this._collection.ReplaceOneAsync(doc => doc.Id == new ObjectId(id), document);
        }

        // Removes the record from the db.
        public void RemoveObject(TDocument document)
        {
            this._collection.DeleteOne(doc => doc.Id == document.Id);
        }

        // Removes the record from the db Async.
        public async Task RemoveObjectAsync(TDocument document)
        {
            await this._collection.DeleteOneAsync(doc => doc.Id == document.Id);
        }

        // Removes the record from the db based on the bason _id.
        public void RemoveObjectById(string id)
        {
            this._collection.DeleteOne(doc => doc.Id == new ObjectId(id));
        }

        // Removes the record from the db based on the bason _id Async.
        public async Task RemoveObjectByIdAsync(string id)
        {
            await this._collection.DeleteOneAsync(doc => doc.Id == new ObjectId(id));
        }

        // Filters the record by lambda.
        public IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression)
        {
            return this._collection.Find(filterExpression).ToEnumerable();
        }
        
        // Filters the project expression.
        public IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression)
        {
            return this._collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
        }

        // Filters the first record.
        public TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            return this._collection.Find(filterExpression).FirstOrDefault();
        }

        // Filters the collection Async.
        public async Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return await this._collection.Find(filterExpression).FirstOrDefaultAsync();
        }

    }
}