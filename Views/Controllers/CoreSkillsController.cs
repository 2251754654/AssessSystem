using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domains;
using Models;
namespace Views.Controllers
{
    public class CoreSkillsController : Controller
    {
        private readonly IDomainCoreSkills domainCoreSkills;

        public CoreSkillsController(IDomainCoreSkills domainCoreSkills)
        {
            this.domainCoreSkills = domainCoreSkills ?? throw new ArgumentNullException(nameof(domainCoreSkills));
        }

        /// <summary>
        /// 技能视图
        /// </summary>
        /// <returns></returns>
        public ActionResult CoreSkillsView()
        {
            return View();
        }
        /// <summary>
        /// 查询核心技能
        /// </summary>
        /// <returns></returns>
        public JsonResult FindAllCoreSkills()
        {
            var result = domainCoreSkills.FindAllCoreSkills();
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 更新核心技能
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdateCoreSkills(ModelCoreSkills modelCoreSkills)
        {
            var result = domainCoreSkills.UpdateCoreSkills(modelCoreSkills);
            return Json(result);
        }
        /// <summary>
        /// 删除核心技能
        /// </summary>
        /// <returns></returns>
        public JsonResult DeleteCoreSkills(int CoreSkillsID)
        {
            var result = domainCoreSkills.DeleteCoreSkills(CoreSkillsID);
            return Json(result);
        }
        /// <summary>
        /// 插入核心技能
        /// </summary>
        /// <returns></returns>
        public JsonResult InsertCoreSkills(ModelCoreSkills modelCoreSkills)
        {
            var result = domainCoreSkills.InsertCoreSkills(modelCoreSkills);
            return Json(result);
        }
        /// <summary>
        /// 查询所有等级
        /// </summary>
        /// <returns></returns>
        public JsonResult FindAllLever(int CoreSkillsID)
        {
            var result = domainCoreSkills.FindAllLever(CoreSkillsID);
            return Json(result);
        }
        /// <summary>
        /// 删除等级
        /// </summary>
        /// <param name="CoreSkillsID"></param>
        /// <param name="CoreLeverID"></param>
        /// <returns></returns>
        public JsonResult DeleteLever(int CoreSkillsID,int CoreLeverID)
        {
            var result = domainCoreSkills.DeleteLever(CoreSkillsID,CoreLeverID);
            return Json(result);
        }
        /// <summary>
        /// 插入等级
        /// </summary>
        /// <returns></returns>
        public JsonResult InsertLever(ModelCoreLever modelCoreLever)
        {
            var result = domainCoreSkills.InsertLever(modelCoreLever);
            return Json(result);
        }
        /// <summary>
        /// 分配的核心技能
        /// </summary>
        /// <returns></returns>
        public JsonResult AllotCoreSkills(int ProfessionalID)
        {
            var result = domainCoreSkills.AllotCoreSkills(ProfessionalID);
            return Json(result);
        }
    }
}