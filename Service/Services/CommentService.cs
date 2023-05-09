using AutoMapper;
using DataContract.Contracts;
using DataContract.Models.Comment;
using ServiceContract.Contracts;
using ServiceContract.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        
        public CommentService(ICommentRepository commentRepository,IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public void AddComment(AddCommentDto addComment)
        {
            var comment = _mapper.Map<AddComment>(addComment);
            _commentRepository.AddComment(comment);
        }

        public ICollection<GetCommentDto> ShowComments(int page, int pageSize,int ideaId)
        {
            List<GetComments> comments = _commentRepository.ShowComments(page,pageSize,ideaId).ToList();
            List<GetCommentDto> showCommends = _mapper.Map<List<GetCommentDto>>(comments);
            return showCommends;

        }

        public List<GetCommentDto> ShowCommentsFromSql(int page, int ideaId)
        {
            List<GetComments> comments = _commentRepository.ShowCommentsFromSql(page,ideaId);
            List<GetCommentDto> showComments = _mapper.Map<List<GetCommentDto>>(comments);
            return showComments;
        }
    }
}
