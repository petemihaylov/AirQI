using AirQi.Dtos;
using AutoMapper;
using AirQi.Models.Core;
using AirQi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MongoDB.Bson;

namespace AirQi.Controllers
{

    [Produces("application/json")]
    [Route("api/stations/")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        private readonly IMongoDataRepository<Station> _repository;
        private readonly IMapper _mapper;
        public StationsController(IMongoDataRepository<Station> repository, IMapper mapper)
        {
           this._repository = repository;
           this._mapper = mapper;
        }

       [HttpGet]
        public async Task<IActionResult> GetAllStations()
        {
            var stations =  await this._repository.GetAllLatestAsync();

            if(stations != null){
                return Ok(_mapper.Map<IEnumerable<StationReadDto>>(stations));
            }

            return NotFound();
        }

        [HttpGet("{id}", Name="GetStationById")]
        public async Task<IActionResult> GetStationById(string id)
        {
            var station = await this._repository.GetObjectByIdAsync(id);

            if(station != null)
            {
                return Ok(_mapper.Map<StationReadDto>(station));    
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStation(StationCreateDto stationCreateDto)
        {
            var station =this._mapper.Map<Station>(stationCreateDto);

            if (station != null)
            {
                station.CreatedAt = station.UpdatedAt = DateTime.UtcNow;
                await this._repository.CreateObjectAsync(station);

                var stationReadDto =this._mapper.Map<StationReadDto>(station);

                // https://docs.microsoft.com/en-us/dotnet/api/system.web.http.apicontroller.createdatroute?view=aspnetcore-2.2
                return CreatedAtRoute(nameof(GetStationById), new { Id = stationReadDto.Id }, stationReadDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStation(string id, StationCreateDto stationCreateDto)
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
            var station= await this._repository.GetObjectByIdAsync(id);

            if(station != null)
            {                
                await this._repository.RemoveObjectAsync(station);
                return Ok("Successfully deleted from collection!"); 
            } 

            return NotFound();
        }      
    }
}