using AutoMapper;
using DataAccess.Entities;
using DataContract.Contracts;
using DataContract.Models.Comment;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DataAccess.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public CommentRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public void AddComment(AddComment addComment)
        {
            var comment = _mapper.Map<Comment>(addComment);
            _applicationDbContext.Add(comment);
            _applicationDbContext.SaveChanges();
        }

        public ICollection<GetComments> ShowComments(int page, int pageSize,int ideaId)
        {
            if (page <= 1)
            {
                page = 0;
            }
            int totalNumber = page * pageSize;
            List<Comment> comments = _applicationDbContext.Comment.Include(a => a.User).OrderBy(x => x.DateTime).Where(x=>x.IdeaId==ideaId).Skip(totalNumber).Take(pageSize).ToList();
            List<GetComments> showComments = _mapper.Map<List<GetComments>>(comments);
            return showComments;
        }

        public List<GetComments> ShowCommentsFromSql(int page, int ideaId)
        {
            List<CommentsOnIdeas> query = _applicationDbContext.CommentsOnIdeas.FromSqlRaw($"Show_Comments_sp @page={page}, @ideaId={ideaId}").ToList();
            List<GetComments> showComments = _mapper.Map<List<GetComments>>(query);
            return showComments;
        }
    }
}
