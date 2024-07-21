using AutoMapper;
using Core.Entities;

namespace Core.Common.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Dream, Dream>();
        }
    }
}