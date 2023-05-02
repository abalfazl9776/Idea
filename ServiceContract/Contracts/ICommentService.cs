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
        List<GetCommentDto> ShowComments();
    }
}
