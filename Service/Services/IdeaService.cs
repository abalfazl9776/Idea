using AutoMapper;
using DataContract.Contracts;
using DataContract.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceContract.Contracts;
using ServiceContract.Models;

namespace Service.Services;

public class IdeaService : IIdeaService
{
    private readonly IIdeaRepository _ideaRepository;
    private readonly IMapper _mapper;

    public IdeaService(IIdeaRepository ideaRepository , IMapper mapper)
    {
        _ideaRepository = ideaRepository;
        _mapper = mapper;
    }

    public void CreateIdea(IdeaInputDto inputDto)
    {
        var addIdeaDto = _mapper.Map<AddIdeaDto>(inputDto);
        _ideaRepository.AddIdea(addIdeaDto);
    }
    public void UpdateIdea(UpdateIdeaInputDto inputDto)
    {
        var updateIdeaDto = _mapper.Map<UpdateIdeaDto>(inputDto);
        _ideaRepository.UpdateIdea(updateIdeaDto);
    }
    
    public List <IdeasDTO> GetAllIdeas()
    {
        List<GetIdeaDto> getIdea = _ideaRepository.GetAllIdeas();
        List<IdeasDTO> idea = _mapper.Map<List<IdeasDTO>>(getIdea);
        return idea;
    }

    //public IdeasDTO GetById(int id)
    //{
    //    throw new NotImplementedException();
    //}

    //public IdeasDTO GetByUserId(int userId)
    //{
    //    throw new NotImplementedException();
    
}