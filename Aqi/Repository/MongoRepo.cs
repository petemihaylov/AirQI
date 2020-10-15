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


        public virtual IEnumerable<TDocument> GetAll()
        ***REMOVED***
            return _collection.Find(doc => true).ToList();
       ***REMOVED***

        public virtual Task<IEnumerable<TDocument>> GetAllAsync()
        ***REMOVED***
            return Task.Run( () =>
            ***REMOVED***
               return (IEnumerable<TDocument>) _collection.Find(doc => true).ToList();
           ***REMOVED***);
       ***REMOVED***

        public virtual TDocument GetObjectById(string id)
        ***REMOVED***
            var objectId = new ObjectId(id);
            return _collection.Find<TDocument>(doc => doc.Id == objectId).FirstOrDefault();
       ***REMOVED***

        public virtual Task<TDocument> GetObjectByIdAsync(string id)
        ***REMOVED***
            return Task.Run(() =>
            ***REMOVED***
                var objectId = new ObjectId(id);
                 return _collection.Find<TDocument>(doc => doc.Id == objectId).FirstOrDefault();
           ***REMOVED***);
       ***REMOVED***

        public virtual void CreateObject(TDocument document)
        ***REMOVED***
            _collection.InsertOne(document);
       ***REMOVED***

        public virtual Task CreateObjectAsync(TDocument document)
        ***REMOVED***
            return Task.Run(() => _collection.InsertOneAsync(document));
       ***REMOVED***

        public virtual void UpdateObject(string id, TDocument document)
        ***REMOVED***
            var objectId = new ObjectId(id);
            _collection.ReplaceOne(doc => doc.Id == objectId, document);
       ***REMOVED***

        public virtual Task UpdateObjectAsync(string id, TDocument document)***REMOVED***
            return Task.Run(() =>
            ***REMOVED***
                var objectId = new ObjectId(id);
                _collection.ReplaceOne(doc => doc.Id == objectId, document);
           ***REMOVED***);
       ***REMOVED***

        public void RemoveObject(TDocument document)
        ***REMOVED***
            _collection.DeleteOne(doc => doc.Id == document.Id);
       ***REMOVED***

        public virtual Task RemoveObjectAsync(TDocument document)
        ***REMOVED***
            return Task.Run(() =>
            ***REMOVED***
                _collection.DeleteOne(doc => doc.Id == document.Id);
           ***REMOVED***);
       ***REMOVED***

        public virtual void RemoveObjectById(string id)
        ***REMOVED***
            var objectId = new ObjectId(id);
            _collection.DeleteOne(doc => doc.Id == objectId);
       ***REMOVED***

        public virtual Task RemoveObjectByIdAsync(string id)
        ***REMOVED***
            return Task.Run(() =>
            ***REMOVED***
                var objectId = new ObjectId(id);
                _collection.DeleteOne(doc => doc.Id == objectId);
           ***REMOVED***);
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

   ***REMOVED***
***REMOVED***