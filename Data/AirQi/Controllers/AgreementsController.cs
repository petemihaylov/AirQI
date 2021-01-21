using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AirQi.Dtos.Core;
using AirQi.Models.Core;
using AirQi.Models.Data;
using AirQi.Repository.Core;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using MongoDB.Bson;

namespace AirQi.Controllers
***REMOVED***
    [Produces("application/json")]
    [Route("api/agreements")]
    [ApiController]
    public class AgreementsController : ControllerBase
    ***REMOVED***
        private readonly IMongoDataRepository<Agreement> _repository;
        private readonly IMongoDataRepository<Station> _repositoryStation;
        private readonly IMapper _mapper;

        public AgreementsController(IMongoDataRepository<Agreement> repository, IMongoDataRepository<Station> repositoryStation, IMapper mapper)
        ***REMOVED***
            _mapper = mapper;
            _repository = repository;
            _repositoryStation = repositoryStation;
       ***REMOVED***

        [HttpGet]
        public async Task<IActionResult> GetAllAgreements()
        ***REMOVED***
            var agreements = await this._repository.GetAllAsync();

            if (agreements != null)
            ***REMOVED***
                return Ok(this._mapper.Map<IEnumerable<AgreementReadDto>>(agreements));
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpGet("***REMOVED***id***REMOVED***", Name = "GetAgreementById")]
        public async Task<IActionResult> GetAgreementById(string id)
        ***REMOVED***
            var agreement = await this._repository.GetObjectByIdAsync(id);

            if (agreement != null)
            ***REMOVED***
                return Ok(this._mapper.Map<AgreementReadDto>(agreement));
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpPost]
        public async Task<IActionResult> CreateAgreement(AgreementCreateDto agreementCreateDto)
        ***REMOVED***
            var agreement = this._mapper.Map<Agreement>(agreementCreateDto);

            if (agreement != null)
            ***REMOVED***
                await this._repository.CreateObjectAsync(agreement);

                return Ok(this._mapper.Map<AgreementReadDto>(agreement));
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpPut("***REMOVED***id***REMOVED***")]
        public async Task<IActionResult> UpdateAgreement(string id, AgreementCreateDto agreementCreateDto)
        ***REMOVED***
            var agreementModel = this._mapper.Map<Agreement>(agreementCreateDto);
            var agreement = await this._repository.GetObjectByIdAsync(id);

            if (agreement != null)
            ***REMOVED***
                agreementModel.UpdatedAt = DateTime.UtcNow;
                agreementModel.Id = new ObjectId(id);
                await this._repository.UpdateObjectAsync(id, agreementModel);
                return Ok(this._mapper.Map<AgreementReadDto>(agreementModel));
           ***REMOVED***

            return NotFound();
       ***REMOVED***

        [HttpDelete("***REMOVED***id***REMOVED***")]
        public async Task<ActionResult> DeleteAgreement(string id)
        ***REMOVED***
            var agreementModel = await this._repository.GetObjectByIdAsync(id);

            if (agreementModel != null)
            ***REMOVED***
                await this._repository.RemoveObjectAsync(agreementModel);
                return Ok("Successfully deleted from collection!");
           ***REMOVED***

            return NotFound();
       ***REMOVED***
   ***REMOVED***
***REMOVED***