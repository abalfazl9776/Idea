using AutoMapper;
using DataContract.Contracts;
using IdeaProject.ViewModels.Comment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContract.Contracts;
using ServiceContract.Models.Comment;

namespace IdeaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment (AddCommentVm addCommentVm)
        {
            var addCommentDto = _mapper.Map<AddCommentDto>(addCommentVm);
            _commentService.AddComment(addCommentDto);
            return Ok(addCommentDto);
        }

        [HttpGet]
        public ActionResult< List<GetCommentVm>> ShowComments()
        {
            List<GetCommentDto>comments = _commentService.ShowComments();
            List<GetCommentVm> showComments = _mapper.Map<List<GetCommentVm>>(comments);
            return Ok(showComments);
        }
    }
}
