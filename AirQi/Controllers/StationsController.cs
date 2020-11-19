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

    [Produces("application/json")]
    [Route("api/stations/")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        private readonly IMongoDataRepository<Station> _repository;
        private readonly IMapper _mapper;
        public StationsController(IMongoDataRepository<Station> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

       [HttpGet]
        public ActionResult <IEnumerable<StationReadDto>> GetAllStations()
        {
            var stationModelItems =  _repository.GetAll();
            
            if(stationModelItems != null){
                return Ok(_mapper.Map<IEnumerable<StationReadDto>>(stationModelItems));
            }

            return NotFound();
        }

        [HttpGet("{id}", Name="GetStationById")]
        public ActionResult <StationReadDto> GetStationById(string id)
        {
            var stationModel = _repository.GetObjectById(id);

            if(stationModel != null)
            {
                return Ok(_mapper.Map<StationReadDto>(stationModel));    
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult <StationCreateDto> CreateStation(StationCreateDto stationCreateDto)
        {
            var stationModel = _mapper.Map<Station>(stationCreateDto);

            stationModel.CreatedAt = stationModel.UpdatedAt = DateTime.UtcNow;
            _repository.CreateObject(stationModel);

            var stationReadDto = _mapper.Map<StationReadDto>(stationModel);
            
            // https://docs.microsoft.com/en-us/dotnet/api/system.web.http.apicontroller.createdatroute?view=aspnetcore-2.2
            return CreatedAtRoute(nameof(GetStationById), new {Id = stationReadDto.Id}, stationReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult <StationCreateDto> EditStation(string id, StationCreateDto stationCreateDto)
        {
            var stationModel = _mapper.Map<Station>(stationCreateDto);
            var station = _repository.GetObjectById(id);


            if(station != null)
            {
                stationModel.UpdatedAt = DateTime.UtcNow;
                stationModel.Id = new MongoDB.Bson.ObjectId(id);
                _repository.UpdateObject(id, stationModel);
                return Ok(_mapper.Map<StationReadDto>(stationModel));    
            }

            return NotFound();

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStation(string id)
        {
            var stationModel = _repository.GetObjectById(id);

            if(stationModel != null)
            {
                
                _repository.RemoveObject(stationModel);

                return Ok("Successfully deleted from collection!");
 
            } 

            return NotFound();
        }
        

    }
}