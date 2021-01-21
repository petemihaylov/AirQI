
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
{
    public class MockDataRepository : IMockDataRepository<Station>
    {
        private static readonly Random _random = new Random(Seed: 0);
        private ConcurrentDictionary<double[], List<Station>> _collections;
        private List<double[]> _positions;


        public MockDataRepository()
        {
            this._collections = new ConcurrentDictionary<double[], List<Station>>(concurrencyLevel: 2, capacity: 128);
            this._positions = new List<double[]>();
        }


        public ConcurrentDictionary<double[], List<Station>> Collections => _collections;
        public List<double[]> Positions => _positions; 
        
        
        public double GetRandomNumber(double minimum, double maximum)
        { 
            return _random.NextDouble() * (maximum - minimum) + minimum;
        }

        public void GenerateMockStations()
        {           
            for (int j = 0; j < _random.Next(2, 8); j++)
            {
                double[] position = new double[] { GetRandomNumber(30.2, 50.3), GetRandomNumber(1.5, 30.6)};
                
                this._positions.Add(position);
                var station = MockStation(position);
                this.CreateObject(station);
            }
        }

        public Station MockStation(double[] position)
        {
                
            var station = new Station
            {
                Position = position,
                Aqi = _random.NextDouble(),
                // https://github.com/vivet/GoogleApi
                Location = "Netherlands",
                City = "",
                Country = "Netherlands",
                Measurements = Enumerable.Range(0, _random.Next(4, 5)).Select(m => MockMeasurement()).ToList()
            };

            return station;
        }

        public Measurement MockMeasurement()
        {
            var measuerment = new Measurement
            {
                Parameter = "aqi",
                Value = _random.Next(50, 150),
                LastUpdated = DateTime.UtcNow.ToString(),
                Unit = "µg/m³",
                SourceName = "MockData"
            };

            return measuerment;
        }

        public Notification MockNotification(double[] position)
        {
                
            var notification = new Notification
            {
                Position = position,
                Title = "title",
                Description = "description"
            };

            return notification;
        }

        private static Guid NewSeeder()
        {
            var bytes = new byte[16];
            _random.NextBytes(buffer: bytes);

            return new Guid(bytes);
        }

        // Returns all objects from the collection.
        public IEnumerable<Station> GetAll()
        {
            var stations = this._collections.Values.SelectMany(x => x);

            return stations.ToList();
        }

        // Returns all objects from the collection Async.
        public async Task<IEnumerable<Station>> GetAllAsync()
        {
            return await Task.FromResult(GetAll());
        }

        // Returns all latest objects from the collection.
        public IEnumerable<Station> GetAllLatest()
        {
            IEnumerable<Station> stations = GetAll();
            stations = stations.OrderByDescending(doc => doc.UpdatedAt).GroupBy(doc => new { doc.Position }, (key, group) => group.First());
            return stations;
        }

        // Returns all latest objects from collection based on date Async.
        public async Task<IEnumerable<Station>> GetAllLatestAsync()
        {
            IEnumerable<Station> stations = await GetAllAsync();
            stations = stations.OrderByDescending(doc => doc.UpdatedAt).GroupBy(doc => new { doc.Position }, (key, group) => group.First());
            return stations;
        }

        // Returns an object by the position of the record.
        public Station GetObjectByPosition(double[] position)
        {
            foreach (var (Position, stations) in this.Collections)
            {
                foreach (var station in stations)
                {
                    if (station.Position.SequenceEqual(position))
                    {
                        return station;
                    }
                }
            }

            return default(Station);
        }

        // Returns an object by the position of the record Async.
        public async Task<Station> GetObjectByPositionAsync(double[] position)
        {
            return await Task.FromResult(GetObjectByPosition(position));
        }

        // Creates a record from the model.
        public void CreateObject(Station station)
        {
            this._collections.AddOrUpdate(station.Position, new List<Station> { station }, (position, stations) =>
            {
                lock (stations)
                {
                    stations.Add(item: station);
                }

                return stations;
            });
        }

        // Creates a record from the model Async.
        public async Task CreateObjectAsync(Station station)
        {
            await Task.Run(() => CreateObject(station));
        }

        // Updates the record from the model by position.
        public void UpdateObject(double[] position, Station station)
        {
            foreach (var (Position, stations) in this._collections)
            {
                lock (stations)
                {
                    for (int i = 0; i < stations.Count; i++)
                    {
                        if (stations[i].Position == position)
                        {
                            this._collections[Position][i] = station;
                        }
                    }
                }
            }
        }

        // Updates the record from the model by position Async.
        public async Task UpdateObjectAsync(double[] position, Station station)
        {
            await Task.Run(() => UpdateObject(position, station));
        }

        // Removes the record from the collection.
        public void RemoveObject(Station station)
        {
            if (this._collections.TryGetValue(station.Position, out List<Station> stations))
            {
                stations.Remove(station);
            }
        }

        // Removes the record from the collection Async.
        public async Task RemoveObjectAsync(Station station)
        {
            await Task.Run(() => RemoveObject(station));
        }

        // Removes the record from the collection based on the position.
        public void RemoveObjectByPosition(double[] position)
        {
             foreach (var (Position, stations) in this._collections)
            {
                foreach (var station in stations)
                {
                    if (station.Position == position)
                    {
                        this._collections[Position].Remove(station);
                    }
                }
            }
        }

        // Removes the record from the db based on the position Async.
        public async Task RemoveObjectByPositionAsync(double[] position)
        {
            await Task.Run(() => RemoveObjectByPosition(position));
        }

    }
}