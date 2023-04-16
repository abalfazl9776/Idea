using AutoMapper;
using DataContract.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using IdeaProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using ServiceContract.Contracts;
using ServiceContract.Models;

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
    public async Task<ActionResult>GetAllIdeas(int id,IdeaOutputVm ideaOutputVm)
    {
       
       var ideasDto = _mapper.Map<IdeasDTO>(ideaOutputVm);
       ideasDto.UserId = id;
       return Ok(ideasDto);
    }
    [HttpGet]
    public  List <IdeaOutputVm> GetAll()
    {
        List<IdeasDTO> getIdeas = _ideaService.GetAllIdeas();
        List<IdeaOutputVm> getAllIdeas = _mapper.Map<List<IdeaOutputVm>>(getIdeas);
        return getAllIdeas;
    }
}