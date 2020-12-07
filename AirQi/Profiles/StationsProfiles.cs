using AutoMapper;
using AirQi.Dtos;
using AirQi.Models.Core;

namespace AirQi.Profiles
***REMOVED***
    public class StationsProfile : Profile
    ***REMOVED***
        public StationsProfile()
        ***REMOVED***
            CreateMap<Station, StationReadDto>();
            CreateMap<StationCreateDto, Station>();
            CreateMap<Station,StationCreateDto>();
       ***REMOVED***
   ***REMOVED***
***REMOVED***