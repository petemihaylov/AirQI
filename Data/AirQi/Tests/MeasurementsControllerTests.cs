using System.Collections.Generic;
using System.Threading.Tasks;
using AirQi.Controllers;
using AirQi.Dtos;
using AirQi.Models.Core;
using AirQi.Profiles;
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
    public class MeasurementsControllerTests
    {
        private readonly IMapper _mapper;
        private readonly MockDataRepository _mock;

        public MeasurementsControllerTests()
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
        public void Test_GetAllMeasurements_ReturnsOkResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var controller = new MeasurementsController(mockRepo.Object, Mapper);
            
            // Act
            var okResult = controller.GetAllMeasurements();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
            Assert.IsType<List<StationMeasurementReadDto>>((okResult.Result as OkObjectResult).Value); 
        }

        [Fact]
        public void Test_GetAllMeasurements_ReturnsNotFoundResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();

            mockRepo.Setup(repo => repo.GetAllAsync())
            .Returns(Task.FromResult((IEnumerable<Station>)default(Station)));

            var controller = new MeasurementsController(mockRepo.Object, Mapper);
            
            // Act
            var notFoundResult = controller.GetAllMeasurements();

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        
    }
}
