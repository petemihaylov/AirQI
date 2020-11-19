using AirQi.Dtos;
using AutoMapper;
using AirQi.Models.Data;
using AirQi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AirQi.Controllers
***REMOVED***
    [ApiController]
    [Route("[controller]")]
    public class MeasurementsController : ControllerBase
    ***REMOVED***
        private readonly IMongoDataRepository<Station> _repository;
        private readonly IMapper _mapper;
        public MeasurementsController(IMongoDataRepository<Station> repository, IMapper mapper)
        ***REMOVED***
            _repository = repository;
            _mapper = mapper;
       ***REMOVED***

        [HttpGet]
        public ActionResult <IEnumerable<StationReadDto>> GetAllMeasurements()
        ***REMOVED***
            var stationModelItems =  _repository.GetAll();
            
            if(stationModelItems != null)***REMOVED***
                return Ok(_mapper.Map<IEnumerable<MeasurementReadDto>>(stationModelItems));
           ***REMOVED***

            return NotFound();
       ***REMOVED***
   ***REMOVED***
***REMOVED***