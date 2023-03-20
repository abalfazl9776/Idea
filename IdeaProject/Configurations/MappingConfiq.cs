using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataContract.Models;
using IdeaProject.ViewModels;
using ServiceContract.Models;

namespace IdeaProject.Configurations
{
    public class MappingConfiq : Profile
    {
        public MappingConfiq()
        {
            CreateMap<IdeaInputVm, IdeaInputDto>();
            CreateMap<IdeaInputDto, AddIdeaDto>()
                .ForMember(dest => dest.DateTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<AddIdeaDto, Idea>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Idea))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
