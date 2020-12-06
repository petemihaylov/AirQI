using AirQi.Dtos;
using AutoMapper;
using AirQi.Models;
using AirQi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AirQi.Controllers
{
    [Produces("application/json")]
    [Route("api/measurements/")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMongoDataRepository<Station> _repository;
        private readonly IMapper _mapper;
        public MeasurementsController(IMongoDataRepository<Station> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<StationReadDto>> GetAllMeasurements()
        {
            var stationModelItems =  _repository.GetAll();
            
            if(stationModelItems != null){
                return Ok(_mapper.Map<IEnumerable<MeasurementReadDto>>(stationModelItems));
            }

            return NotFound();
        }
    }
}