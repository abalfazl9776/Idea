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
        void UpdateUser(UpdateUserInfoDto updateUserDto);
        public IEnumerable<GetUserInfoDto> ShowBySearch(string searchedWord);
        void DeleteUser(int id);
    }
}
