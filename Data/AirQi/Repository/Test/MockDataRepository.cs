
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Concurrent;

using AirQi.Models.Core;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AirQi.Repository.Test
{
    public class MockDataRepository : IMockDataRepository<Station>
    {
        private static readonly Random _random = new Random(Seed: 0);
        private  readonly ConcurrentDictionary<double[], List<Station>> _collections;

        public MockDataRepository()
        {
            this._collections = new ConcurrentDictionary<double[], List<Station>>(concurrencyLevel: 2, capacity: 128);
        }

        public async void GenerateMockStations()
        {
            double[,] positions = new double[4,2] { { 51.31, 4.97 }, { 50.82, 51.52 }, { 45.22, 31.53 }, { 21.31, 4.37 } };
            var stationStateCount = _random.Next(2, 10);

            for (int j = 0; j < 4; j++)
            {
                double[] position = new double[] { positions[j, 0], positions[j, 1] };

                for (int i = 0; i < stationStateCount; i++)
                {
                    var station = MockStation(position);
                    await this.CreateObjectAsync(station);
                }
            }
        }

        private static Station MockStation(double[] position)
        {

            var latitude = (_random.NextDouble() * (53.2193835 - 51.1913202)) + 51.1913202;
            var longitude = (_random.NextDouble() * (6.8936619 - 4.4777325)) + 4.4777325;


            var station = new Station
            {

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
            };

            return station;
        }

        private static Measurement MockMeasurement()
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
            foreach (var (Position, stations) in this._collections)
            {
                foreach (var station in stations)
                {
                    if (station.Position == position)
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