using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domains;
using Models;

namespace Views.Controllers
{
    public class TeachSkillsController : Controller
    {
        private readonly IDomainTeachSkills domainTeachSkills;

        public TeachSkillsController(IDomainTeachSkills domainTeachSkills)
        {
            this.domainTeachSkills = domainTeachSkills ?? throw new ArgumentNullException(nameof(domainTeachSkills));
        }

        // GET: TeachSkills
        public ActionResult TeachSkillsView()
        {
            return View();
        }

        /// <summary>
        /// 查询专业技能
        /// </summary>
        /// <returns></returns>
        public JsonResult FindAllTeachSkills()
        {
            var result = domainTeachSkills.FindAllTeachSkills();
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 更专业心技能
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdateTeachSkills(ModelTechSkills modelTechSkills)
        {
            var result = domainTeachSkills.UpdateTeackSkills(modelTechSkills);
            return Json(result);
        }
        /// <summary>
        /// 删除专业技能
        /// </summary>
        /// <returns></returns>
        public JsonResult DeleteTeachSkills(int TeachSkillsID)
        {
            var result = domainTeachSkills.DeleteTeachSkills(TeachSkillsID);
            return Json(result);
        }
        /// <summary>
        /// 插入专业技能
        /// </summary>
        /// <returns></returns>
        public JsonResult InsertTeachSkills(ModelTechSkills modelTechSkills)
        {
            var result = domainTeachSkills.InsertTeachSkills(modelTechSkills);
            return Json(null);
        }
        /// <summary>
        /// 查询所有等级
        /// </summary>
        /// <returns></returns>
        public JsonResult FindAllLever(int TeachSkillsID)
        {
            var result = domainTeachSkills.FindAllLever(TeachSkillsID);
            return Json(result);
        }
        /// <summary>
        /// 删除等级
        /// </summary>
        /// <param name="CoreSkillsID"></param>
        /// <param name="CoreLeverID"></param>
        /// <returns></returns>
        public JsonResult DeleteLever(int TeachSkillsID, int TeachLeverID)
        {
            var result = domainTeachSkills.DeleteLever(TeachSkillsID, TeachLeverID);
            return Json(result);
        }
        /// <summary>
        /// 插入等级
        /// </summary>
        /// <returns></returns>
        public JsonResult InsertLever(ModelTeachLever  modelTeachLever)
        {
            var result = domainTeachSkills.InsertLever(modelTeachLever);
            return Json(result);
        }
        /// <summary>
        /// 分配的专业技能
        /// </summary>
        /// <param name="ProfessionalID"></param>
        /// <returns></returns>
        public JsonResult AllotTeachSkills(int ProfessionalID)
        {
            var result = domainTeachSkills.AllotTeachSkills(ProfessionalID);
            return Json(result);
        }
    }
}