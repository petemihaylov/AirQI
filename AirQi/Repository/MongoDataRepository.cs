using AirQi.Repository;
using System.Linq;
using AirQi.Settings;
using MongoDB.Driver;
using AirQi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using MongoDB.Bson;

namespace AirQi.Repository
***REMOVED***
    public class MongoDataRepository<TDocument> : IMongoDataRepository<TDocument> where TDocument : IDocument
    ***REMOVED***
        private readonly IMongoCollection<TDocument> _collection;

        public MongoDataRepository(IMongoDbSettings settings)
        ***REMOVED***
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
       ***REMOVED***

        private protected string GetCollectionName(Type type)
        ***REMOVED***
            return ((BsonCollectionAttribute) type.GetCustomAttributes(
                typeof(BsonCollectionAttribute), true).FirstOrDefault())?.CollectionName;
       ***REMOVED***

        // Returns all objects from the db.
        public IEnumerable<TDocument> GetAll()
        ***REMOVED***
            return _collection.Find(doc => true).ToList();
       ***REMOVED***

        // Returns all objects from the db Async.
        public async Task<IEnumerable<TDocument>> GetAllAsync()
        ***REMOVED***
            return await Task.FromResult(GetAll());
       ***REMOVED***

        // Returns all latest objects from db based on date.
        public IEnumerable<TDocument> GetAllLatest()
        ***REMOVED***
            return _collection.Find(doc => true).ToList().OrderByDescending(doc => doc.UpdatedAt).ToList();
            // return _collection.Find(doc => true).ToList().OrderByDescending(doc => doc.UpdatedAt).GroupBy(doc => new ***REMOVED*** doc.Location***REMOVED***, (key, group) => group.First()).ToList();
       ***REMOVED***

        // Returns all latest objects from db based on date Async.
        public async Task<IEnumerable<TDocument>> GetAllLatestAsync()
        ***REMOVED***
            return await Task.FromResult(GetAllLatest());
       ***REMOVED***

        // Returns an object by the bson _id of the record.
        public TDocument GetObjectById(string id)
        ***REMOVED***
            var matches = _collection.Find(doc => doc.Id == new ObjectId(id)).ToList().OrderByDescending(doc => doc.UpdatedAt);
            return matches.FirstOrDefault();
       ***REMOVED***

        // Returns an object by the bson _id of the record Async.
        public async Task<TDocument> GetObjectByIdAsync(string id)
        ***REMOVED***
            return await Task.FromResult(GetObjectById(id));
       ***REMOVED***

        // Creates a record from the model.
        public void CreateObject(TDocument document)
        ***REMOVED***
            _collection.InsertOne(document);
       ***REMOVED***

        // Creates a record from the model Async.
        public async Task CreateObjectAsync(TDocument document)
        ***REMOVED***
            await _collection.InsertOneAsync(document);
       ***REMOVED***

        // Updates the record from the model by bson _id.
        public void UpdateObject(string id, TDocument document)
        ***REMOVED***
            document.UpdatedAt = DateTime.UtcNow;
            _collection.ReplaceOne(doc => doc.Id == new ObjectId(id), document);
       ***REMOVED***

        // Updates the record from the model by bson _id Async.
        public async Task UpdateObjectAsync(string id, TDocument document)
        ***REMOVED***
            document.UpdatedAt = DateTime.UtcNow;
            await _collection.ReplaceOneAsync(doc => doc.Id == new ObjectId(id), document);
       ***REMOVED***

        // Removes the record from the db.
        public void RemoveObject(TDocument document)
        ***REMOVED***
            _collection.DeleteOne(doc => doc.Id == document.Id);
       ***REMOVED***

        // Removes the record from the db Async.
        public async Task RemoveObjectAsync(TDocument document)
        ***REMOVED***
            await _collection.DeleteOneAsync(doc => doc.Id == document.Id);
       ***REMOVED***

        // Removes the record from the db based on the bason _id.
        public void RemoveObjectById(string id)
        ***REMOVED***
            _collection.DeleteOne(doc => doc.Id == new ObjectId(id));
       ***REMOVED***

        // Removes the record from the db based on the bason _id Async.
        public async Task RemoveObjectByIdAsync(string id)
        ***REMOVED***
            await _collection.DeleteOneAsync(doc => doc.Id == new ObjectId(id));
       ***REMOVED***

        // Filters the record by lambda.
        public IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression)
        ***REMOVED***
            return _collection.Find(filterExpression).ToEnumerable();
       ***REMOVED***
        
        // Filters the project expression.
        public IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression)
        ***REMOVED***
            return _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
       ***REMOVED***

        // Filters the first record.
        public TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
        ***REMOVED***
            return _collection.Find(filterExpression).FirstOrDefault();
       ***REMOVED***

        // Filters the collection Async.
        public async Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        ***REMOVED***
            return await _collection.Find(filterExpression).FirstOrDefaultAsync();
       ***REMOVED***

   ***REMOVED***
***REMOVED***