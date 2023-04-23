using DataContract.Models.Idea;

namespace DataContract.Contracts;

public interface IIdeaRepository
{
    void AddIdea(AddIdeaDto dto);
    void UpdateIdea(UpdateIdeaDto Udto);
    List<GetIdeaDto> GetAllIdeas();
    public GetIdeaDto GetById(int id);
    public GetIdeaDto GetByUserId(int userId);
    public IEnumerable<GetIdeaDto> ShowBySearch(string searchedWord);
    void DeleteIdea(int id);
}