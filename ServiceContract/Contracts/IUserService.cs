using ServiceContract.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract.Contracts
{
    public  interface IUserService
    {
        void AddUser(UserInfoInputDto addUserDto);
    }
}
