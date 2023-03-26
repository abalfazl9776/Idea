using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using IdeaProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
    {   ValidationResult result = await _validator.ValidateAsync(ideaInputVm);
       if(!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
        }
        var ideaInputDto = _mapper.Map<IdeaInputDto>(ideaInputVm);
        ideaInputDto.UserId = 1;
        _ideaService.CreateIdea(ideaInputDto);
        return Ok();
    }


}