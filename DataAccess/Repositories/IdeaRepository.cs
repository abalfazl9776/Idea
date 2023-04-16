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

    public List <GetIdeaDto> GetAllIdeas()
    {
        List<Idea> idea = _applicationDbContext.Idea.ToList();
        List<GetIdeaDto> getIdea = _mapper.Map<List<GetIdeaDto>>(idea);
        return getIdea;

    }

    //public GetIdeaDto GetById(int id)
    //{
    //    try
    //    {
    //        if (id != null)
    //        {
    //            var idea = _applicationDbContext.Idea.FirstOrDefault(x => x.Id == id);
    //            if (idea != null) return idea;
    //            else return null;
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}

    //public GetIdeaDto GetByUserId(int userId)
    //{
    //    try
    //    {
    //        if (userId != null)
    //        {
    //            var idea = _applicationDbContext.Idea.FirstOrDefault(x => x.UserId == userId);
    //            if (idea != null) return idea;
    //            else return null;
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}

    public void UpdateIdea(UpdateIdeaDto uDto)
    {
        var idea = _applicationDbContext.Idea.Find(uDto.Id);
        idea = _mapper.Map<UpdateIdeaDto, Idea>(uDto, idea);
        _applicationDbContext.Idea.Update(idea);
        _applicationDbContext.SaveChanges();
    }



}