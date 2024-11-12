using ApexaApp.API.Dtos;
using ApexaApp.API.Models;
using AutoMapper;

namespace ApexaApp.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Advisor, AdvisorDto>().ForMember(dest => dest.HealthStatus, 
            opt => opt.MapFrom(src => src.HealthStatus.ToString()));
            CreateMap<AdvisorDto, Advisor>();
        }
        
    }
}