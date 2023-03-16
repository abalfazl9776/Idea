using DataAccess.Entities;
using DataContract.Contracts;
using DataContract.Models;

namespace DataAccess.Repositories;

public class IdeaRepository : IIdeaRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public IdeaRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public void AddIdea(AddIdeaDto dto)
    {
        _applicationDbContext.Idea.Add(new Idea()
        {
            Description = dto.Idea,
            Title = dto.Title,
            DateTime = dto.DateTime,
            UserId = dto.UserId
        });
        _applicationDbContext.SaveChanges();
    }

}