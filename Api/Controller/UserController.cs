using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllServices.Services.UserContainer;
using DataAccess.Dtos.UserDto;
using DataAccess.Mappers;
using Microsoft.AspNetCore.Mvc;
using Models;

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
        public async Task<IActionResult> GetUsers(){
            var users = await _userService.GetAllUsers();
            var userDtos = users.Select(x => x.ToGetUserDto());
            return Ok(userDtos);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetUserById(int id){
            if(!ModelState.IsValid){
                return BadRequest();
            }

            var user = await _userService.GetUserById(id);
            if(user == null){
                return NotFound();
            }

            return Ok(user.ToGetUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDto userDto) {

            if(!ModelState.IsValid){
                return BadRequest();
            }

            var user = userDto.ToCreateUser();

            var newUser = await _userService.CreateUser(user);

            if(newUser == null){
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetUserById), new {id= newUser.Id}, newUser.ToGetUserDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(int id){
            var user = await _userService.DeleteUser(id);
            if(user == null){
                return NotFound();
            }
            return Ok(null);
        }
        
    }
}