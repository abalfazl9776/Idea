using AutoMapper;
using FluentValidation;
using IdeaProject.ViewModels.Idea;
using IdeaProject.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using ServiceContract.Contracts;
using ServiceContract.Models.Idea;
using ServiceContract.Models.User;

namespace IdeaProject.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
        [HttpPost]
        public IActionResult SignUp(UserInfoInputVm userInfoInputVm)
        {
            var userInfo = _mapper.Map<UserInfoInputDto>(userInfoInputVm);
            _userService.AddUser(userInfo);
            return Ok();
        }
    }
}
    