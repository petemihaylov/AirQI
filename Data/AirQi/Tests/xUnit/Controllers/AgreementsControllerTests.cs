using AirQi.Controllers;
using AirQi.Profiles;
using AirQi.Models.Data;
using AirQi.Repository.Core;
using AirQi.Repository.Test;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using AirQi.Models.Core;
using AirQi.Dtos.Core;

namespace Qi.Tests.xUnit.Controllers
***REMOVED***
    public class AgreementsControllerTests
    ***REMOVED***
        private readonly IMapper _mapper;
        private readonly MockDataRepository _mock;

        public AgreementsControllerTests()
        ***REMOVED***
            this._mock = new MockDataRepository();

            if (this._mapper == null)
            ***REMOVED***
                var mappingConfig = new MapperConfiguration(mc =>
                ***REMOVED***
                    mc.AddProfile(new AgreementsProfile());
               ***REMOVED***);
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
           ***REMOVED***

       ***REMOVED***

        public IMapper Mapper => _mapper;
        public MockDataRepository Mock => _mock;

        [Fact]
        public void Test_GetAllAgreements_ReturnsOkResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Agreement>>();
            var mockRepoStation = new Mock<IMongoDataRepository<Station>>();
            var controller = new AgreementsController(mockRepo.Object, mockRepoStation.Object, Mapper);
            
            // Act
            var okResult = controller.GetAllAgreements();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
       ***REMOVED***

        [Fact]
        public void Test_GetAllAgreements_ReturnsNotFoundResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Agreement>>();
            mockRepo.Setup(repo => repo.GetAllAsync())
            .Returns(Task.FromResult((IEnumerable<Agreement>)default(Agreement)));

            
            var mockRepoStation = new Mock<IMongoDataRepository<Station>>();
            var controller = new AgreementsController(mockRepo.Object, mockRepoStation.Object, Mapper);
            
            // Act
            var notFoundResult = controller.GetAllAgreements();

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
       ***REMOVED***

        [Fact]
        public void Test_GetAllAgreements_ReturnsRightItems()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Agreement>>();
            var mockRepoStation = new Mock<IMongoDataRepository<Station>>();
            var controller = new AgreementsController(mockRepo.Object, mockRepoStation.Object, Mapper);
            
            // Act
            var okResult = controller.GetAllAgreements();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
            Assert.IsType<List<AgreementReadDto>>((okResult.Result as OkObjectResult).Value); 
            
       ***REMOVED***

        [Fact]
        public void Test_GetAgreementById_ReturnsRightItem()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Agreement>>();

            this.Mock.GenerateMockStations();
            List<Station> stations = this.Mock.GetAll().ToList();

            Agreement agreement = this.Mock.MockAgreement(stations);
            agreement.Id = ObjectId.GenerateNewId();
            agreement.CreatedAt = agreement.UpdatedAt = DateTime.UtcNow;

            mockRepo.Setup(repo => repo.GetObjectByIdAsync(agreement.Id.ToString()))
            .Returns(Task.FromResult(agreement));

            var mockRepoStation = new Mock<IMongoDataRepository<Station>>();
            var controller = new AgreementsController(mockRepo.Object, mockRepoStation.Object, Mapper);

            // Act       
            var okResult = controller.GetAgreementById(agreement.Id.ToString()).Result as OkObjectResult;

            // Assert
            Assert.IsType<AgreementReadDto>(okResult.Value);
            Assert.Equal(agreement.Id.ToString(), (okResult.Value as AgreementReadDto).Id);           
       ***REMOVED***

        [Fact]
        public void Test_GetAgreementById_ReturnsNotFoundResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Agreement>>();
            var mockRepoStation = new Mock<IMongoDataRepository<Station>>();
            var controller = new AgreementsController(mockRepo.Object, mockRepoStation.Object, Mapper);

            // Act
            var notFoundResult = controller.GetAgreementById(ObjectId.GenerateNewId().ToString());
        
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
       ***REMOVED***

        [Fact]
        public void Test_CreateAgreement_ReturnsOkResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Agreement>>();

            this.Mock.GenerateMockStations();
            List<Station> stations = this.Mock.GetAll().ToList();

            Agreement agreement = this.Mock.MockAgreement(stations);
            agreement.Id = ObjectId.GenerateNewId();
            agreement.CreatedAt = agreement.UpdatedAt = DateTime.UtcNow;

            mockRepo.Setup(repo => repo.GetObjectByIdAsync(agreement.Id.ToString()))
            .Returns(Task.FromResult(agreement));

            var mockRepoStation = new Mock<IMongoDataRepository<Station>>();
            var controller = new AgreementsController(mockRepo.Object, mockRepoStation.Object, Mapper);

            // Act
            var okResult = controller.CreateAgreement(this.Mapper.Map<AgreementCreateDto>(agreement));

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
       ***REMOVED***

        [Fact]
        public void Test_CreateAgreement_ReturnsNotFoundResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Agreement>>();
            var mockRepoStation = new Mock<IMongoDataRepository<Station>>();
            var controller = new AgreementsController(mockRepo.Object, mockRepoStation.Object, Mapper);

            // Act
            var notFoundResult = controller.CreateAgreement((AgreementCreateDto) null);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
       ***REMOVED***

        [Fact]
        public void Test_CreateAgreement_ReturnsRightItem()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Agreement>>();

            this.Mock.GenerateMockStations();
            List<Station> stations = this.Mock.GetAll().ToList();

            Agreement agreement = this.Mock.MockAgreement(stations);
            agreement.Id = ObjectId.GenerateNewId();
            agreement.CreatedAt = agreement.UpdatedAt = DateTime.UtcNow;

            mockRepo.Setup(repo => repo.GetObjectByIdAsync(agreement.Id.ToString()))
            .Returns(Task.FromResult(agreement));

            var mockRepoStation = new Mock<IMongoDataRepository<Station>>();
            var controller = new AgreementsController(mockRepo.Object, mockRepoStation.Object, Mapper);

            // Act       
            var okResult = controller.UpdateAgreement(agreement.Id.ToString(), this.Mapper.Map<AgreementCreateDto>(agreement));

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
            Assert.IsType<AgreementReadDto>((okResult.Result as OkObjectResult).Value);
            Assert.True(agreement.Id.ToString() == ((okResult.Result as OkObjectResult).Value as AgreementReadDto).Id);
            
       ***REMOVED***

        [Fact]
        public void Test_UpdateAgreement_ReturnsOkResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Agreement>>();

            this.Mock.GenerateMockStations();
            List<Station> stations = this.Mock.GetAll().ToList();

            Agreement agreement = this.Mock.MockAgreement(stations);
            agreement.Id = ObjectId.GenerateNewId();
            agreement.CreatedAt = agreement.UpdatedAt = DateTime.UtcNow;

            mockRepo.Setup(repo => repo.GetObjectByIdAsync(agreement.Id.ToString()))
            .Returns(Task.FromResult(agreement));

            var mockRepoStation = new Mock<IMongoDataRepository<Station>>();
            var controller = new AgreementsController(mockRepo.Object, mockRepoStation.Object, Mapper);

            // Act       
            var okResult = controller.UpdateAgreement(agreement.Id.ToString(), this.Mapper.Map<AgreementCreateDto>(agreement));

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result); 
            Assert.IsType<AgreementReadDto>((okResult.Result as OkObjectResult).Value);           
       ***REMOVED***

        [Fact]
        public void Test_UpdateAgreement_ReturnsNotFoundResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Agreement>>();
            var mockRepoStation = new Mock<IMongoDataRepository<Station>>();
            var controller = new AgreementsController(mockRepo.Object, mockRepoStation.Object, Mapper);

            // Act
            var notFoundResult = controller.UpdateAgreement(ObjectId.GenerateNewId().ToString(), (AgreementCreateDto) null);
        
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
       ***REMOVED***

        [Fact]
        public void Test_DeleteAgreement_ReturnsOkResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Agreement>>();
            this.Mock.GenerateMockStations();
            List<Station> stations = this.Mock.GetAll().ToList();

            Agreement agreement = this.Mock.MockAgreement(stations);
            agreement.Id = ObjectId.GenerateNewId();
            agreement.CreatedAt = agreement.UpdatedAt = DateTime.UtcNow;

            mockRepo.Setup(repo => repo.GetObjectByIdAsync(agreement.Id.ToString()))
            .Returns(Task.FromResult(agreement));

            var mockRepoStation = new Mock<IMongoDataRepository<Station>>();
            var controller = new AgreementsController(mockRepo.Object, mockRepoStation.Object, Mapper);

            // Act       
            var okResult = controller.DeleteAgreement(agreement.Id.ToString());

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);           
       ***REMOVED***

        [Fact]
        public void Test_DeleteAgreement_ReturnsNotFoundResult()
        ***REMOVED***
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Agreement>>();
            var mockRepoStation = new Mock<IMongoDataRepository<Station>>();
            var controller = new AgreementsController(mockRepo.Object, mockRepoStation.Object, Mapper);

            // Act
            var notFoundResult = controller.DeleteAgreement(ObjectId.GenerateNewId().ToString());
        
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
       ***REMOVED***

   ***REMOVED***
***REMOVED***