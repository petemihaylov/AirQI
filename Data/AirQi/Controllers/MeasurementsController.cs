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
        public ActionResult <IEnumerable<StationReadDto>> GetAllMeasurements()
        {
            var stationModelItems =  this._repository.GetAll();
            
            if(stationModelItems != null){
                return Ok(_mapper.Map<IEnumerable<MeasurementReadDto>>(stationModelItems));
            }

            return NotFound();
        }

        [HttpGet("{id}", Name="GetMeasurementsByStationId")]
        public async Task<IActionResult> GetMeasurementsByStationId(string id)
        {
            var station = await this._repository.GetObjectByIdAsync(id);

            if(station != null)
            {
                return Ok(_mapper.Map<MeasurementReadDto>(station));    
            }

            return NotFound();
        }

        [HttpPost("id")]
        public async Task<IActionResult> CreateMeasurementByStationId(string id, MeasurementCreateDto measurementCreateDto)
        {
            var station = await this._repository.GetObjectByIdAsync(id);
            var measurementModel = this._mapper.Map<Measurement>(measurementCreateDto);
            var stationModel = this._mapper.Map<Station>(station);

            if(station != null)
            {
                stationModel.UpdatedAt = DateTime.UtcNow;
                stationModel.Id = new ObjectId(id);
                stationModel.Measurements.ToList().Add(measurementModel);

                this._repository.UpdateObject(id, stationModel);
                return Ok(_mapper.Map<StationReadDto>(stationModel));    
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeasurementBySourceName(string id, MeasurementCreateDto measurementCreateDto)
        {
            var station = await this._repository.GetObjectByIdAsync(id);
            var measurementModel = this._mapper.Map<Measurement>(measurementCreateDto);
            var stationModel = this._mapper.Map<Station>(station);

            if(station != null)
            {
                stationModel.UpdatedAt = DateTime.UtcNow;
                stationModel.Id = new ObjectId(id);
                var measurements = stationModel.Measurements.ToList();
                var mObj = measurements.FirstOrDefault(m => m.SourceName == measurementModel.SourceName);

                if (mObj != null)
                {
                    measurements.Remove(mObj);
                    measurements.Add(measurementModel);
                    this._repository.UpdateObject(id, stationModel);
                    return Ok(_mapper.Map<StationReadDto>(stationModel));    
                }
                    
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public  async Task<ActionResult> DeleteMeasurement(string id, MeasurementCreateDto measurementCreateDto)
        {
            var station = await this._repository.GetObjectByIdAsync(id);
            var measurementModel = this._mapper.Map<Measurement>(measurementCreateDto);
            var stationModel = this._mapper.Map<Station>(station);
            var measurements = stationModel.Measurements.ToList();
            var mObj = measurements.FirstOrDefault(m => m.SourceName == measurementModel.SourceName);

            if (mObj != null)
            {
                    measurements.Remove(mObj);
 
                return Ok("Successfully deleted from collection!"); 
            } 

            return NotFound();
        }
    }
}