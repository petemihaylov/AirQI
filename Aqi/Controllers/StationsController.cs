using Aqi.Dtos;
using AutoMapper;
using System.Collections.Generic;
using Aqi.Models.Models;
using Aqi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

namespace Aqi.Controllers
***REMOVED***
    // api/stations
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

        [HttpPost]
        public async Task CreateStation(StationCreateDto stationCreateDto)
        ***REMOVED***
            var stationModel = _mapper.Map<Station>(stationCreateDto);
            await _repository.InsertOneAsync(stationModel);
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
   ***REMOVED***
***REMOVED***