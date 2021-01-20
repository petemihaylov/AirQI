using AirQi.Controllers;
using AirQi.Models.Core;
using AirQi.Repository.Core;
using AirQi.Repository.Test;
using AssetNXT.Hubs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Moq;
using Xunit;

namespace Qi.Tests
{
    public class StationsControllerTests
    {
        private readonly Mock<IMongoDataRepository<Station>> _repository;
        private readonly Mock<IHubContext<LiveStationHub>> _hub;
        private readonly Mock<IMapper> _mapper;
        private readonly StationsController _controller;
        private readonly MockDataRepository _mock;

        public StationsControllerTests()
        {
            this._repository = new Mock<IMongoDataRepository<Station>>();
            this._mock = new MockDataRepository();
            this._mapper = new Mock<IMapper>();
            this._hub = new Mock<IHubContext<LiveStationHub>>();
            this._controller = new StationsController(Repository.Object, Hub.Object, Mapper.Object);
        }

        public Mock<IMongoDataRepository<Station>> Repository => _repository;
        public Mock<IHubContext<LiveStationHub>> Hub => _hub;

        public Mock<IMapper> Mapper => _mapper;

        [Fact]
        public void Test_GetAllStations_OkResult()
        {
            // Act
            var okResult = this._controller.GetAllStations();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Test_CreateStationMethod()
        {
            // Prepare
            this._mock.GenerateMockStations();
            
            
            // Act
            var okResult = this._controller.GetAllStations();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        

    }
}
