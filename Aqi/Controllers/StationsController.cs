using Aqi.Dtos;
using AutoMapper;
using System.Collections.Generic;
using Aqi.Models.Data;
using Aqi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace Aqi.Controllers
***REMOVED***

    [ApiController]
    [Route("[controller]")]
    public class StationsController : ControllerBase
    ***REMOVED***
        private readonly IMongoRepo<Station> _repository;
        private readonly IMapper _mapper;
        public StationsController(IMongoRepo<Station> repository, IMapper mapper)
        ***REMOVED***
            _repository = repository;
            _mapper = mapper;
       ***REMOVED***

       [HttpGet]
        public ActionResult <IEnumerable<StationReadDto>> GetAllStations()
        ***REMOVED***
            var stationModelItems =  _repository.GetAll();
            
            if(stationModelItems != null)***REMOVED***
                return Ok(_mapper.Map<IEnumerable<StationReadDto>>(stationModelItems));
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpGet("***REMOVED***id***REMOVED***", Name="GetStationById")]
        public ActionResult <StationReadDto> GetStationById(string id)
        ***REMOVED***
            var stationModel = _repository.GetObjectById(id);

            if(stationModel != null)
            ***REMOVED***
                return Ok(_mapper.Map<StationReadDto>(stationModel));    
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpPost]
        public ActionResult <StationCreateDto> CreateStation(StationCreateDto stationCreateDto)
        ***REMOVED***
            var stationModel = _mapper.Map<Station>(stationCreateDto);

            stationModel.CreatedAt = stationModel.UpdatedAt = DateTime.UtcNow;
            _repository.CreateObject(stationModel);

            var stationReadDto = _mapper.Map<StationReadDto>(stationModel);
            
            // https://docs.microsoft.com/en-us/dotnet/api/system.web.http.apicontroller.createdatroute?view=aspnetcore-2.2
            return CreatedAtRoute(nameof(GetStationById), new ***REMOVED***Id = stationReadDto.Id***REMOVED***, stationReadDto);
       ***REMOVED***

        [HttpPut("***REMOVED***id***REMOVED***")]
        public ActionResult <StationCreateDto> EditStation(string id, StationCreateDto stationCreateDto)
        ***REMOVED***
            var stationModel = _mapper.Map<Station>(stationCreateDto);
            var station = _repository.GetObjectById(id);


            if(station != null)
            ***REMOVED***
                stationModel.UpdatedAt = DateTime.UtcNow;
                stationModel.Id = new MongoDB.Bson.ObjectId(id);
                _repository.UpdateObject(id, stationModel);
                return Ok(_mapper.Map<StationReadDto>(stationModel));    
           ***REMOVED***

            return NotFound();

       ***REMOVED***

        [HttpDelete("***REMOVED***id***REMOVED***")]
        public ActionResult DeleteStation(string id)
        ***REMOVED***
            var stationModel = _repository.GetObjectById(id);

            if(stationModel != null)
            ***REMOVED***
                
                _repository.RemoveObject(stationModel);

                return Ok("Successfully deleted from collection!");
 
           ***REMOVED*** 

            return NotFound();
       ***REMOVED***
        

   ***REMOVED***
***REMOVED***