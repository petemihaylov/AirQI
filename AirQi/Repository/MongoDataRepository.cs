using Aqi.Repository;
using System.Linq;
using Aqi.Settings;
using MongoDB.Driver;
using Aqi.Models.Data;
using System.Collections.Generic;
using Aqi.Models;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using MongoDB.Bson;

namespace Aqi.Repository
{
    public class MongoDataRepository<TDocument> : IMongoDataRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoDataRepository(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type type)
        {
            return ((BsonCollectionAttribute) type.GetCustomAttributes(
                typeof(BsonCollectionAttribute), true).FirstOrDefault())?.CollectionName;
        }

        // Returns all objects from the db.
        public IEnumerable<TDocument> GetAll()
        {
            return _collection.Find(doc => true).ToList();
        }

        // Returns all objects from the db Async.
        public async Task<IEnumerable<TDocument>> GetAllAsync()
        {
            return await Task.FromResult(GetAll());
        }

        // Returns all latest objects from db based on date.
        public IEnumerable<TDocument> GetAllLatest()
        {
            return _collection.Find(doc => true).ToList().OrderByDescending(doc => doc.UpdatedAt).GroupBy(doc => new { doc.Location }, (key, group) => group.First()).ToList();
        }

        // Returns all latest objects from db based on date Async.
        public async Task<IEnumerable<TDocument>> GetAllLatestAsync()
        {
            return await Task.FromResult(GetAllLatest());
        }

        // Returns an object by the bson _id of the record.
        public TDocument GetObjectById(string id)
        {
            var matches = _collection.Find(doc => doc.Id == new ObjectId(id)).ToList().OrderByDescending(doc => doc.UpdatedAt);
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
            document.CreatedAt = DateTime.UtcNow;
            document.UpdatedAt = DateTime.UtcNow;
            _collection.InsertOne(document);
        }

        // Creates a record from the model Async.
        public async Task CreateObjectAsync(TDocument document)
        {
            document.CreatedAt = DateTime.UtcNow;
            document.UpdatedAt = DateTime.UtcNow;
            await _collection.InsertOneAsync(document);
        }

        // Updates the record from the model by bson _id.
        public void UpdateObject(string id, TDocument document)
        {
            var objectId = new ObjectId(id);
            document.UpdatedAt = DateTime.UtcNow;
            _collection.ReplaceOne(doc => doc.Id == objectId, document);
        }

        // Updates the record from the model by bson _id Async.
        public async Task UpdateObjectAsync(string id, TDocument document)
        {
            var objectId = new ObjectId(id);
            document.UpdatedAt = DateTime.UtcNow;
            await _collection.ReplaceOneAsync(doc => doc.Id == objectId, document);
        }

        // Removes the record from the db.
        public void RemoveObject(TDocument document)
        {
            _collection.DeleteOne(doc => doc.Id == document.Id);
        }

        // Removes the record from the db Async.
        public async Task RemoveObjectAsync(TDocument document)
        {
            await _collection.DeleteOneAsync(doc => doc.Id == document.Id);
        }

        // Removes the record from the db based on the bason _id.
        public void RemoveObjectById(string id)
        {
            var objectId = new ObjectId(id);
            _collection.DeleteOne(doc => doc.Id == objectId);
        }

        // Removes the record from the db based on the bason _id Async.
        public async Task RemoveObjectByIdAsync(string id)
        {
            var objectId = new ObjectId(id);
            await _collection.DeleteOneAsync(doc => doc.Id == objectId);
        }

        // Filters the record by lambda.
        public IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).ToEnumerable();
        }
        
        // Filters the project expression.
        public IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression)
        {
            return _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
        }

        // Filters the first record.
        public TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).FirstOrDefault();
        }

        // Filters the collection Async.
        public async Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return await _collection.Find(filterExpression).FirstOrDefaultAsync();
        }

    }
}