using Infrastructure.DtoExtension;
using Infrastructure.EntityExtension;
using Repositorys.DataAccess.UserModule;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using UserInfoDomain.ProfessTerritory;
using UserInfoDomain.UserTerritory;
using WebApiUI.Models.DbContext;

namespace WebApiUI.Controllers
{
    //[EnableCors("*","*","*")]
    public class RoleController : ApiController
    {
        private IRoleDomain roleDomain;
        private IProfessDomain professDomain;

        public RoleController(IRoleDomain roleDomain, IProfessDomain professDomain)
        {
            this.roleDomain = roleDomain;
            this.professDomain = professDomain;
            roleDomain.InitDbContext(DbContextFactory.GetDbContext());
            professDomain.InitDbContext(DbContextFactory.GetDbContext());
        }
        [HttpPost, HttpGet]
        public JsonResult<List<RoleDto>> Get(int page, int number, string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                search = "";
            }
            var roleList = roleDomain.Get(o=>o.RoleName.Contains(search), q => q.OrderBy(c => c.RoleName), null,page,number);
            return Json(roleList);
        }
        [HttpPost]
        public JsonResult<string[]> GetMenu()
        {
            return Json(new string[] {"0" });
        }
        [HttpPost]
        public JsonResult<string> Insert(Role role)
        {
            roleDomain.Insert(role);
            roleDomain.Save();
            return Json("ok");
        }

        public JsonResult<string> Update(Role role)
        {
            roleDomain.Update(role);
            roleDomain.Save();
            return Json("ok");
        }
        [HttpPost]
        public JsonResult<string> Delete(Role role)
        {
            roleDomain.RealDelete(role.Guid);
            roleDomain.Save();
            return Json("ok");
        }
        [HttpPost,HttpGet]
        public JsonResult<List<ProfessDto>> GetProfessByRoleGuid(Role role)
        {

           var professList =  roleDomain.GetProfessByRoleGuid(role.Guid);
            return Json(professList);
        }
        [HttpPost, HttpGet]
        public JsonResult<List<ProfessDto>> GetNotProfessByRoleGuid(Role role)
        {

            var professList = roleDomain.GetProfessByRoleGuid(role.Guid);
            var allProfessList = professDomain.Get();

            var notProfessList = allProfessList.Except(professList,new Equality());
            return Json(notProfessList.ToList());
        }

        public class Equality : IEqualityComparer<ProfessDto>
        {
            public bool Equals(ProfessDto x, ProfessDto y)
            {
                return x.Guid == y.Guid;
            }

            public int GetHashCode(ProfessDto obj)
            {
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return obj.ToString().GetHashCode();
                }
            }
        }

        public JsonResult<string> DeleteProfessToRole(string roleGuid,string professGuid)
        {

            roleDomain.DeleteProfessToRole(Guid.Parse(roleGuid),Guid.Parse(professGuid));
            return Json("ok");
        }
        [HttpPost, HttpGet]
        public JsonResult<string> SetProfessToRole(string roleGuid, string professGuid)
        {
            roleDomain.SetProfessToRole(Guid.Parse(roleGuid), Guid.Parse(professGuid));
            return Json("ok");
        }

    }
}
