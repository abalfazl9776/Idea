using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract.Models.User
{
    public class UserInfoInputDto
    {
        public int UserId { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime DateTime { get; set; }
    }
}
