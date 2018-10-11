using Infrastructure.DtoExtension;
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
    public class SkillController : ApiController
    {
        private ISkillDomain skillDomain;

        public SkillController(ISkillDomain skillDomain)
        {
            this.skillDomain = skillDomain;
            this.skillDomain.InitDbContext(DbContextFactory.GetDbContext());
        }
        [HttpPost,HttpGet]
        public JsonResult<List<CoreSkillDto>> GetCoreSkill()
        {
           
            return Json(skillDomain.GetCore(null,null,"CoreLevers"));
        }
        [HttpPost, HttpGet]
        public JsonResult<List<TeachSkillDto>> GetTeachSkill()
        {
            return Json(skillDomain.GetTeach(null, null, "TeachLevers"));
        }

        public JsonResult<string> InsertCoreSkill(CoreSkill coreSkill)
        {
            skillDomain.Insert(coreSkill);
            skillDomain.Save();
            return Json("ok");
        }
        public JsonResult<string> InsertTeachSkill(TeachSkill teachSkill )
        {
            skillDomain.Insert(teachSkill);
            skillDomain.Save();
            return Json("ok");
        }

        public JsonResult<string> UpdateCoreSkill(CoreSkill coreSkill)
        {
            skillDomain.Update(coreSkill);
            skillDomain.Save();
            return Json("ok");
        }
        public JsonResult<string> UpdateTeachSkill(TeachSkill teachSkill)
        {
            skillDomain.Update(teachSkill);
            skillDomain.Save();
            return Json("ok");
        }

        public JsonResult<string> FakeDeleteCoreSkill(CoreSkill coreSkill)
        {
            skillDomain.FakeDeleteToCore(coreSkill.Guid);
            skillDomain.Save();
            return Json("ok");
        }
        public JsonResult<string> FakeDeleteTeachSkill(TeachSkill teachSkill)
        {
            skillDomain.FakeDeleteToTeach(teachSkill.Guid);
            skillDomain.Save();
            return Json("ok");
        }
        [HttpPost]
        public JsonResult<string> RealDeleteCoreSkill(CoreSkill coreSkill)
        {
            skillDomain.RealDeleteToCore(coreSkill.Guid);
            skillDomain.Save();
            return Json("ok");
        }
        [HttpPost]
        public JsonResult<string> RealDeleteTeachSkill(TeachSkill teachSkill)
        {
            skillDomain.RealDeleteToTeach(teachSkill.Guid);
            skillDomain.Save();
            return Json("ok");
        }
        //添加核心等级
        [HttpPost]
        public JsonResult<string> InsertCoreLeverToCore(CoreLever coreLever)
        {
            skillDomain.SetCoreLeverToCoreSkill(coreLever);
            skillDomain.Save();
            return Json("ok");
        }
        [HttpPost]
        public JsonResult<string> InsertTeachLeverToTeach(TeachLever  teachLever)
        {
            skillDomain.SetTeachLeverToTeachSkill(teachLever);
            skillDomain.Save();
            return Json("ok");
        }
        [HttpPost]
        public JsonResult<List<CoreLeverDto>> GetCoreLeverToCore(CoreSkill  coreSkill)
        {
            var result = skillDomain.GetCoreLeverByCoreSkillGuid(coreSkill.Guid);
            return Json(result);
        }
        [HttpPost]
        public JsonResult<List<TeachLeverDto>> GetTeachLeverToTeach(TeachSkill  teachSkill)
        {
            var result = skillDomain.GetTeachLeverByTeachSkillGuid(teachSkill.Guid);
            skillDomain.Save();
            return Json(result);
        }
        [HttpPost]
        public JsonResult<string> DeleteCoreLeverToCore(CoreLever  coreLever)
        {
            skillDomain.DeleteCoreLeverToCoreSkill(coreLever);
            skillDomain.Save();
            return Json("ok");
        }
        [HttpPost]
        public JsonResult<string> DeleteTeachLeverToTeach(TeachLever  teachLever)
        {
            skillDomain.DeleteTeachLeverToTeachsSkill(teachLever);
            skillDomain.Save();
            return Json("ok");
        }

    }
}
