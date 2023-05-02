using AutoMapper;
using DataContract.Contracts;
using DataContract.Models.User;
using ServiceContract.Contracts;
using ServiceContract.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository , IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public void AddUser(UserInfoInputDto addUserDto)
        {
            var addUser = _mapper.Map<AddUserDto>(addUserDto);
            _userRepository.AddUser(addUser);
        }
    }
}
