using System;
using System.Text.Json;
using AutoMapper;
using AuthService.DataTransfer;
using AuthService.Domain;
using Microsoft.Extensions.DependencyInjection;
using AuthService.Data.Interfaces;
using UserService.DataTransfer;

namespace AuthService.EventManager
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IMapper _mapper;
         private readonly IServiceScopeFactory _scopeFactory;


        public EventProcessor(IServiceScopeFactory scopeFactory, AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
            _scopeFactory = scopeFactory;
        }

        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.UserPublished:
                    addUser(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string message)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(message);

            switch(eventType.Event)
            {
                case "User_Published":
                    Console.WriteLine("--> User Published Event Detected");
                    return EventType.UserPublished;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }

        private void addUser(string userConsumedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                
                var userConsumedDto = JsonSerializer.Deserialize<UserConsumeDto>(userConsumedMessage);

                try
                {
                    var user = _mapper.Map<User>(userConsumedDto);
                    if(!_uow.Users.DemandUserExist(userConsumedDto.Username))
                    {
                        _uow.Users.Add(new User 
                        {
                            Username = user.Username,
                            Password = user.Password,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            UserRole = user.UserRole,
                            IsActive = user.IsActive,
                            LastActive = user.LastActive
                        });
                        _uow.Complete();
                        Console.WriteLine("--> User added!");
                    }
                    else
                    {
                        Console.WriteLine("--> User already exists...");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add User to DB {ex.Message}");
                }
            }
        }
    }

    enum EventType
    {
        UserPublished,
        Undetermined
    }
}