using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentBody { get; set; }
        public virtual User User { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public int IdeaId { get; set; }
        public int? ParentCommentId { get; set; }
    }
}
