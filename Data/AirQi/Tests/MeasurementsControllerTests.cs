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
***REMOVED***
    public class MeasurementsControllerTests
    ***REMOVED***
        private readonly IMapper _mapper;
        private readonly MockDataRepository _mock;

        public MeasurementsControllerTests()
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
        public void Test_GetAllMeasurements_ReturnsOkResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();
            var controller = new MeasurementsController(mockRepo.Object, Mapper);
            
            // Act
            var okResult = controller.GetAllMeasurements();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
            Assert.IsType<List<StationMeasurementReadDto>>((okResult.Result as OkObjectResult).Value); 
       ***REMOVED***

        [Fact]
        public void Test_GetAllMeasurements_ReturnsNotFoundResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Station>>();

            mockRepo.Setup(repo => repo.GetAllAsync())
            .Returns(Task.FromResult((IEnumerable<Station>)default(Station)));

            var controller = new MeasurementsController(mockRepo.Object, Mapper);
            
            // Act
            var notFoundResult = controller.GetAllMeasurements();

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
       ***REMOVED***

        
   ***REMOVED***
***REMOVED***
