using AutoMapper;
using DataAccess.Entities;
using DataContract.Contracts;
using DataContract.Models;

namespace DataAccess.Repositories;

public class IdeaRepository : IIdeaRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public IdeaRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public void AddIdea(AddIdeaDto dto)
    {
        var idea = _mapper.Map<Idea>(dto);
        _applicationDbContext.Idea.Add(idea);
        _applicationDbContext.SaveChanges();
    }

}