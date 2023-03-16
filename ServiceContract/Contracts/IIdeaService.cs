using ServiceContract.Models;

namespace ServiceContract.Contracts;

public interface IIdeaService
{
    void CreateIdea(IdeaInputDto inputDto);
}