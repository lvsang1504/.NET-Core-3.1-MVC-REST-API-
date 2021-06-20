using AutoMapper;
using Commander.Dtos;
using Commander.Models;

namespace Commander.Profiles 
{
    public class PeriodicReportProfile : Profile
    {
        public PeriodicReportProfile()
        {
            //Source -> Target
            CreateMap<PeriodicReportItem, PeriodicReportItemReadDto>();
            CreateMap<PeriodicReportItemCreateDto, PeriodicReportItem>();
            CreateMap<PeriodicReportItemUpdateDto, PeriodicReportItem>();
            CreateMap<PeriodicReportItem, PeriodicReportItemUpdateDto>();
        }
    }
}