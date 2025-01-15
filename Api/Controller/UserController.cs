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
        public IActionResult GetUsers(){
            var users =  _userService.GetAllUsers();
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

            var newUser = await _userService.CreateUser(userDto);

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

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto userDto){
            if(!ModelState.IsValid){
                return BadRequest();
            }

            var updatedUser = await _userService.UpdateUser(userDto, id);

            if(updatedUser == null){
                return NotFound();
            }

            return Ok(updatedUser.ToGetUserDto());
        }
        
    }
}