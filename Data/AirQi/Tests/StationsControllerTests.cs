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
***REMOVED***
    public class StationsControllerTests
    ***REMOVED***
        private readonly Mock<IMongoDataRepository<Station>> _repository;
        private readonly Mock<IHubContext<LiveStationHub>> _hub;
        private readonly Mock<IMapper> _mapper;
        private readonly StationsController _controller;
        private readonly MockDataRepository _mock;

        public StationsControllerTests()
        ***REMOVED***
            this._repository = new Mock<IMongoDataRepository<Station>>();
            this._mock = new MockDataRepository();
            this._mapper = new Mock<IMapper>();
            this._hub = new Mock<IHubContext<LiveStationHub>>();
            this._controller = new StationsController(Repository.Object, Hub.Object, Mapper.Object);
       ***REMOVED***

        public Mock<IMongoDataRepository<Station>> Repository => _repository;
        public Mock<IHubContext<LiveStationHub>> Hub => _hub;

        public Mock<IMapper> Mapper => _mapper;

        [Fact]
        public void Test_GetAllStations_OkResult()
        ***REMOVED***
            // Act
            var okResult = this._controller.GetAllStations();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
       ***REMOVED***

        [Fact]
        public void Test_CreateStationMethod()
        ***REMOVED***
            // Prepare
            this._mock.GenerateMockStations();
            
            
            // Act
            var okResult = this._controller.GetAllStations();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
       ***REMOVED***

        

   ***REMOVED***
***REMOVED***
