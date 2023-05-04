using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract.Models.Comment
{
    public class GetCommentDto
    {
        public string UserName { get; set; }
        public int Id { get; set; }
        public string CommentBody { get; set; }
        public DateTime DateTime { get; set; }
    }
}
