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
{
    [Produces("application/json")]
    [Route("api/agreements")]
    [ApiController]
    public class AgreementsController : ControllerBase
    {
        private readonly IMongoDataRepository<Agreement> _repository;
        private readonly IMongoDataRepository<Station> _repositoryStation;
        private readonly IMapper _mapper;

        public AgreementsController(IMongoDataRepository<Agreement> repository, IMongoDataRepository<Station> repositoryStation, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _repositoryStation = repositoryStation;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAgreements()
        {
            var agreements = await this._repository.GetAllAsync();

            if (agreements != null)
            {
                return Ok(this._mapper.Map<IEnumerable<AgreementReadDto>>(agreements));
            }

            return NotFound();
        }

        [HttpGet("{id}", Name = "GetAgreementById")]
        public async Task<IActionResult> GetAgreementById(string id)
        {
            var agreement = await this._repository.GetObjectByIdAsync(id);

            if (agreement != null)
            {
                return Ok(this._mapper.Map<AgreementReadDto>(agreement));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAgreement(AgreementCreateDto agreementCreateDto)
        {
            var agreement = this._mapper.Map<Agreement>(agreementCreateDto);

            if (agreement != null)
            {
                await this._repository.CreateObjectAsync(agreement);

                return Ok(this._mapper.Map<AgreementReadDto>(agreement));
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAgreement(string id, AgreementCreateDto agreementCreateDto)
        {
            var agreementModel = this._mapper.Map<Agreement>(agreementCreateDto);
            var agreement = await this._repository.GetObjectByIdAsync(id);

            if (agreement != null)
            {
                agreementModel.UpdatedAt = DateTime.UtcNow;
                agreementModel.Id = new ObjectId(id);
                await this._repository.UpdateObjectAsync(id, agreementModel);
                return Ok(this._mapper.Map<AgreementReadDto>(agreementModel));
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAgreement(string id)
        {
            var agreementModel = await this._repository.GetObjectByIdAsync(id);

            if (agreementModel != null)
            {
                await this._repository.RemoveObjectAsync(agreementModel);
                return Ok("Successfully deleted from collection!");
            }

            return NotFound();
        }
    }
}