using AutoMapper;
using AirQi.Dtos;
using AirQi.Models.Core;

namespace AirQi.Profiles
{
    public class StationsProfile : Profile
    {
        public StationsProfile()
        {
            CreateMap<Station, StationReadDto>();
            CreateMap<StationCreateDto, Station>();
            CreateMap<Station, StationCreateDto>();
        }
    }
}