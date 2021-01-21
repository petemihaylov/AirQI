using AirQi.Controllers;
using AirQi.Dtos;
using AirQi.Profiles;
using AirQi.Models.Data;
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
using System.Linq;

namespace Qi.Tests.xUnit.Controllers
{
    public class NotificationsControllerTests
    {
        private readonly IMapper _mapper;
        private readonly MockDataRepository _mock;

        public NotificationsControllerTests()
        {
            this._mock = new MockDataRepository();

            if (this._mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new NotificationsProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

        }

        public IMapper Mapper => _mapper;
        public MockDataRepository Mock => _mock;

        [Fact]
        public void Test_GetAllNotifications_ReturnsOkResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Notification>>();
            var mockHub = new Mock<IHubContext<LiveNotificationHub>>();
            var controller = new NotificationsController(mockRepo.Object, mockHub.Object, Mapper);
            
            // Act
            var okResult = controller.GetAllNotifications();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Test_GetAllNotifications_ReturnsNotFoundResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Notification>>();

            mockRepo.Setup(repo => repo.GetAllAsync())
            .Returns(Task.FromResult((IEnumerable<Notification>)default(Notification)));

            var mockHub = new Mock<IHubContext<LiveNotificationHub>>();
            var controller = new NotificationsController(mockRepo.Object, mockHub.Object, Mapper);
            
            // Act
            var notFoundResult = controller.GetAllNotifications();

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void Test_GetAllNotifications_ReturnsRightItems()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Notification>>();
            var mockHub = new Mock<IHubContext<LiveNotificationHub>>();
            var controller = new NotificationsController(mockRepo.Object, mockHub.Object, Mapper);
            
            // Act
            var okResult = controller.GetAllNotifications();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
            Assert.IsType<List<NotificationReadDto>>((okResult.Result as OkObjectResult).Value); 
            
        }

        [Fact]
        public void Test_GetNotificationById_ReturnsRightItem()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Notification>>();

            double[] position = new double[] { 30.2, 50.3 };
            Notification notification = this.Mock.MockNotification(position);
            notification.Id = ObjectId.GenerateNewId();
            notification.CreatedAt = notification.UpdatedAt = DateTime.UtcNow;

            mockRepo.Setup(repo => repo.GetObjectByIdAsync(notification.Id.ToString()))
            .Returns(Task.FromResult(notification));

            var mockHub = new Mock<IHubContext<LiveNotificationHub>>();
            var controller = new NotificationsController(mockRepo.Object, mockHub.Object, Mapper);
            
            // Act       
            var okResult = controller.GetNotificationById(notification.Id.ToString()).Result as OkObjectResult;

            // Assert
            Assert.IsType<NotificationReadDto>(okResult.Value);
            Assert.Equal(notification.Id.ToString(), (okResult.Value as NotificationReadDto).Id);           
        }

        [Fact]
        public void Test_GetNotificationById_ReturnsNotFoundResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Notification>>();
            var mockHub = new Mock<IHubContext<LiveNotificationHub>>();
            var controller = new NotificationsController(mockRepo.Object, mockHub.Object, Mapper);

            // Act
            var notFoundResult = controller.GetNotificationById(ObjectId.GenerateNewId().ToString());
        
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void Test_CreateNotification_ReturnsOkResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Notification>>();
            var mockHub = new Mock<IHubContext<LiveNotificationHub>>();
            var controller = new NotificationsController(mockRepo.Object, mockHub.Object, Mapper);
            
            double[] position = new double[] { 30.2, 50.3 };
            Notification notification = this.Mock.MockNotification(position);
            notification.Id = ObjectId.GenerateNewId();
            notification.CreatedAt = notification.UpdatedAt = DateTime.UtcNow;

            // Act
            var okResult = controller.CreateNotification(this.Mapper.Map<NotificationCreateDto>(notification));

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Test_CreateNotification_ReturnsNotFoundResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Notification>>();
            var mockHub = new Mock<IHubContext<LiveNotificationHub>>();
            var controller = new NotificationsController(mockRepo.Object, mockHub.Object, Mapper);

            // Act
            var notFoundResult = controller.CreateNotification((NotificationCreateDto) null);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void Test_CreateNotification_ReturnsRightItem()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Notification>>();
            var mockHub = new Mock<IHubContext<LiveNotificationHub>>();
            var controller = new NotificationsController(mockRepo.Object, mockHub.Object, Mapper);
            this.Mock.GenerateMockStations();

            double[] position = new double[] { 30.2, 50.3 };
            Notification notification = this.Mock.MockNotification(position);
            notification.Id = ObjectId.GenerateNewId();
            notification.CreatedAt = notification.UpdatedAt = DateTime.UtcNow;

            // Act
            var okResult = controller.CreateNotification(this.Mapper.Map<NotificationCreateDto>(notification)).Result as OkObjectResult;

            // Assert
            Assert.IsType<NotificationReadDto>(okResult.Value);
            Assert.True(notification.Position.SequenceEqual((okResult.Value as NotificationReadDto).Position));
            
        }

        [Fact]
        public void Test_UpdateNotification_ReturnsOkResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Notification>>();

            double[] position = new double[] { 30.2, 50.3 };
            Notification notification = this.Mock.MockNotification(position);
            notification.Id = ObjectId.GenerateNewId();
            notification.CreatedAt = notification.UpdatedAt = DateTime.UtcNow;

            mockRepo.Setup(repo => repo.GetObjectByIdAsync(notification.Id.ToString()))
            .Returns(Task.FromResult(notification));

            var mockHub = new Mock<IHubContext<LiveNotificationHub>>();
            var controller = new NotificationsController(mockRepo.Object, mockHub.Object, Mapper);
            
            // Act       
            var okResult = controller.UpdateNotification(notification.Id.ToString(), this.Mapper.Map<NotificationCreateDto>(notification));

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result); 
            Assert.IsType<NotificationReadDto>((okResult.Result as OkObjectResult).Value);           
        }

        [Fact]
        public void Test_UpdateNotification_ReturnsNotFoundResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Notification>>();
            var mockHub = new Mock<IHubContext<LiveNotificationHub>>();
            var controller = new NotificationsController(mockRepo.Object, mockHub.Object, Mapper);

            // Act
            var notFoundResult = controller.UpdateNotification(ObjectId.GenerateNewId().ToString(), (NotificationCreateDto) null);
        
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void Test_DeleteNotification_ReturnsOkResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Notification>>();

            double[] position = new double[] { 30.2, 50.3 };
            Notification notification = this.Mock.MockNotification(position);
            notification.Id = ObjectId.GenerateNewId();
            notification.CreatedAt = notification.UpdatedAt = DateTime.UtcNow;

            mockRepo.Setup(repo => repo.GetObjectByIdAsync(notification.Id.ToString()))
            .Returns(Task.FromResult(notification));

            var mockHub = new Mock<IHubContext<LiveNotificationHub>>();
            var controller = new NotificationsController(mockRepo.Object, mockHub.Object, Mapper);
            
            // Act       
            var okResult = controller.DeleteNotification(notification.Id.ToString());

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);           
        }

        [Fact]
        public void Test_DeleteNotification_ReturnsNotFoundResult()
        {
            // Arrange
            var mockRepo = new Mock<IMongoDataRepository<Notification>>();
            var mockHub = new Mock<IHubContext<LiveNotificationHub>>();
            var controller = new NotificationsController(mockRepo.Object, mockHub.Object, Mapper);

            // Act
            var notFoundResult = controller.DeleteNotification(ObjectId.GenerateNewId().ToString());
        
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

    }
}