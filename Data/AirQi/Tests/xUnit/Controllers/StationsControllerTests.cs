using AirQi.Controllers;
using AirQi.Dtos;
using AirQi.Profiles;
using AirQi.Models.Core;
using AirQi.Repository.Core;
using AirQi.Repository.Test;
using AirQi.Hubs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Moq;
using Xunit;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qi.Tests.xUnit.Controllers
***REMOVED***
    public class StationsControllerTests
    ***REMOVED***
        private readonly IMapper _mapper;
        private readonly MockDataRepository _mock;

        public StationsControllerTests()
        ***REMOVED***
            this._mock = new MockDataRepository();

            if (this._mapper == null)
            ***REMOVED***
                var mappingConfig = new MapperConfiguration(mc =>
                ***REMOVED***
                    mc.AddProfile(new StationsProfile());
                    mc.AddProfile(new MeasurementsProfile());
               ***REMOVED***);
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
           ***REMOVED***

       ***REMOVED***

        public IMapper Mapper => _mapper;
        public MockDataRepository Mock => _mock;

        [Fact]
        public void Test_GetAllStations_ReturnsOkResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);
            
            // Act
            var okResult = controller.GetAllStations();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
       ***REMOVED***

        [Fact]
        public void Test_GetAllStations_ReturnsNotFoundResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();

            mockRepo.Setup(repo => repo.GetAllAsync())
            .Returns(Task.FromResult((IEnumerable<Station>)default(Station)));

            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);
            
            // Act
            var notFoundResult = controller.GetAllStations();

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
       ***REMOVED***

        [Fact]
        public void Test_GetAllStations_ReturnsRightItems()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);
            
            // Act
            var okResult = controller.GetAllStations();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
            Assert.IsType<List<StationReadDto>>((okResult.Result as OkObjectResult).Value); 
            
       ***REMOVED***

        [Fact]
        public void Test_GetStationById_ReturnsRightItem()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();

            double[] position = new double[] ***REMOVED*** 30.2, 50.3***REMOVED***;
            Station station = this.Mock.MockStation(position);
            station.Id = ObjectId.GenerateNewId();
            station.CreatedAt = station.UpdatedAt = DateTime.UtcNow;

            mockRepo.Setup(repo => repo.GetObjectByIdAsync(station.Id.ToString()))
            .Returns(Task.FromResult(station));

            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);
            
            // Act       
            var okResult = controller.GetStationById(station.Id.ToString()).Result as OkObjectResult;

            // Assert
            Assert.IsType<StationReadDto>(okResult.Value);
            Assert.Equal(station.Id.ToString(), (okResult.Value as StationReadDto).Id);           
       ***REMOVED***

        [Fact]
        public void Test_GetStationById_ReturnsNotFoundResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);
            this.Mock.GenerateMockStations();

            // Act
            var notFoundResult = controller.GetStationById(ObjectId.GenerateNewId().ToString());
        
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
       ***REMOVED***

        [Fact]
        public async void Test_CreateStation_ReturnsOkResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);
            this.Mock.GenerateMockStations();

            foreach (var position in this.Mock.Positions)
            ***REMOVED***
                // Act
                var station = await this.Mock.GetObjectByPositionAsync(position);

                var okResult = controller.CreateStation(this.Mapper.Map<StationCreateDto>(station));

                // Assert
                Assert.IsType<OkObjectResult>(okResult.Result);
           ***REMOVED***
       ***REMOVED***

        [Fact]
        public void Test_CreateStation_ReturnsNotFoundResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);

            // Act
            var notFoundResult = controller.CreateStation((StationCreateDto) null);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
       ***REMOVED***

        [Fact]
        public async void Test_CreateStation_ReturnsRightItem()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);
            this.Mock.GenerateMockStations();

            foreach (var position in this.Mock.Positions)
            ***REMOVED***
                // Act
                var station = await this.Mock.GetObjectByPositionAsync(position);

                var okResult = controller.CreateStation(this.Mapper.Map<StationCreateDto>(station)).Result as OkObjectResult;

                // Assert
                Assert.IsType<StationReadDto>(okResult.Value);
                Assert.Equal(station.Aqi, (okResult.Value as StationReadDto).Aqi);
           ***REMOVED***
       ***REMOVED***

        [Fact]
        public void Test_UpdateStation_ReturnsOkResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();

            double[] position = new double[] ***REMOVED*** 30.2, 50.3***REMOVED***;
            Station station = this.Mock.MockStation(position);
            station.Id = ObjectId.GenerateNewId();
            station.CreatedAt = station.UpdatedAt = DateTime.UtcNow;

            mockRepo.Setup(repo => repo.GetObjectByIdAsync(station.Id.ToString()))
            .Returns(Task.FromResult(station));

            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);
            
            // Act       
            var okResult = controller.UpdateStation(station.Id.ToString(), this.Mapper.Map<StationCreateDto>(station));

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result); 
            Assert.IsType<StationReadDto>((okResult.Result as OkObjectResult).Value);           
       ***REMOVED***

        [Fact]
        public void Test_UpdateStation_ReturnsNotFoundResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);

            // Act
            var notFoundResult = controller.UpdateStation(ObjectId.GenerateNewId().ToString(), (StationCreateDto) null);
        
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
       ***REMOVED***

        [Fact]
        public void Test_DeleteStation_ReturnsOkResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();

            double[] position = new double[] ***REMOVED*** 30.2, 50.3***REMOVED***;
            Station station = this.Mock.MockStation(position);
            station.Id = ObjectId.GenerateNewId();
            station.CreatedAt = station.UpdatedAt = DateTime.UtcNow;

            mockRepo.Setup(repo => repo.GetObjectByIdAsync(station.Id.ToString()))
            .Returns(Task.FromResult(station));

            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);
            
            // Act       
            var okResult = controller.DeleteStation(station.Id.ToString());

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);           
       ***REMOVED***

        [Fact]
        public void Test_DeleteStation_ReturnsNotFoundResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);

            // Act
            var notFoundResult = controller.DeleteStation(ObjectId.GenerateNewId().ToString());
        
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
       ***REMOVED***

   ***REMOVED***
***REMOVED***