using AirQi.Dtos;
using AirQi.Models.Data;

using AutoMapper;

namespace AirQi.Profiles
{
    public class NotificationsProfile : Profile
    {
        public NotificationsProfile()
        {
            CreateMap<Notification, NotificationReadDto>();
            CreateMap<NotificationCreateDto, Notification>();
            CreateMap<Notification, NotificationCreateDto>();
        }
    }
}