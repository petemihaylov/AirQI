using Aqi.Repository;
using System.Linq;
using Aqi.Settings;
using MongoDB.Driver;
using Aqi.Models.Models;
using System.Collections.Generic;
using Aqi.Models;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using MongoDB.Bson;

namespace Aqi.Repository
***REMOVED***
    public class MongoRepo<TDocument> : IMongoRepo<TDocument> where TDocument : IDocument
    ***REMOVED***
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepo(IMongoDbSettings settings)
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

        public IQueryable<TDocument> AsQueryable()
        ***REMOVED***
            return _collection.AsQueryable();
       ***REMOVED***

        public virtual IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression)
        ***REMOVED***
            return _collection.Find(filterExpression).ToEnumerable();
       ***REMOVED***

        public virtual IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression)
        ***REMOVED***
            return _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
       ***REMOVED***

        public virtual TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
        ***REMOVED***
            return _collection.Find(filterExpression).FirstOrDefault();
       ***REMOVED***

        public virtual Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        ***REMOVED***
            return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
       ***REMOVED***

        public virtual TDocument FindById(string id)
        ***REMOVED***
            var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            return _collection.Find(filter).SingleOrDefault();
       ***REMOVED***

        public virtual Task<TDocument> FindByIdAsync(string id)
        ***REMOVED***
            return Task.Run(() =>
            ***REMOVED***
                var objectId = new ObjectId(id);
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
                return _collection.Find(filter).SingleOrDefaultAsync();
           ***REMOVED***);
       ***REMOVED***


        public virtual void InsertOne(TDocument document)
        ***REMOVED***
            _collection.InsertOne(document);
       ***REMOVED***

        public virtual Task InsertOneAsync(TDocument document)
        ***REMOVED***
            return Task.Run(() => _collection.InsertOneAsync(document));
       ***REMOVED***

        public void InsertMany(ICollection<TDocument> documents)
        ***REMOVED***
            _collection.InsertMany(documents);
       ***REMOVED***


        public virtual async Task InsertManyAsync(ICollection<TDocument> documents)
        ***REMOVED***
            await _collection.InsertManyAsync(documents);
       ***REMOVED***

        public void ReplaceOne(TDocument document)
        ***REMOVED***
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            _collection.FindOneAndReplace(filter, document);
       ***REMOVED***

        public virtual async Task ReplaceOneAsync(TDocument document)
        ***REMOVED***
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            await _collection.FindOneAndReplaceAsync(filter, document);
       ***REMOVED***

        public void DeleteOne(Expression<Func<TDocument, bool>> filterExpression)
        ***REMOVED***
            _collection.FindOneAndDelete(filterExpression);
       ***REMOVED***

        public Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        ***REMOVED***
            return Task.Run(() => _collection.FindOneAndDeleteAsync(filterExpression));
       ***REMOVED***

        public void DeleteById(string id)
        ***REMOVED***
            var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            _collection.FindOneAndDelete(filter);
       ***REMOVED***

        public Task DeleteByIdAsync(string id)
        ***REMOVED***
            return Task.Run(() =>
            ***REMOVED***
                var objectId = new ObjectId(id);
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
                _collection.FindOneAndDeleteAsync(filter);
           ***REMOVED***);
       ***REMOVED***

        public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression)
        ***REMOVED***
            _collection.DeleteMany(filterExpression);
       ***REMOVED***

        public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
        ***REMOVED***
            return Task.Run(() => _collection.DeleteManyAsync(filterExpression));
       ***REMOVED***

   ***REMOVED***
***REMOVED***