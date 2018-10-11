using Infrastructure.Dto;
using Infrastructure.Exception;
using Repositorys.DataAccess.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using UserInfoDomain.UserTerritory;
using WebApiUI.Models.DbContext;

namespace WebApiUI.Controllers
{
    
    public class UserController : ApiController
    {
        private readonly IUserDomain userDomain;
        
        public UserController(IUserDomain userDomain)
        {
            this.userDomain = userDomain;
            userDomain.InitDbContext(DbContextFactory.GetDbContext());
        }
        [HttpPost]
        public JsonResult<string> Insert(User user)
        {
            userDomain.Insert(user);
            return Json("ok");
        }
        [HttpPost]
        public JsonResult<string> Update(User user)
        {
            userDomain.Update(user);
            return Json("ok");
        }
        [HttpPost]
        public JsonResult<string> FakeDelete(User user)
        {
            userDomain.FakeDelete(user.Guid);
            return Json("ok");
        }
        [HttpPost]
        public JsonResult<string> RealDelete(User user)
        {
            userDomain.RealDelete(user.Guid);
            return Json("ok");
        }
        [HttpPost,HttpGet]
        public JsonResult<UserDto> GetUser()
        {
            var authentication = HttpContext.Current.GetOwinContext().Authentication;
            var ticket = authentication.AuthenticateAsync("Bearer").Result;
            string Guid;

            if (ticket != null)
            {
                if (ticket.Properties.Dictionary.TryGetValue("Guid", out Guid))
                {
                    var result = userDomain.GetByID(System.Guid.Parse(Guid));
                    if (result != null)
                    {
                        return Json(result);
                    }
                   
                }
            }
            return Json(new UserDto());
        }
    }
}
