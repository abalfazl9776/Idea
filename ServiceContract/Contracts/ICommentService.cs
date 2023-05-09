using ServiceContract.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract.Contracts
{
    public interface ICommentService
    {
        void AddComment(AddCommentDto addComment);
        ICollection<GetCommentDto> ShowComments(int page, int pageSize,int ideaId);
        List<GetCommentDto> ShowCommentsFromSql(int page, int ideaId);
    }
}
