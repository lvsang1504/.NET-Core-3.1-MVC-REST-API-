using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles 
{
    public class TopicsProfile : Profile
    {
        public TopicsProfile()
        {
            //Source -> Target
            CreateMap<Topic, TopicReadDto>();
            CreateMap<TopicCreateDto, Topic>();
            CreateMap<TopicUpdateDto, Topic>();
            CreateMap<Topic, TopicUpdateDto>();
        }
    }
}