using AutoMapper;
using IdeaProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceContract.Contracts;
using ServiceContract.Models;

namespace IdeaProject.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class IdeaController : ControllerBase
{
    private readonly IIdeaService _ideaService;
    private readonly IMapper _mapper;

    public IdeaController(IIdeaService ideaService, IMapper mapper)
    {
        _ideaService = ideaService;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateIdea(IdeaInputVm ideaInputVm)
    {
        var ideaInputDto = _mapper.Map<IdeaInputDto>(ideaInputVm);
        ideaInputDto.UserId = 1;
        _ideaService.CreateIdea(ideaInputDto);
        return Ok();
    }
}