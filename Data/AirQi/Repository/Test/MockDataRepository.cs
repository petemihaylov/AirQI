
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Concurrent;

using AirQi.Models.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using AirQi.Models.Data;

namespace AirQi.Repository.Test
***REMOVED***
    public class MockDataRepository : IMockDataRepository<Station>
    ***REMOVED***
        private static readonly Random _random = new Random(Seed: 0);
        private ConcurrentDictionary<double[], List<Station>> _collections;
        private List<double[]> _positions;


        public MockDataRepository()
        ***REMOVED***
            this._collections = new ConcurrentDictionary<double[], List<Station>>(concurrencyLevel: 2, capacity: 128);
            this._positions = new List<double[]>();
       ***REMOVED***


        public ConcurrentDictionary<double[], List<Station>> Collections => _collections;
        public List<double[]> Positions => _positions; 
        
        
        public double GetRandomNumber(double minimum, double maximum)
        ***REMOVED*** 
            return _random.NextDouble() * (maximum - minimum) + minimum;
       ***REMOVED***

        public void GenerateMockStations()
        ***REMOVED***           
            for (int j = 0; j < _random.Next(2, 8); j++)
            ***REMOVED***
                double[] position = new double[] ***REMOVED*** GetRandomNumber(30.2, 50.3), GetRandomNumber(1.5, 30.6)***REMOVED***;
                
                this._positions.Add(position);
                var station = MockStation(position);
                this.CreateObject(station);
           ***REMOVED***
       ***REMOVED***

        public Station MockStation(double[] position)
        ***REMOVED***
                
            var station = new Station
            ***REMOVED***
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

        public Measurement MockMeasurement()
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

        public Notification MockNotification(double[] position)
        ***REMOVED***
                
            var notification = new Notification
            ***REMOVED***
                Position = position,
                Title = "title",
                Description = "description"
           ***REMOVED***;

            return notification;
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
            foreach (var (Position, stations) in this.Collections)
            ***REMOVED***
                foreach (var station in stations)
                ***REMOVED***
                    if (station.Position.SequenceEqual(position))
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