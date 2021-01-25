using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirQi.Models.Data;
using AirQi.Models.Core;
using AirQi.Repository.Core;

namespace AirQi.Services.Configurations
{
    public class ServiceAgreementConfiguration : IServiceConfiguration<ServiceAgreement>
    {
        private readonly IMongoDataRepository<Agreement> _agreementRepository;
        private readonly IMongoDataRepository<ServiceAgreement> _serviceAgreementRepository;
        private List<Station> _stations;
        private List<ServiceAgreement> _collection;

        public ServiceAgreementConfiguration(List<Station> stations, IMongoDataRepository<Agreement> agreementRepository, IMongoDataRepository<ServiceAgreement> serviceAgreementRepository)
        {
            this._stations = stations;
            this._collection = new List<ServiceAgreement>();
            this._agreementRepository = agreementRepository;
            this._serviceAgreementRepository = serviceAgreementRepository;
        }

        public async Task<List<ServiceAgreement>> IsBreachedCollection()
        {
            var agreements = await this._agreementRepository.GetAllAsync();

            foreach (var station in this._stations)
            {
                var agreement = agreements.ToList().Where(agreement => agreement.Stations.Any(obj => obj.Position.SequenceEqual(station.Position))).FirstOrDefault();

                if (agreement != null)
                {
                    ServiceAgreement configuration = new ServiceAgreement();

                    configuration.StationLastUpdate = station.UpdatedAt;
                    configuration.IsAqiAgreementValid = (station.Aqi >= agreement.AqiMin && station.Aqi <= agreement.AqiMax) ? true : false;

                    this._collection.Add(configuration);

                    if (configuration.IsAqiAgreementValid)
                    {
                        SaveConfiguration(configuration);
                    }
                }
            }


            return this._collection;
        }

        public void SaveConfiguration(object obj)
        {
            this._serviceAgreementRepository.CreateObject((ServiceAgreement)obj);
        }
    }
}