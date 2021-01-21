using AirQi.Dtos.Core;
using AirQi.Models.Data;

using AutoMapper;

namespace AirQi.Profiles
***REMOVED***
    public class AgreementsProfile : Profile
    ***REMOVED***
        public AgreementsProfile()
        ***REMOVED***
            CreateMap<Agreement, AgreementReadDto>();
            CreateMap<AgreementCreateDto, Agreement>();
            CreateMap<Agreement, AgreementCreateDto>();
       ***REMOVED***
   ***REMOVED***
***REMOVED***