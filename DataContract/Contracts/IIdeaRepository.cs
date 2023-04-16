using DataContract.Models;

namespace DataContract.Contracts;

public interface IIdeaRepository
{
    void AddIdea(AddIdeaDto dto);
    void UpdateIdea(UpdateIdeaDto Udto);
    List<GetIdeaDto> GetAllIdeas();
    public GetIdeaDto GetById(int id);
    public GetIdeaDto GetByUserId(int userId);
    void DeleteIdea(int id);
}