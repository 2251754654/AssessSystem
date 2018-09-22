using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domains;
using UserInfoDomain;

using Models;
namespace Views.Controllers
{
    public class JobController : Controller
    {
        private readonly IDomainJob domainJob;

        public JobController(IDomainJob _domainJob)
        {
            this.domainJob = _domainJob ?? throw new ArgumentNullException(nameof(domainJob));
        }
        /// <summary>
        /// 职业管理视图
        /// </summary>
        /// <returns></returns>
        public ActionResult JobView()
        {
            return View();
        }
        /// <summary>
        /// 更新职业
        /// </summary>
        /// <param name="modelProfessional"></param>
        /// <returns></returns>
        public JsonResult UpdateJob(ModelProfessional modelProfessional)
        {
            var result = domainJob.UpdateJob(modelProfessional);
            return Json(result);
        }
        //插入某个职位
        public JsonResult InsertJob(ModelProfessional modelProfessional)
        {
            var result = domainJob.InsertJob(modelProfessional);
            return Json(result);
        }
        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="jobID"></param>
        /// <returns></returns>
        public JsonResult DeleteJob(int ProfessionalID)
        {
            var result = domainJob.DeleteJob(ProfessionalID);
            return Json(result);
        }
        /// <summary>
        /// 查询某个职位
        /// </summary>
        /// <param name="ProfessionalID"></param>
        /// <returns></returns>
        public JsonResult FindJob(int ProfessionalID)
        {
            var result = domainJob.FindJob(ProfessionalID);
            return Json(result);
        }
        /// <summary>
        /// 查询所有职位
        /// </summary>
        /// <returns></returns>
        public JsonResult FindAllJob()
        {
            var result = domainJob.FindAllJob();
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 分配核心技能
        /// </summary>
        /// <param name="ProfessionalID"></param>
        /// <param name="CoreSkillsID"></param>
        /// <returns></returns>
        public JsonResult InsertProfessionalCoreSkills(int ProfessionalID,int CoreSkillsID)
        {
            var result = domainJob.InsertProfessionalCoreSkills(ProfessionalID, CoreSkillsID);
            return Json(result);
        }
        /// <summary>
        /// 分配专业技能
        /// </summary>
        /// <param name="ProfessionalID"></param>
        /// <param name="TeachSkillsID"></param>
        /// <returns></returns>
        public JsonResult InsertProfessionalTeachSkills(int ProfessionalID, int TeachSkillsID)
        {
            var result = domainJob.InsertProfessionalTeachSkills(ProfessionalID, TeachSkillsID);
            return Json(result);
        }
        /// <summary>
        /// 查询已分配
        /// </summary>
        /// <param name="RoleID"></param>
        /// <returns></returns>
        public JsonResult AllotedProfessional(int RoleID)
        {
            var result = domainJob.AllotedProfessional(RoleID);
            return Json(result);
        }
    }
}