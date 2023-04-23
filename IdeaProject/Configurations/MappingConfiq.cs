using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataContract.Models.Idea;
using DataContract.Models.User;
using IdeaProject.ViewModels.Idea;
using IdeaProject.ViewModels.User;
using ServiceContract.Models.Idea;
using ServiceContract.Models.User;

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
            CreateMap<IdeaInputVm, UpdateIdeaInputDto>().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Idea)); 
            CreateMap<UpdateIdeaInputDto, UpdateIdeaDto>();
            CreateMap<UpdateIdeaDto, Idea>();
            CreateMap< IdeasDTO , IdeaOutputVm> ().ReverseMap();
            CreateMap<GetIdeaDto, IdeasDTO > ().ReverseMap();
            CreateMap< Idea , GetIdeaDto> ().ForMember(dest => dest.MainIdea, opt => opt.MapFrom(src => src.Description )).ReverseMap();
            CreateMap<IdeaDeleteVm, DeleteDto> ();
            CreateMap<DeleteDto, DeleteIdeaDto> ();
            CreateMap<DeleteIdeaDto, Idea>();


            CreateMap<UserInfoInputVm, UserInfoInputDto>();
            CreateMap<UserInfoInputDto, AddUserDto>().ForMember(dest => dest.DateTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<AddUserDto, User>();
        }
    }
}
