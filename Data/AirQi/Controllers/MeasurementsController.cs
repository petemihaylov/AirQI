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
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<MeasurementReadDto>> GetAllMeasurements()
        {
            var stationModelItems =  this._repository.GetAll();
            
            if(stationModelItems != null){
                return Ok(_mapper.Map<IEnumerable<StationMeasurementReadDto>>(stationModelItems));
            }

            return NotFound();
        }

        [HttpGet("{id}", Name="GetMeasurementsByStationId")]
        public async Task<IActionResult> GetMeasurementsByStationId(string id)
        {
            var station = await this._repository.GetObjectByIdAsync(id);

            if(station != null)
            {
                return Ok(_mapper.Map<StationMeasurementReadDto>(station));    
            }

            return NotFound();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStation(string id, StationMeasurementCreateDto stationCreateDto)
        {
            var stationModel =this._mapper.Map<Station>(stationCreateDto);
            var station = await this._repository.GetObjectByIdAsync(id);

            if(station != null)
            {
                stationModel.UpdatedAt = DateTime.UtcNow;
                stationModel.Id = new ObjectId(id);
                this._repository.UpdateObject(id, stationModel);
                return Ok(_mapper.Map<StationReadDto>(stationModel));    
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public  async Task<ActionResult> DeleteStation(string id)
        {
            var station = await this._repository.GetObjectByIdAsync(id);

            if(station != null)
            {                
                await this._repository.RemoveObjectAsync(station);
                return Ok("Successfully deleted from collection!"); 
            } 

            return NotFound();
        }      
    }
}