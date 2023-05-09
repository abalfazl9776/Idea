using AutoMapper;
using DataContract.Contracts;
using IdeaProject.ViewModels.Comment;
using IdeaProject.ViewModels.Pagination;
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

        [HttpGet("ideaId : int")]
        public ActionResult< ICollection<GetCommentVm>> ShowComments(int ideaId,int page = 1)
        {
            List<GetCommentDto>comments = _commentService.ShowComments(page,2,ideaId).ToList();
            List<GetCommentVm> showComments = _mapper.Map<List<GetCommentVm>>(comments);
            return Ok(showComments);
        }

        [HttpGet("FromSql")]
        public List<GetCommentVm> ShowCommentsFromSql(int page, int ideaId)
        {
            List<GetCommentDto> comments = _commentService.ShowCommentsFromSql(page, ideaId);
            List<GetCommentVm> showComments = _mapper.Map<List<GetCommentVm>>(comments);
            return showComments;
        }
    }
}
