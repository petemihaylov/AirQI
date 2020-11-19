using AutoMapper;
using AirQi.Dtos;
using AirQi.Models.Data;

namespace AirQi.Profiles
***REMOVED***
    public class MeasurementsProfile : Profile
    ***REMOVED***
        public MeasurementsProfile()
        ***REMOVED***
            CreateMap<Station, MeasurementReadDto>();
            CreateMap<MeasurementReadDto, StationReadDto>().ForMember(dest => dest.Measurements, opt => opt.MapFrom(src => src));
            // https://stackoverflow.com/questions/10660623/automapper-map-from-source-nested-collection-to-another-collection

            CreateMap<MeasurementCreateDto, Station>();
            CreateMap<Station, MeasurementCreateDto>();

       ***REMOVED***
   ***REMOVED***
***REMOVED***