using AutoMapper;
using DataContract.Contracts;
using DataContract.Models;
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
}