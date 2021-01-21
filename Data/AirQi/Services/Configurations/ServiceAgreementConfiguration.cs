using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirQi.Models.Data;
using AirQi.Models.Core;
using AirQi.Repository.Core;

namespace AirQi.Services.Configurations
***REMOVED***
    public class ServiceAgreementConfiguration : IServiceConfiguration<ServiceAgreement>
    ***REMOVED***
        private readonly IMongoDataRepository<Agreement> _agreementRepository;
        private readonly IMongoDataRepository<ServiceAgreement> _serviceAgreementRepository;
        private List<Station> _stations;
        private List<ServiceAgreement> _collection;

        public ServiceAgreementConfiguration(List<Station> stations, IMongoDataRepository<Agreement> agreementRepository, IMongoDataRepository<ServiceAgreement> serviceAgreementRepository)
        ***REMOVED***
            this._stations = stations;
            this._collection = new List<ServiceAgreement>();
            this._agreementRepository = agreementRepository;
            this._serviceAgreementRepository = serviceAgreementRepository;
       ***REMOVED***

        public async Task<List<ServiceAgreement>> IsBreachedCollection()
        ***REMOVED***
            var agreements = await this._agreementRepository.GetAllAsync();

            foreach (var station in this._stations)
            ***REMOVED***
                var agreement = agreements.ToList().Where(agreement => agreement.Stations.Any(obj => obj.Position.SequenceEqual(station.Position))).FirstOrDefault();

                if (agreement != null)
                ***REMOVED***
                    ServiceAgreement configuration = new ServiceAgreement();

                    configuration.StationLastUpdate = station.UpdatedAt;
                    configuration.IsAqiAgreementValid = (station.Aqi >= agreement.AqiMin && station.Aqi <= agreement.AqiMax) ? true : false;

                    this._collection.Add(configuration);

                    if (configuration.IsAqiAgreementValid)
                    ***REMOVED***
                        SaveConfiguration(configuration);
                   ***REMOVED***
               ***REMOVED***
           ***REMOVED***


            return this._collection;
       ***REMOVED***

        public void SaveConfiguration(object obj)
        ***REMOVED***
            this._serviceAgreementRepository.CreateObject((ServiceAgreement)obj);
       ***REMOVED***
   ***REMOVED***
***REMOVED***