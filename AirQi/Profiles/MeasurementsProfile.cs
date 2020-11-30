using AutoMapper;
using AirQi.Dtos;
using AirQi.Models;

namespace AirQi.Profiles
{
    public class MeasurementsProfile : Profile
    {
        public MeasurementsProfile()
        {
            CreateMap<Station, MeasurementReadDto>();
            CreateMap<MeasurementReadDto, StationReadDto>().ForMember(dest => dest.Measurements, opt => opt.MapFrom(src => src));
            // https://stackoverflow.com/questions/10660623/automapper-map-from-source-nested-collection-to-another-collection

            CreateMap<MeasurementCreateDto, Station>();
            CreateMap<Station, MeasurementCreateDto>();

        }
    }
}