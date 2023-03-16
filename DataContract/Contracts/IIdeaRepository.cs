using DataContract.Models;

namespace DataContract.Contracts;

public interface IIdeaRepository
{
    void AddIdea(AddIdeaDto dto);
}