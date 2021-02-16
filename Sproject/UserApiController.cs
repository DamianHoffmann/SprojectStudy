using Application;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sproject
{
    [Route("v1/users")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly UserController _userController;

        public UserApiController(UserController userController)
        {
            _userController = userController;
        }

      
        [HttpGet("login")]
        public async Task<User> Login(string username, string password)
        {
            
           var user = await _userController.CheckLogIn(username, password);

            return user;

        }
        
        [HttpPost("create")]
        public async Task<User> CreateUser(string username, string password)
        {

          var user =  await _userController.AddUserAsync(username, password);

            return user;

        }
    }
}
