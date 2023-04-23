using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract.Models.User
{
    public class GetUserInfoDto
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string UserName { get; set; }
    }
}
