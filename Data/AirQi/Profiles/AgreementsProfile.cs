using AirQi.Dtos.Core;
using AirQi.Models.Data;

using AutoMapper;

namespace AirQi.Profiles
{
    public class AgreementsProfile : Profile
    {
        public AgreementsProfile()
        {
            CreateMap<Agreement, AgreementReadDto>();
            CreateMap<AgreementCreateDto, Agreement>();
            CreateMap<Agreement, AgreementCreateDto>();
        }
    }
}