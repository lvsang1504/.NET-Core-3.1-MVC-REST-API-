using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles 
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            //Source -> Target
            CreateMap<Notification, NotificationReadDto>();
            CreateMap<NotificationCreateDto, Notification>();
            CreateMap<NotificationUpdateDto, Notification>();
            CreateMap<Notification, NotificationUpdateDto>();
        }
    }
}