using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Aqi.Models;
using AutoMapper;
using Aqi.Data;
using Aqi.Dtos;


namespace Aqi.Controllers
{
    // api/stations
    [Route("api/[controller]")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        private readonly IStationRepo _repository;
        private readonly IMapper _mapper;

        public StationsController(IStationRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}