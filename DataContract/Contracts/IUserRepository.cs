using DataContract.Models.Idea;
using DataContract.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContract.Contracts
{
    public interface IUserRepository
    {
        void AddUser(AddUserDto addUserDto);
    }
}
