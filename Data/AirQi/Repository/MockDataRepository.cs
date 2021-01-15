
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
{
    public class MockDataRepository<TDocument> : IMongoDataRepository<TDocument> where TDocument : IDocument
    {
        private static readonly Random _random = new Random(Seed: 0);
        private readonly ConcurrentDictionary<string, List<TDocument>> _collection;
        private readonly IMapper _mapper;

        public MockDataRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static Station MockStation()
        {
            var coordinates = new Coordinates
            {
                Latitude = (_random.NextDouble() * (53.2193835 - 51.1913202)) + 51.1913202,
                Longitude = (_random.NextDouble() * (6.8936619 - 4.4777325)) + 4.4777325
            };

            var station = new Station
            {

                Id = new ObjectId(NewSeeder().ToString().Substring(0, 8)),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Coordinates = coordinates,
                Aqi = _random.NextDouble(),
                // https://github.com/vivet/GoogleApi
                Location = "Netherlands",
                City = "",
                Country = "Netherlands",
                Measurements = Enumerable.Range(0, _random.Next(4, 5)).Select(m => MockMeasurement(coordinates)).ToList()
            };

            return station;
        }

        private static Measurement MockMeasurement(Coordinates coordinates)
        {
            var measuerment = new Measurement
            {
                Id = new ObjectId(NewSeeder().ToString().Substring(0, 8)),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Coordinates = coordinates,
                Parameter = "aqi",
                Value = _random.Next(50, 150),
                LastUpdated = DateTime.UtcNow.ToString(),
                Unit = "µg/m³",
                SourceName = "MockData"
            };

            return measuerment;
        }

        private static Guid NewSeeder()
        {
            var bytes = new byte[16];
            _random.NextBytes(buffer: bytes);

            return new Guid(bytes);
        }

        // Returns all objects from the db.
        public IEnumerable<TDocument> GetAll()
        {
             var stations = this._collection.Values.SelectMany(x => x);
            stations = stations.OrderByDescending(x => x.UpdatedAt).ThenByDescending(x => x.CreatedAt);

            return stations.ToList();
        }

        // Returns all objects from the db Async.
        public async Task<IEnumerable<TDocument>> GetAllAsync()
        {
            return await Task.FromResult(GetAll());
        }

        // Returns all latest objects from db based on date.
        public IEnumerable<TDocument> GetAllLatest()
        {
            return GetAll();
        }

        // Returns all latest objects from db based on date Async.
        public async Task<IEnumerable<TDocument>> GetAllLatestAsync()
        {
            return await Task.FromResult(GetAllLatest());
        }

        // Returns an object by the bson _id of the record.
        public TDocument GetObjectById(string id)
        {
            foreach (var (Id, stations) in this._collection)
            {
                foreach (var station in stations)
                {
                    if (station.Id == new MongoDB.Bson.ObjectId(id))
                    {
                        return station;
                    }
                }
            }

            return default(TDocument);
        }

        // Returns an object by the bson _id of the record Async.
        public async Task<TDocument> GetObjectByIdAsync(string id)
        {
            return await Task.FromResult(GetObjectById(id));
        }

        // Creates a record from the model.
        public void CreateObject(TDocument document)
        {
            this._collection.AddOrUpdate(document.Id.ToString(), new List<TDocument> { document }, (id, stations) =>
            {
                lock (stations)
                {
                    stations.Add(item: document);
                }

                return stations;
            });
        }

        // Creates a record from the model Async.
        public async Task CreateObjectAsync(TDocument document)
        {
            await Task.Run(() => CreateObject(document));
        }

        // Updates the record from the model by bson _id.
        public void UpdateObject(string id, TDocument document)
        {
            foreach (var (Id, stations) in this._collection)
            {
                lock (stations)
                {
                    for (int i = 0; i < stations.Count; i++)
                    {
                        if (stations[i].Id == new MongoDB.Bson.ObjectId(id))
                        {
                            this._collection[Id][i] = document;
                        }
                    }
                }
            }
        }

        // Updates the record from the model by bson _id Async.
        public async Task UpdateObjectAsync(string id, TDocument document)
        {
            await Task.Run(() => UpdateObject(id, document));
        }

        // Removes the record from the db.
        public void RemoveObject(TDocument document)
        {
            if (this._collection.TryGetValue(document.Id.ToString(), out List<TDocument> stations))
            {
                stations.Remove(document);
            }
        }

        // Removes the record from the db Async.
        public async Task RemoveObjectAsync(TDocument document)
        {
            await Task.Run(() => RemoveObject(document));
        }

        // Removes the record from the db based on the bason _id.
        public void RemoveObjectById(string id)
        {
             foreach (var (Id, stations) in this._collection)
            {
                foreach (var station in stations)
                {
                    if (station.Id == new ObjectId(id))
                    {
                        this._collection[Id].Remove(station);
                    }
                }
            }
        }

        // Removes the record from the db based on the bason _id Async.
        public async Task RemoveObjectByIdAsync(string id)
        {
            await Task.Run(() => RemoveObjectById(id));
        }

        // Filters the record by lambda.
        public IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression)
        {
            throw new Exception();
        }
        
        // Filters the project expression.
        public IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression)
        {
            throw new Exception();
        }

        // Filters the first record.
        public TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            throw new Exception();
        }

        // Filters the collection Async.
        public Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            throw new Exception();
        }

    }
}