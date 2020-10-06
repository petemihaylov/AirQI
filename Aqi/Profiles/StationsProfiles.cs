using AutoMapper;
using Aqi.Dtos;
using Aqi.Models.Models;

namespace Aqi.Profiles
{
    public class StationsProfile : Profile
    {
        public StationsProfile()
        {
            CreateMap<Station, StationReadDto>();
            CreateMap<StationReadDto, Station>();
            CreateMap<StationCreateDto, Station>();
            CreateMap<Station,StationCreateDto>();
        }
    }
}