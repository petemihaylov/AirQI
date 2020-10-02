using System.Collections.Generic;
using Aqi.Models;

namespace Aqi.Data
***REMOVED***
    public class SqlStationRepo : IStationRepo
    ***REMOVED***
        private readonly AqiDbContext _context;

        public SqlStationRepo(AqiDbContext context)
        ***REMOVED***
            _context = context;
       ***REMOVED***

        public void CreateOrUpdateStation(Station station)
        ***REMOVED***
            throw new System.NotImplementedException();
       ***REMOVED***

        public void CreateStation(Station station)
        ***REMOVED***
            throw new System.NotImplementedException();
       ***REMOVED***

        public void DeleteStation(Station station)
        ***REMOVED***
            throw new System.NotImplementedException();
       ***REMOVED***

        public IEnumerable<Station> GetAllStaions()
        ***REMOVED***
            throw new System.NotImplementedException();
       ***REMOVED***

        public Station GetStationById(int id)
        ***REMOVED***
            throw new System.NotImplementedException();
       ***REMOVED***

        public bool SaveChanges()
        ***REMOVED***
            return ( _context.SaveChanges() >= 0);
       ***REMOVED***
   ***REMOVED***
***REMOVED***