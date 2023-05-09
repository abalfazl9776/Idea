using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class CommentsOnIdeas
    {
        public string UserName { get; set; }
        public int Id { get; set; }
        public string CommentBody { get; set; }
        public DateTime DateTime { get; set; }
        public int IdeaId { get; set; }
    }
}
