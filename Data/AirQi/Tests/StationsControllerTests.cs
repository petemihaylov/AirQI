using AirQi.Controllers;
using AirQi.Models.Core;
using AirQi.Repository;
using AutoMapper;
using Moq;
using Xunit;

namespace Qi.Tests
{
    public class StationsControllerTests
    {
        private readonly Mock<IMongoDataRepository<Station>> _repository;
        private readonly Mock<IMapper> _mapper;

        private readonly StationsController _controller;

        public StationsControllerTests()
        {
            this._repository = new Mock<IMongoDataRepository<Station>>();
            this._mapper = new Mock<IMapper>();
            this._controller = new StationsController(Repository.Object, Mapper.Object);
        }

        public Mock<IMongoDataRepository<Station>> Repository => _repository;

        public Mock<IMapper> Mapper => _mapper;

        [Fact]
        public void Test_GetAllStations_NotFound()
        {
            
        }
    }
}
