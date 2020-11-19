using Aqi.Dtos;
using AutoMapper;
using Aqi.Models.Data;
using Aqi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Aqi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMongoRepo<Station> _repository;
        private readonly IMapper _mapper;
        public MeasurementsController(IMongoRepo<Station> repository, IMapper mapper)
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