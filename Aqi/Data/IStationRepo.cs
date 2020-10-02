using System.Collections.Generic;
using Aqi.Models;

namespace Aqi.Data
{
    public interface IStationRepo
    {
        bool SaveChanges();

        IEnumerable<Station> GetAllStaions();
        Station GetStationById(int id);
        void CreateStation(Station station);

        void CreateOrUpdateStation(Station station);

        void DeleteStation(Station station);
    }
}