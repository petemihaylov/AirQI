using AutoMapper;
using Aqi.Dtos;
using Aqi.Models.Data;

namespace Aqi.Profiles
{
    public class MeasurementsProfile : Profile
    {
        public MeasurementsProfile()
        {
            CreateMap<Station, MeasurementsReadDto>();
            CreateMap<MeasurementsReadDto, StationReadDto>().ForMember(dest => dest.Measurements, opt => opt.MapFrom(src => src));
            // https://stackoverflow.com/questions/10660623/automapper-map-from-source-nested-collection-to-another-collection

        }
    }
}