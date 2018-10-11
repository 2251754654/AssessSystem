using Infrastructure.DtoExtension;
using Repositorys.DataAccess.MappingModule;
using Repositorys.DataAccess.ProfessModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using UserInfoDomain.ProfessTerritory;
using WebApiUI.Models.DbContext;

namespace WebApiUI.Controllers
{
    public class ProfessController : ApiController
    {
        private IProfessDomain professDomain;
        private ISkillDomain skillDomain;

        public ProfessController(IProfessDomain _professDomain, ISkillDomain skillDomain)
        {
            this.professDomain = _professDomain;
            this.skillDomain = skillDomain;
            professDomain.InitDbContext(DbContextFactory.GetDbContext());
            skillDomain.InitDbContext(DbContextFactory.GetDbContext());
        }

        public List<ProfessDto> Get()
        {
            return professDomain.Get();
        }
        public JsonResult<string> Insert(Profess profess)
        {
            professDomain.Insert(profess);
            professDomain.Save();
            return Json("ok");
        }
        public JsonResult<string> Update(Profess profess)
        {
            professDomain.Update(profess);
            professDomain.Save();
            return Json("ok");
        }
        [HttpPost]
        public JsonResult<string> Delete(Profess profess)
        {
            professDomain.RealDelete(profess.Guid);
            professDomain.Save();
            return Json("ok");
        }
        //分配的职业
        [HttpPost, HttpGet]
        public JsonResult<List<CoreSkillDto>> GetCoreSkillByProfessGuid(Profess profess)
        {
            return Json(professDomain.GetCoreSkillByProfessGuid(profess.Guid));
        }
        [HttpPost, HttpGet]
        public JsonResult<List<TeachSkillDto>> GetTeachSkillByProfessGuid(Profess profess)
        {
            return Json(professDomain.GetTeachSkillByProfessGuid(profess.Guid));
        }
        //没有分配的职业
        [HttpPost,HttpGet]
        public JsonResult<List<CoreSkillDto>> GetNotCoreSkillByProfessGuid(Profess profess)
        {
            var coreSkillList = professDomain.GetCoreSkillByProfessGuid(profess.Guid);
            var allCoreSkill = skillDomain.GetCore();

            var notProfessList = allCoreSkill.Except(coreSkillList, new CoreEquality());
            return Json(notProfessList.ToList());
        }
        private class CoreEquality : IEqualityComparer<CoreSkillDto>
        {
            public bool Equals(CoreSkillDto x, CoreSkillDto y)
            {
                return x.Guid == y.Guid;
            }

            public int GetHashCode(CoreSkillDto obj)
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
        [HttpPost, HttpGet]
        public JsonResult<List<TeachSkillDto>> GetNotTeachSkillByProfessGuid(Profess profess)
        {
            var teachSkillList = professDomain.GetTeachSkillByProfessGuid(profess.Guid);
            var allTeachSkill = skillDomain.GetTeach();

            var notProfessList = allTeachSkill.Except(teachSkillList, new TeachEquality());
            return Json(notProfessList.ToList());
        }
        private class TeachEquality : IEqualityComparer<TeachSkillDto>
        {
            public bool Equals(TeachSkillDto x, TeachSkillDto y)
            {
                return x.Guid == y.Guid;
            }

            public int GetHashCode(TeachSkillDto obj)
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
        //删除分配的
        [HttpPost]
        public JsonResult<string> DeleteCoreSkillToProfess(Profess_CoreSkill profess_CoreSkill)
        {
            professDomain.DeleteCoreSkillToProfess(profess_CoreSkill.ProfessGuid, profess_CoreSkill.CoreSkillGuid);
            professDomain.Save();
            return Json("ok");
        }
        [HttpPost]
        public JsonResult<string> DeleteTeachSkillToProfess(Profess_TeachSkill profess_TeachSkill)
        {
            professDomain.DeleteTeachSkillToProfess(profess_TeachSkill.ProfessGuid, profess_TeachSkill.TeachSkillGuid);
            professDomain.Save();
            return Json("ok");
        }
        //分配
        [HttpPost]
        public JsonResult<string> AddCoreSkillToProfess(Profess_CoreSkill profess_CoreSkill)
        {
            professDomain.SetCoreSkillToProfessGuid(profess_CoreSkill.ProfessGuid,profess_CoreSkill.CoreSkillGuid);
            professDomain.Save();
            return Json("ok");
        }
        [HttpPost]
        public JsonResult<string> AddTeachSkillToProfess(Profess_TeachSkill  profess_TeachSkill)
        {
            professDomain.SetTeachSkillToProfessGuid(profess_TeachSkill.ProfessGuid, profess_TeachSkill.TeachSkillGuid);
            professDomain.Save();
            return Json("ok");
        }
    }
}
