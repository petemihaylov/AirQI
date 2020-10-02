using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Aqi.Models;
using AutoMapper;
using Aqi.Data;
using Aqi.Dtos;


namespace Aqi.Controllers
***REMOVED***
    // api/stations
    [Route("api/[controller]")]
    [ApiController]
    public class StationsController : ControllerBase
    ***REMOVED***
        private readonly IStationRepo _repository;
        private readonly IMapper _mapper;

        public StationsController(IStationRepo repository, IMapper mapper)
        ***REMOVED***
            _repository = repository;
            _mapper = mapper;
       ***REMOVED***
   ***REMOVED***
***REMOVED***