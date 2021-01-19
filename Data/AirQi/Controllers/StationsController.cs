using AirQi.Dtos;
using AutoMapper;
using AirQi.Models.Core;
using AirQi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MongoDB.Bson;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using AssetNXT.Hubs;

namespace AirQi.Controllers
***REMOVED***

    [Produces("application/json")]
    [Route("api/stations/")]
    [ApiController]
    public class StationsController : ControllerBase
    ***REMOVED***
        private readonly IMongoDataRepository<Station> _repository;
        private readonly IHubContext<LiveStationHub> _hub;
        private readonly IMapper _mapper;
        public StationsController(IMongoDataRepository<Station> repository, IHubContext<LiveStationHub> hub, IMapper mapper)
        ***REMOVED***
            this._repository = repository;
            this._hub = hub;
            this._mapper = mapper;
       ***REMOVED***

       [HttpGet]
        public async Task<IActionResult> GetAllStations()
        ***REMOVED***
            var stations = await this._repository.GetAllAsync();
            stations = stations.OrderByDescending(doc => doc.UpdatedAt).GroupBy(doc => new ***REMOVED*** doc.Position***REMOVED***, (key, group) => group.First());

            if(stations != null)***REMOVED***
                return Ok(_mapper.Map<IEnumerable<StationReadDto>>(stations));
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpGet("***REMOVED***id***REMOVED***", Name="GetStationById")]
        public async Task<IActionResult> GetStationById(string id)
        ***REMOVED***
            var station = await this._repository.GetObjectByIdAsync(id);

            if(station != null)
            ***REMOVED***
                return Ok(_mapper.Map<StationReadDto>(station));    
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpPost]
        public async Task<IActionResult> CreateStation(StationCreateDto stationCreateDto)
        ***REMOVED***
            var station = this._mapper.Map<Station>(stationCreateDto);

            if (station != null)
            ***REMOVED***
                station.CreatedAt = station.UpdatedAt = DateTime.UtcNow;
                await this._repository.CreateObjectAsync(station);

                // SignalR event
                await this._hub.Clients.All.SendAsync("GetNewStationsAsync", station);

                var stationReadDto = this._mapper.Map<StationReadDto>(station);

                // https://docs.microsoft.com/en-us/dotnet/api/system.web.http.apicontroller.createdatroute?view=aspnetcore-2.2
                return CreatedAtRoute(nameof(GetStationById), new ***REMOVED*** Id = stationReadDto.Id***REMOVED***, stationReadDto);
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpPut("***REMOVED***id***REMOVED***")]
        public async Task<IActionResult> UpdateStation(string id, StationCreateDto stationCreateDto)
        ***REMOVED***
            var stationModel =this._mapper.Map<Station>(stationCreateDto);
            var station = await this._repository.GetObjectByIdAsync(id);

            if(station != null)
            ***REMOVED***
                stationModel.UpdatedAt = DateTime.UtcNow;
                stationModel.Id = new ObjectId(id);
               this._repository.UpdateObject(id, stationModel);
                return Ok(_mapper.Map<StationReadDto>(stationModel));    
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpDelete("***REMOVED***id***REMOVED***")]
        public  async Task<ActionResult> DeleteStation(string id)
        ***REMOVED***
            var station= await this._repository.GetObjectByIdAsync(id);

            if(station != null)
            ***REMOVED***                
                await this._repository.RemoveObjectAsync(station);
                return Ok("Successfully deleted from collection!"); 
           ***REMOVED*** 

            return NotFound();
       ***REMOVED***      
   ***REMOVED***
***REMOVED***