
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Linq.Expressions;

using AutoMapper;
using AirQi.Models.Core;
using AirQi.Repository;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AirQi.Data
***REMOVED***
    public class MockDataRepository<TDocument> : IMongoDataRepository<TDocument> where TDocument : IDocument
    ***REMOVED***
        private static readonly Random _random = new Random(Seed: 0);
        private readonly ConcurrentDictionary<string, List<TDocument>> _collection;
        private readonly IMapper _mapper;

        public MockDataRepository(IMapper mapper)
        ***REMOVED***
            _mapper = mapper;
       ***REMOVED***

        private static Station MockStation()
        ***REMOVED***

            var latitude = (_random.NextDouble() * (53.2193835 - 51.1913202)) + 51.1913202;
            var longitude = (_random.NextDouble() * (6.8936619 - 4.4777325)) + 4.4777325;


            double[] position = new double[] ***REMOVED*** latitude, longitude***REMOVED***;

            var station = new Station
            ***REMOVED***

                Id = new ObjectId(NewSeeder().ToString().Substring(0, 8)),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Position = position,
                Aqi = _random.NextDouble(),
                // https://github.com/vivet/GoogleApi
                Location = "Netherlands",
                City = "",
                Country = "Netherlands",
                Measurements = Enumerable.Range(0, _random.Next(4, 5)).Select(m => MockMeasurement()).ToList()
           ***REMOVED***;

            return station;
       ***REMOVED***

        private static Measurement MockMeasurement()
        ***REMOVED***
            var measuerment = new Measurement
            ***REMOVED***
                Parameter = "aqi",
                Value = _random.Next(50, 150),
                LastUpdated = DateTime.UtcNow.ToString(),
                Unit = "µg/m³",
                SourceName = "MockData"
           ***REMOVED***;

            return measuerment;
       ***REMOVED***

        private static Guid NewSeeder()
        ***REMOVED***
            var bytes = new byte[16];
            _random.NextBytes(buffer: bytes);

            return new Guid(bytes);
       ***REMOVED***

        // Returns all objects from the db.
        public IEnumerable<TDocument> GetAll()
        ***REMOVED***
             var stations = this._collection.Values.SelectMany(x => x);
            stations = stations.OrderByDescending(x => x.UpdatedAt).ThenByDescending(x => x.CreatedAt);

            return stations.ToList();
       ***REMOVED***

        // Returns all objects from the db Async.
        public async Task<IEnumerable<TDocument>> GetAllAsync()
        ***REMOVED***
            return await Task.FromResult(GetAll());
       ***REMOVED***

        // Returns all latest objects from db based on date.
        public IEnumerable<TDocument> GetAllLatest()
        ***REMOVED***
            return GetAll();
       ***REMOVED***

        // Returns all latest objects from db based on date Async.
        public async Task<IEnumerable<TDocument>> GetAllLatestAsync()
        ***REMOVED***
            return await Task.FromResult(GetAllLatest());
       ***REMOVED***

        // Returns an object by the bson _id of the record.
        public TDocument GetObjectById(string id)
        ***REMOVED***
            foreach (var (Id, stations) in this._collection)
            ***REMOVED***
                foreach (var station in stations)
                ***REMOVED***
                    if (station.Id == new MongoDB.Bson.ObjectId(id))
                    ***REMOVED***
                        return station;
                   ***REMOVED***
               ***REMOVED***
           ***REMOVED***

            return default(TDocument);
       ***REMOVED***

        // Returns an object by the bson _id of the record Async.
        public async Task<TDocument> GetObjectByIdAsync(string id)
        ***REMOVED***
            return await Task.FromResult(GetObjectById(id));
       ***REMOVED***

        // Creates a record from the model.
        public void CreateObject(TDocument document)
        ***REMOVED***
            this._collection.AddOrUpdate(document.Id.ToString(), new List<TDocument> ***REMOVED*** document***REMOVED***, (id, stations) =>
            ***REMOVED***
                lock (stations)
                ***REMOVED***
                    stations.Add(item: document);
               ***REMOVED***

                return stations;
           ***REMOVED***);
       ***REMOVED***

        // Creates a record from the model Async.
        public async Task CreateObjectAsync(TDocument document)
        ***REMOVED***
            await Task.Run(() => CreateObject(document));
       ***REMOVED***

        // Updates the record from the model by bson _id.
        public void UpdateObject(string id, TDocument document)
        ***REMOVED***
            foreach (var (Id, stations) in this._collection)
            ***REMOVED***
                lock (stations)
                ***REMOVED***
                    for (int i = 0; i < stations.Count; i++)
                    ***REMOVED***
                        if (stations[i].Id == new MongoDB.Bson.ObjectId(id))
                        ***REMOVED***
                            this._collection[Id][i] = document;
                       ***REMOVED***
                   ***REMOVED***
               ***REMOVED***
           ***REMOVED***
       ***REMOVED***

        // Updates the record from the model by bson _id Async.
        public async Task UpdateObjectAsync(string id, TDocument document)
        ***REMOVED***
            await Task.Run(() => UpdateObject(id, document));
       ***REMOVED***

        // Removes the record from the db.
        public void RemoveObject(TDocument document)
        ***REMOVED***
            if (this._collection.TryGetValue(document.Id.ToString(), out List<TDocument> stations))
            ***REMOVED***
                stations.Remove(document);
           ***REMOVED***
       ***REMOVED***

        // Removes the record from the db Async.
        public async Task RemoveObjectAsync(TDocument document)
        ***REMOVED***
            await Task.Run(() => RemoveObject(document));
       ***REMOVED***

        // Removes the record from the db based on the bason _id.
        public void RemoveObjectById(string id)
        ***REMOVED***
             foreach (var (Id, stations) in this._collection)
            ***REMOVED***
                foreach (var station in stations)
                ***REMOVED***
                    if (station.Id == new ObjectId(id))
                    ***REMOVED***
                        this._collection[Id].Remove(station);
                   ***REMOVED***
               ***REMOVED***
           ***REMOVED***
       ***REMOVED***

        // Removes the record from the db based on the bason _id Async.
        public async Task RemoveObjectByIdAsync(string id)
        ***REMOVED***
            await Task.Run(() => RemoveObjectById(id));
       ***REMOVED***

        // Filters the record by lambda.
        public IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression)
        ***REMOVED***
            throw new Exception();
       ***REMOVED***
        
        // Filters the project expression.
        public IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression)
        ***REMOVED***
            throw new Exception();
       ***REMOVED***

        // Filters the first record.
        public TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
        ***REMOVED***
            throw new Exception();
       ***REMOVED***

        // Filters the collection Async.
        public Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        ***REMOVED***
            throw new Exception();
       ***REMOVED***

   ***REMOVED***
***REMOVED***