
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Linq.Expressions;

using AutoMapper;
using AirQi.Models.Core;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Test.Repository
***REMOVED***
    public class MockDataRepository : IMockDataRepository<Station>
    ***REMOVED***
        private static readonly Random _random = new Random(Seed: 0);
        private  readonly ConcurrentDictionary<double[], List<Station>> _collections;
        private readonly IMapper _mapper;

        public MockDataRepository(IMapper mapper)
        ***REMOVED***
            this._mapper = mapper;
            this._collections = new ConcurrentDictionary<double[], List<Station>>(concurrencyLevel: 2, capacity: 128);
       ***REMOVED***

        public async void GenerateMockStations()
        ***REMOVED***
            double[,] positions = new double[4,2] ***REMOVED*** ***REMOVED*** 51.31, 4.97***REMOVED***, ***REMOVED*** 50.82, 51.52***REMOVED***, ***REMOVED*** 45.22, 31.53***REMOVED***, ***REMOVED*** 21.31, 4.37***REMOVED******REMOVED***;
            var stationStateCount = _random.Next(2, 10);

            for (int j = 0; j < 4; j++)
            ***REMOVED***
                double[] position = new double[] ***REMOVED*** positions[j, 0], positions[j, 1]***REMOVED***;

                for (int i = 0; i < stationStateCount; i++)
                ***REMOVED***
                    var station = MockStation(position);
                    await this.CreateObjectAsync(station);
               ***REMOVED***
           ***REMOVED***
       ***REMOVED***

        private static Station MockStation(double[] position)
        ***REMOVED***

            var latitude = (_random.NextDouble() * (53.2193835 - 51.1913202)) + 51.1913202;
            var longitude = (_random.NextDouble() * (6.8936619 - 4.4777325)) + 4.4777325;


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

        // Returns all objects from the collection.
        public IEnumerable<Station> GetAll()
        ***REMOVED***
            var stations = this._collections.Values.SelectMany(x => x);

            return stations.ToList();
       ***REMOVED***

        // Returns all objects from the collection Async.
        public async Task<IEnumerable<Station>> GetAllAsync()
        ***REMOVED***
            return await Task.FromResult(GetAll());
       ***REMOVED***

        // Returns all latest objects from the collection.
        public IEnumerable<Station> GetAllLatest()
        ***REMOVED***
            IEnumerable<Station> stations = GetAll();
            stations = stations.OrderByDescending(doc => doc.UpdatedAt).GroupBy(doc => new ***REMOVED*** doc.Position***REMOVED***, (key, group) => group.First());
            return stations;
       ***REMOVED***

        // Returns all latest objects from collection based on date Async.
        public async Task<IEnumerable<Station>> GetAllLatestAsync()
        ***REMOVED***
            IEnumerable<Station> stations = await GetAllAsync();
            stations = stations.OrderByDescending(doc => doc.UpdatedAt).GroupBy(doc => new ***REMOVED*** doc.Position***REMOVED***, (key, group) => group.First());
            return stations;
       ***REMOVED***

        // Returns an object by the position of the record.
        public Station GetObjectByPosition(double[] position)
        ***REMOVED***
            foreach (var (Position, stations) in this._collections)
            ***REMOVED***
                foreach (var station in stations)
                ***REMOVED***
                    if (station.Position == position)
                    ***REMOVED***
                        return station;
                   ***REMOVED***
               ***REMOVED***
           ***REMOVED***

            return default(Station);
       ***REMOVED***

        // Returns an object by the position of the record Async.
        public async Task<Station> GetObjectByPositionAsync(double[] position)
        ***REMOVED***
            return await Task.FromResult(GetObjectByPosition(position));
       ***REMOVED***

        // Creates a record from the model.
        public void CreateObject(Station station)
        ***REMOVED***
            this._collections.AddOrUpdate(station.Position, new List<Station> ***REMOVED*** station***REMOVED***, (position, stations) =>
            ***REMOVED***
                lock (stations)
                ***REMOVED***
                    stations.Add(item: station);
               ***REMOVED***

                return stations;
           ***REMOVED***);
       ***REMOVED***

        // Creates a record from the model Async.
        public async Task CreateObjectAsync(Station station)
        ***REMOVED***
            await Task.Run(() => CreateObject(station));
       ***REMOVED***

        // Updates the record from the model by position.
        public void UpdateObject(double[] position, Station station)
        ***REMOVED***
            foreach (var (Position, stations) in this._collections)
            ***REMOVED***
                lock (stations)
                ***REMOVED***
                    for (int i = 0; i < stations.Count; i++)
                    ***REMOVED***
                        if (stations[i].Position == position)
                        ***REMOVED***
                            this._collections[Position][i] = station;
                       ***REMOVED***
                   ***REMOVED***
               ***REMOVED***
           ***REMOVED***
       ***REMOVED***

        // Updates the record from the model by position Async.
        public async Task UpdateObjectAsync(double[] position, Station station)
        ***REMOVED***
            await Task.Run(() => UpdateObject(position, station));
       ***REMOVED***

        // Removes the record from the collection.
        public void RemoveObject(Station station)
        ***REMOVED***
            if (this._collections.TryGetValue(station.Position, out List<Station> stations))
            ***REMOVED***
                stations.Remove(station);
           ***REMOVED***
       ***REMOVED***

        // Removes the record from the collection Async.
        public async Task RemoveObjectAsync(Station station)
        ***REMOVED***
            await Task.Run(() => RemoveObject(station));
       ***REMOVED***

        // Removes the record from the collection based on the position.
        public void RemoveObjectByPosition(double[] position)
        ***REMOVED***
             foreach (var (Position, stations) in this._collections)
            ***REMOVED***
                foreach (var station in stations)
                ***REMOVED***
                    if (station.Position == position)
                    ***REMOVED***
                        this._collections[Position].Remove(station);
                   ***REMOVED***
               ***REMOVED***
           ***REMOVED***
       ***REMOVED***

        // Removes the record from the db based on the position Async.
        public async Task RemoveObjectByPositionAsync(double[] position)
        ***REMOVED***
            await Task.Run(() => RemoveObjectByPosition(position));
       ***REMOVED***

   ***REMOVED***
***REMOVED***