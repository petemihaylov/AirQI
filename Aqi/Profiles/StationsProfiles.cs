using AutoMapper;
using Aqi.Dtos;
using Aqi.Models.Models;

namespace Aqi.Profiles
***REMOVED***
    public class StationsProfile : Profile
    ***REMOVED***
        public StationsProfile()
        ***REMOVED***
            CreateMap<Station, StationReadDto>();
            CreateMap<StationReadDto, Station>();
            CreateMap<StationCreateDto, Station>();
            CreateMap<Station,StationCreateDto>();
       ***REMOVED***
   ***REMOVED***
***REMOVED***