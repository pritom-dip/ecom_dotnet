using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllServices.Services.UserContainer;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [ApiController]
    [Route("/api/user")]
    public class UserController : ControllerBase
    {   

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get(){
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
        
    }
}