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

    public IdeaController(IIdeaService ideaService)
    {
        _ideaService = ideaService;
    }

    [HttpPost]
    public IActionResult CreateIdea(IdeaInputVm ideaInputVm)
    {
        _ideaService.CreateIdea(new IdeaInputDto()
        {
            Idea = ideaInputVm.Idea,
            Title = ideaInputVm.Title,
            UserId = 1 // TODO : get user id
        });
        return Ok();
    }
}