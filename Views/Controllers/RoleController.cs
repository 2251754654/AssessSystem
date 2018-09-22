using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domains;
using Models;

namespace Views.Controllers
{
    public class RoleController : AbstractAdminController
    {
        public RoleController(IDomainRole _domainRole) : base(_domainRole)
        {
        }

        /// <summary>
        /// 角色管理视图
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleView()
        {
            return View();
        }
        /// <summary>
        /// AJAX查询角色信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public JsonResult FindAllRole(int page)
        {
            return Json(domainRole.FindAllRole(),JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// AJAX根据roleID查询某个role
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public JsonResult FindRole(int roleID)
        {
            return Json(domainRole.FindRole(roleID));
        }
        /// <summary>
        /// AJAX根据roleID删除某个role或者某些
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public JsonResult DeleteRole(int RoleID)
        {
            var result = domainRole.DeleteRole(RoleID);
            return Json(result);
        }
        /// <summary>
        /// 根据roleeID更新roleID，要求更新的数据全部上传
        /// </summary>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        public JsonResult UpdateRole(ModelRole modelRole)
        {
            var result = domainRole.UpdateRole(modelRole);
            return Json(result);
        }
        /// <summary>
        /// 根据上传的数据添加Role
        /// </summary>
        /// <param name="modelRol"></param>
        /// <returns></returns>
        public JsonResult InsertRole(ModelRole modelRol)
        {
            var result = domainRole.InsertRole(modelRol);
            return Json(result);
        }

        /// <summary>
        /// 添加角色对应的职业
        /// </summary>
        /// <param name="RoleID"></param>
        /// <param name="ProfessionalID"></param>
        /// <returns></returns>
        public JsonResult InsertRoleProfessional(int RoleID,int ProfessionalID)
        {
            var result = domainRole.InsertRoleProfessional(RoleID, ProfessionalID);
            return Json(result);
        }
    }
}