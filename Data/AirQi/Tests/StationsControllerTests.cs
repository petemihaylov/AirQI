using AirQi.Controllers;
using AirQi.Dtos;
using AirQi.Profiles;
using AirQi.Models.Core;
using AirQi.Repository.Core;
using AirQi.Repository.Test;
using AssetNXT.Hubs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Moq;
using Xunit;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Qi.Tests
{
    public class StationsControllerTests
    {
        private readonly IMapper _mapper;
        private readonly MockDataRepository _mock;

        public StationsControllerTests()
        {
            this._mock = new MockDataRepository();

            if (this._mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new StationsProfile());
                    mc.AddProfile(new MeasurementsProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

        }

        public IMapper Mapper => _mapper;
        public MockDataRepository Mock => _mock;

        [Fact]
        public void Test_GetAllStations_ReturnsOkResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);
            
            // Act
            var okResult = controller.GetAllStations();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Test_GetAllStations_ReturnsNotFoundResult()
        {
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
        }

        [Fact]
        public void Test_GetStationById_ReturnsRightItem()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();

            double[] position = new double[] { 30.2, 50.3 };
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
        }

        [Fact]
        public void Test_GetStationById_ReturnsNotFoundResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);
            this.Mock.GenerateMockStations();

            // Act
            var notFoundResult = controller.GetStationById(ObjectId.GenerateNewId().ToString());
        
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public async void Test_CreateStation_ReturnsOkResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);
            this.Mock.GenerateMockStations();

            foreach (var position in this.Mock.Positions)
            {
                // Act
                var station = await this.Mock.GetObjectByPositionAsync(position);

                var okResult = controller.CreateStation(this.Mapper.Map<StationCreateDto>(station));

                // Assert
                Assert.IsType<OkObjectResult>(okResult.Result);
            }
        }

        [Fact]
        public void Test_CreateStation_ReturnsNotFoundResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);

            // Act
            var notFoundResult = controller.CreateStation((StationCreateDto) null);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
      
        }

        [Fact]
        public async void Test_CreateStation_ReturnsRightItem()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);
            this.Mock.GenerateMockStations();

            foreach (var position in this.Mock.Positions)
            {
                // Act
                var station = await this.Mock.GetObjectByPositionAsync(position);

                var okResult = controller.CreateStation(this.Mapper.Map<StationCreateDto>(station)).Result as OkObjectResult;

                // Assert
                Assert.IsType<StationReadDto>(okResult.Value);
                Assert.Equal(station.Aqi, (okResult.Value as StationReadDto).Aqi);
            }
        }

        [Fact]
        public void Test_UpdateStation_ReturnsOkResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();

            double[] position = new double[] { 30.2, 50.3 };
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
        }

        [Fact]
        public void Test_UpdateStation_ReturnsNotFoundResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);

            // Act
            var notFoundResult = controller.UpdateStation(ObjectId.GenerateNewId().ToString(), (StationCreateDto) null);
        
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void Test_DeleteStation_ReturnsOkResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();

            double[] position = new double[] { 30.2, 50.3 };
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
        }

        [Fact]
        public void Test_DeleteStation_ReturnsNotFoundResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var mockHub = new Mock<IHubContext<LiveStationHub>>();
            var controller = new StationsController(mockRepo.Object, mockHub.Object, Mapper);

            // Act
            var notFoundResult = controller.DeleteStation(ObjectId.GenerateNewId().ToString());
        
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

    }
}