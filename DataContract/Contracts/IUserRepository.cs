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
        void UpdateUser(AddUserDto updateUserDto);
        public IEnumerable<GetUserDto> ShowBySearch(string searchedWord);
        void DeleteUser(int id);
    }
}
