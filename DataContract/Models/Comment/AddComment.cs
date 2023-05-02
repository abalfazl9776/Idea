using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContract.Models.Comment
{
    public class AddComment
    {
        public int Id { get; set; }
        public string CommentBody { get; set; }
        public int UserId { get; set; }
        public int IdeaId { get; set; }
        public int? ParentCommentId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
