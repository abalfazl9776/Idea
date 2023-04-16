﻿using ServiceContract.Models;

namespace ServiceContract.Contracts;

public interface IIdeaService
{
    void CreateIdea(IdeaInputDto inputDto);
    void UpdateIdea(UpdateIdeaInputDto inputDto);
    List<IdeasDTO> GetAllIdeas();
    public IdeasDTO GetById(int id);
    public IdeasDTO GetByUserId(int userId);
    void DeleteIdea(int id);
}