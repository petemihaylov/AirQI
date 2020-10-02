using System.Collections.Generic;
using Aqi.Models;

namespace Aqi.Data
{
    public class SqlStationRepo : IStationRepo
    {
        private readonly AqiDbContext _context;

        public SqlStationRepo(AqiDbContext context)
        {
            _context = context;
        }

        public void CreateOrUpdateStation(Station station)
        {
            throw new System.NotImplementedException();
        }

        public void CreateStation(Station station)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteStation(Station station)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Station> GetAllStaions()
        {
            throw new System.NotImplementedException();
        }

        public Station GetStationById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0);
        }
    }
}