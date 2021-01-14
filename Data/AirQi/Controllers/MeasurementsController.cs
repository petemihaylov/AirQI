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
***REMOVED***
    [Produces("application/json")]
    [Route("api/measurements/")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    ***REMOVED***
        private readonly IMongoDataRepository<Station> _repository;
        private readonly IMapper _mapper;
        public MeasurementsController(IMongoDataRepository<Station> repository, IMapper mapper)
        ***REMOVED***
            this._repository = repository;
            this._mapper = mapper;
       ***REMOVED***

        [HttpGet]
        public ActionResult <IEnumerable<StationReadDto>> GetAllMeasurements()
        ***REMOVED***
            var stationModelItems =  this._repository.GetAll();
            
            if(stationModelItems != null)***REMOVED***
                return Ok(_mapper.Map<IEnumerable<MeasurementReadDto>>(stationModelItems));
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpGet("***REMOVED***id***REMOVED***", Name="GetMeasurementsByStationId")]
        public async Task<IActionResult> GetMeasurementsByStationId(string id)
        ***REMOVED***
            var station = await this._repository.GetObjectByIdAsync(id);

            if(station != null)
            ***REMOVED***
                return Ok(_mapper.Map<MeasurementReadDto>(station));    
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpPost("id")]
        public async Task<IActionResult> CreateMeasurementByStationId(string id, MeasurementCreateDto measurementCreateDto)
        ***REMOVED***
            var station = await this._repository.GetObjectByIdAsync(id);
            var measurementModel = this._mapper.Map<Measurement>(measurementCreateDto);
            var stationModel = this._mapper.Map<Station>(station);

            if(station != null)
            ***REMOVED***
                stationModel.UpdatedAt = DateTime.UtcNow;
                stationModel.Id = new ObjectId(id);
                stationModel.Measurements.ToList().Add(measurementModel);

                this._repository.UpdateObject(id, stationModel);
                return Ok(_mapper.Map<StationReadDto>(stationModel));    
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpPut("***REMOVED***id***REMOVED***")]
        public async Task<IActionResult> UpdateMeasurementBySourceName(string id, MeasurementCreateDto measurementCreateDto)
        ***REMOVED***
            var station = await this._repository.GetObjectByIdAsync(id);
            var measurementModel = this._mapper.Map<Measurement>(measurementCreateDto);
            var stationModel = this._mapper.Map<Station>(station);

            if(station != null)
            ***REMOVED***
                stationModel.UpdatedAt = DateTime.UtcNow;
                stationModel.Id = new ObjectId(id);
                var measurements = stationModel.Measurements.ToList();
                var mObj = measurements.FirstOrDefault(m => m.SourceName == measurementModel.SourceName);

                if (mObj != null)
                ***REMOVED***
                    measurements.Remove(mObj);
                    measurements.Add(measurementModel);
                    this._repository.UpdateObject(id, stationModel);
                    return Ok(_mapper.Map<StationReadDto>(stationModel));    
               ***REMOVED***
                    
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpDelete("***REMOVED***id***REMOVED***")]
        public  async Task<ActionResult> DeleteMeasurement(string id, MeasurementCreateDto measurementCreateDto)
        ***REMOVED***
            var station = await this._repository.GetObjectByIdAsync(id);
            var measurementModel = this._mapper.Map<Measurement>(measurementCreateDto);
            var stationModel = this._mapper.Map<Station>(station);
            var measurements = stationModel.Measurements.ToList();
            var mObj = measurements.FirstOrDefault(m => m.SourceName == measurementModel.SourceName);

            if (mObj != null)
            ***REMOVED***
                    measurements.Remove(mObj);
 
                return Ok("Successfully deleted from collection!"); 
           ***REMOVED*** 

            return NotFound();
       ***REMOVED***
   ***REMOVED***
***REMOVED***