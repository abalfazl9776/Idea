using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract.Models
{
    public class UpdateIdeaInputDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
    }
}
