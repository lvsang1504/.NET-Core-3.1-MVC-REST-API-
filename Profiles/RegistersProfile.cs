using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles 
{
    public class RegistersProfile : Profile
    {
        public RegistersProfile()
        {
            //Source -> Target
            CreateMap<Register, RegisterReadDto>();
            CreateMap<RegisterCreateDto, Register>();
            CreateMap<RegisterUpdateDto, Register>();
            CreateMap<Register, RegisterUpdateDto>();
        }
    }
}