using AirQi.Controllers;
using AirQi.Models.Core;
using AirQi.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Qi.Tests
{
    public class MeasurementsControllerTests
    {
        private readonly Mock<IMongoDataRepository<Station>> _repository;
        private readonly Mock<IMapper> _mapper;

        private readonly MeasurementsController _controller;

        public MeasurementsControllerTests()
        {
            this._repository = new Mock<IMongoDataRepository<Station>>();
            this._mapper = new Mock<IMapper>();
            this._controller = new MeasurementsController(Repository.Object, Mapper.Object);
        }

        public Mock<IMongoDataRepository<Station>> Repository => _repository;

        public Mock<IMapper> Mapper => _mapper;

        [Fact]
        public void Test_GetAllMeasurements_OkResult()
        {
            // Act
            var okResult = _controller.GetAllMeasurements();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
