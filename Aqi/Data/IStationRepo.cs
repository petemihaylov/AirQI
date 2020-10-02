using System.Collections.Generic;
using Aqi.Models;

namespace Aqi.Data
***REMOVED***
    public interface IStationRepo
    ***REMOVED***
        bool SaveChanges();

        IEnumerable<Station> GetAllStaions();
        Station GetStationById(int id);
        void CreateStation(Station station);

        void CreateOrUpdateStation(Station station);

        void DeleteStation(Station station);
   ***REMOVED***
***REMOVED***