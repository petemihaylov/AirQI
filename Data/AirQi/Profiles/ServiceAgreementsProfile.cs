using AirQi.Dtos.Data;
using AirQi.Models.Data;

using AutoMapper;

namespace AirQi.Profiles
{
    public class ServiceAgreementsProfile : Profile
    {
        public ServiceAgreementsProfile()
        {
            CreateMap<ServiceAgreement, ServiceAgreementReadDto>();
        }
    }
}

