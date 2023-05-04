using DataContract.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContract.Models.Comment
{
    public class GetComments
    {
        public string UserName { get; set; }
        public int Id { get; set; }
        public string CommentBody { get; set; }
        public DateTime DateTime { get; set; }
    } 
}
