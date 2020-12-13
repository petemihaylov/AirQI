using System.Collections.Generic;
using System.Threading.Tasks;
using AirQi.Models.Core;

namespace AirQi.Hubs
{
    public interface IStationClient<TDocument>
    {
        Task ReceiveStationAsync(List<TDocument> documents);
    }
}
