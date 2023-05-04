using DataContract.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContract.Contracts
{
    public interface ICommentRepository
    {
        void AddComment(AddComment addComment);
        ICollection<GetComments> ShowComments(int page, int pageSize);
    }
}
