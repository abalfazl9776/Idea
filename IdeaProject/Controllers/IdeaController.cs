using AutoMapper;
using DataAccess.Entities;
using DataContract.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using IdeaProject.ViewModels.Idea;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using ServiceContract.Contracts;
using ServiceContract.Models.Idea;

namespace IdeaProject.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class IdeaController : ControllerBase
{
    private readonly IValidator<IdeaInputVm> _validator;
    private readonly IIdeaService _ideaService;
    private readonly IMapper _mapper;

    public IdeaController(IIdeaService ideaService, IMapper mapper, IValidator<IdeaInputVm> validator)
    {
        _validator = validator;
        _ideaService = ideaService;
        _mapper = mapper;
    }
    [HttpPost]
    public async Task<IActionResult> CreateIdea(IdeaInputVm ideaInputVm)
    { ValidationResult result = await _validator.ValidateAsync(ideaInputVm);
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
        }
        var ideaInputDto = _mapper.Map<IdeaInputDto>(ideaInputVm);
        ideaInputDto.UserId = 1;
        _ideaService.CreateIdea(ideaInputDto);
        return Ok();
    }
    [HttpPut("id:int")]
    public async Task<IActionResult> UpdateIdea(int id, [FromBody] IdeaInputVm ideaInputVm)
    {
        ValidationResult result = await _validator.ValidateAsync(ideaInputVm);
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
        }
        var ideaInputDto = _mapper.Map<UpdateIdeaInputDto>(ideaInputVm);
        ideaInputDto.Id = id;
        _ideaService.UpdateIdea(ideaInputDto);
        return Ok();
    }
    [HttpGet("id:int")]
    public ActionResult GetIdeaById(int id)
    {
        var getIdea = _ideaService.GetById(id);
        var idea = _mapper.Map<IdeasDTO>(getIdea);
        if (idea == null)
        {
            return NotFound("Invalid ID");
        }
        return Ok(idea);
    }

    [HttpGet("UserId:int")]
    public ActionResult GetIdeaByUserID(int userId)
    {
        var getIdea = _ideaService.GetById(userId);
        var idea = _mapper.Map<IdeaOutputVm>(getIdea);
        if (idea == null)
        {
            return NotFound("Invalid UserID");
        }
        return Ok(idea);
    }

    [HttpGet]
    public  List <IdeaOutputVm> GetAll()
    {
        List<IdeasDTO> getIdeas = _ideaService.GetAllIdeas();
        List<IdeaOutputVm> getAllIdeas = _mapper.Map<List<IdeaOutputVm>>(getIdeas);
        return getAllIdeas;
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        _ideaService.DeleteIdea(id);
        return Ok();
    }
    [HttpGet("SearchBar:string")]
    public ActionResult OnPostAsync(string searchBar)
    {
        var getIdeaByWord = _ideaService.ShowBySearch(searchBar);
        List<IdeaOutputVm> idea = _mapper.Map<List<IdeaOutputVm>>(getIdeaByWord);
        return Ok(idea);
        
    }
   
}