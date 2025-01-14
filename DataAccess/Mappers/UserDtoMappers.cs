using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.UserDto;
using Models;

namespace DataAccess.Mappers
{
    public static class UserDtoMappers
    {
        public static UserDto ToGetUserDto(this User user){
            return new UserDto {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                CreateAt = user.CreateAt,
                UpdatedAt = user.UpdatedAt
            };
        }
        
    }
}