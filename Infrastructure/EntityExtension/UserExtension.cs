using Infrastructure.Dto;
using Repositorys.DataAccess.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityExtension
{
    public static class UserExtension
    {
        public static UserDto ToDto(this User user)
        {
            var userDto = new UserDto();
            userDto.Guid = user.Guid;
            userDto.UserName = user.UserName;
            userDto.ReigstTime = user.ReigstTime;
            userDto.VisitCount = user.VisitCount;
            if (user.UserInfo != null)
            {
                userDto.UserInfoDtos =  user.UserInfo.ToDto();
            }
            return userDto;
        }
        
         public static User ToUpdateEntity(this User user,User detachedUser)
        {
            var userDto = new User();
            userDto.Guid = user.Guid;
            userDto.UserName = user.UserName;
            userDto.ReigstTime = user.ReigstTime;
            userDto.VisitCount = user.VisitCount;
            return userDto;
        }

        public static User ToInsertEntity(this User user)
        {
            user.Guid = Guid.NewGuid();
            user.IsActivate = 0;
            user.LoginTime = DateTime.Now;
            user.ReigstTime = DateTime.Now;
            user.State = 0;
            user.VisitCount = 0;
            user.UserInfo = new UserInfo() {
                Guid = Guid.NewGuid()
            };
            return user;
        }
    }
}
