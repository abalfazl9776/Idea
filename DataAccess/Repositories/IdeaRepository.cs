using AutoMapper;
using DataAccess.Entities;
using DataContract.Contracts;
using DataContract.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

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

    public void DeleteIdea(int id)
    {
        var idea = _applicationDbContext.Idea.FirstOrDefault(x=>x.Id==id);
        if(idea==null) 
        {
            throw new Exception("Not Found");
        }
        _applicationDbContext.Idea.Remove(idea);
        _applicationDbContext.SaveChanges();
    }

    public List <GetIdeaDto> GetAllIdeas()
    {
        List<Idea> idea = _applicationDbContext.Idea.ToList();
        List<GetIdeaDto> getIdea = _mapper.Map<List<GetIdeaDto>>(idea);
        return getIdea;

    }

    public GetIdeaDto GetById(int id)
    {
        var idea  = _applicationDbContext.Idea.FirstOrDefault(x=>x.Id==id);
        var getIdea = _mapper.Map<GetIdeaDto>(idea);
        return getIdea;
    }

    public GetIdeaDto GetByUserId(int userId)
    { 
        var idea = _applicationDbContext.Idea.FirstOrDefault(x => x.UserId == userId);
        var getIdea = _mapper.Map<GetIdeaDto>(idea);
        return getIdea;
    }

    public IEnumerable < GetIdeaDto> ShowBySearch(string searchedWord)
    {
        List<Idea> idea = _applicationDbContext.Idea.Where(x => x.Description.Contains(searchedWord) || x.Title.Contains(searchedWord)).ToList();
        List<GetIdeaDto> getIdeaBySearch = _mapper.Map<List< GetIdeaDto> > (idea);
        return getIdeaBySearch;
    }

    public void UpdateIdea(UpdateIdeaDto uDto)
    {
        var idea = _applicationDbContext.Idea.Find(uDto.Id);
        idea = _mapper.Map<UpdateIdeaDto, Idea>(uDto, idea);
        _applicationDbContext.Idea.Update(idea);
        _applicationDbContext.SaveChanges();
    }



} 