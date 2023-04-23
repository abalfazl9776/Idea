using AutoMapper;
using DataAccess.Entities;
using DataContract.Contracts;
using DataContract.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public void AddUser(AddUserDto addUserDto)
        {
            var User = _mapper.Map<User>(addUserDto);
            _applicationDbContext.User.Add(User);
            _applicationDbContext.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetUserDto> ShowBySearch(string searchedWord)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(AddUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
