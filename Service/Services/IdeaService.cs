using DataContract.Contracts;
using DataContract.Models;
using ServiceContract.Contracts;
using ServiceContract.Models;

namespace Service.Services;

public class IdeaService : IIdeaService
{
    private readonly IIdeaRepository _ideaRepository;

    public IdeaService(IIdeaRepository ideaRepository)
    {
        _ideaRepository = ideaRepository;
    }

    public void CreateIdea(IdeaInputDto inputDto)
    {
        _ideaRepository.AddIdea(new AddIdeaDto()
        {
            Idea = inputDto.Idea,
            Title = inputDto.Title,
            UserId = inputDto.UserId,
            DateTime = DateTime.Now
        });
    }
}