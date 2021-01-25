using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirQi.Dtos.Core;
using AirQi.Dtos.Data;
using AirQi.Models.Core;
using AirQi.Models.Data;
using AirQi.Repository.Core;
using AirQi.Services.Configurations;
using AutoMapper;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;

namespace AssetNXT.Controllers
{
    [Produces("application/json")]
    [Route("api/agreement/configurations")]
    [ApiController]
    public class ServiceAgreementController : ControllerBase
    {
        private readonly IMongoDataRepository<Agreement> _agreementRepository;
        private readonly IMongoDataRepository<ServiceAgreement> _serviceAgreementRepository;
        private readonly IMongoDataRepository<Station> _repositoryStation;
        private readonly IMapper _mapper;

        public ServiceAgreementController(IMongoDataRepository<Agreement> agreementRepository, IMongoDataRepository<ServiceAgreement> serviceAgreementRepository, IMongoDataRepository<Station> repositoryStation, IMapper mapper)
        {
            this._repositoryStation = repositoryStation;
            this._agreementRepository = agreementRepository;
            this._serviceAgreementRepository = serviceAgreementRepository;
            this._mapper = mapper;
        }

        private async Task<List<Station>> GetAllObjectsAsync()
        {
            var stations = await this._repositoryStation.GetAllAsync();
            return stations.GroupBy(doc => new { doc.Position }, (key, group) => group.First()).ToList();
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceAgreementByStationId(ServiceAgreementCreateDto serviceAgreementCreateDto)
        {
            var stations = await GetAllObjectsAsync();
            List<Station> collection = new List<Station>();

            foreach (var station in serviceAgreementCreateDto.Stations)
            {
                var obj = stations.Find(doc => doc.Id == station.Id);
                if (obj != null)
                {
                    collection.Add(obj);
                }   
            }

            if (!collection.IsNullOrEmpty())
            {
                var serviceAgreement = new ServiceAgreementConfiguration(collection, this._agreementRepository, this._serviceAgreementRepository);

                var breachedStations = await serviceAgreement.IsBreachedCollection();
                return Ok(_mapper.Map<IEnumerable<ServiceAgreementReadDto>>(breachedStations));
            }

            return NotFound();
        }
    }
}