using Domain;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public class UserController
    {
        public IUserRepository _userRepository;
    
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            
        }

        public  async Task<User> CheckLogIn(string name, string password)
        {
            var user = new User()
            {
                Name = name,
                Password = password
            };
            var result = await _userRepository.GetUserAsync(user);
            if(result.Password != user.Password)
            {
                throw new UnauthorizedAccessException();
            }
           
            return result ;
        }
       public async Task<User> AddUserAsync(string name, string password) {
            var user = new User()
            {
                Name = name,
                Password = password
            };
            var result = await _userRepository.AddUserAsync(user);
            return result;
        }
    }
}
