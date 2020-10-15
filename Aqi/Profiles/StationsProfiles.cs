using AutoMapper;
using Aqi.Dtos;
using Aqi.Models.Data;

namespace Aqi.Profiles
{
    public class StationsProfile : Profile
    {
        public StationsProfile()
        {
            CreateMap<Station, StationReadDto>();
            CreateMap<StationCreateDto, Station>();
            CreateMap<Station,StationCreateDto>();
        }
    }
}