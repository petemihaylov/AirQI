using AutoMapper;
using Aqi.Dtos;
using Aqi.Models.Data;

namespace Aqi.Profiles
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