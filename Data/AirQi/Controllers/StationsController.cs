using AirQi.Dtos;
using AutoMapper;
using AirQi.Models.Core;
using AirQi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MongoDB.Bson;
using AirQi.Services;
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
        private readonly IMapper _mapper;
        public StationsController(IMongoDataRepository<Station> repository, IMapper mapper)
        ***REMOVED***
            _repository = repository;
            _mapper = mapper;
       ***REMOVED***

       [HttpGet]
        public async Task<IActionResult> GetAllStations()
        ***REMOVED***
            var stations =  await _repository.GetAllLatestAsync();
            
            if(stations != null)***REMOVED***
                return Ok(_mapper.Map<IEnumerable<StationReadDto>>(stations));
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpGet("***REMOVED***id***REMOVED***", Name="GetStationById")]
        public async Task<IActionResult> GetStationById(string id)
        ***REMOVED***
            var station = await _repository.GetObjectByIdAsync(id);

            if(station != null)
            ***REMOVED***
                return Ok(_mapper.Map<StationReadDto>(station));    
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpPost]
        public async Task<IActionResult> CreateStation(StationCreateDto stationCreateDto)
        ***REMOVED***
            var station = _mapper.Map<Station>(stationCreateDto);

            if (station != null)
            ***REMOVED***
                station.CreatedAt = station.UpdatedAt = DateTime.UtcNow;
                await _repository.CreateObjectAsync(station);

                var stationReadDto = _mapper.Map<StationReadDto>(station);

                // https://docs.microsoft.com/en-us/dotnet/api/system.web.http.apicontroller.createdatroute?view=aspnetcore-2.2
                return CreatedAtRoute(nameof(GetStationById), new ***REMOVED*** Id = stationReadDto.Id***REMOVED***, stationReadDto);
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpPut("***REMOVED***id***REMOVED***")]
        public async Task<IActionResult> UpdateStation(string id, StationCreateDto stationCreateDto)
        ***REMOVED***
            var stationModel = _mapper.Map<Station>(stationCreateDto);
            var station = await _repository.GetObjectByIdAsync(id);

            if(station != null)
            ***REMOVED***
                stationModel.UpdatedAt = DateTime.UtcNow;
                stationModel.Id = new ObjectId(id);
                _repository.UpdateObject(id, stationModel);
                return Ok(_mapper.Map<StationReadDto>(stationModel));    
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpDelete("***REMOVED***id***REMOVED***")]
        public  async Task<ActionResult> DeleteStation(string id)
        ***REMOVED***
            var station= await _repository.GetObjectByIdAsync(id);

            if(station != null)
            ***REMOVED***                
                await _repository.RemoveObjectAsync(station);
                return Ok("Successfully deleted from collection!"); 
           ***REMOVED*** 

            return NotFound();
       ***REMOVED***
        

   ***REMOVED***
***REMOVED***