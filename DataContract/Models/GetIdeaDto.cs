using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContract.Models
{
    public class GetIdeaDto
    {
        public string MainIdea { get; set; }

        public string Title { get; set; }

        public int UserId { get; set; }
    }
}
