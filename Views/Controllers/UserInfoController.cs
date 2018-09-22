using Domains;
using Models;
using System;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly IDomainUserCoreSkills domainUserCoreSkills;
        private readonly IDomainUserTeachSkills domainUserTeachSkills;
        private readonly IDomainUserInfo domainUserInfo;
        private readonly IDomainRole domainRole;

        public UserInfoController(IDomainUserCoreSkills domainUserCoreSkills, IDomainUserTeachSkills domainUserTeachSkills, IDomainUserInfo domainUserInfo, IDomainRole domainRole)
        {
            this.domainUserCoreSkills = domainUserCoreSkills ?? throw new ArgumentNullException(nameof(domainUserCoreSkills));
            this.domainUserTeachSkills = domainUserTeachSkills ?? throw new ArgumentNullException(nameof(domainUserTeachSkills));
            this.domainUserInfo = domainUserInfo ?? throw new ArgumentNullException(nameof(domainUserInfo));
            this.domainRole = domainRole ?? throw new ArgumentNullException(nameof(domainRole));
        }

        /// <summary>
        /// 用户信息视图
        /// </summary>
        /// <returns></returns>
        public ActionResult UserInfoView()
        {
            return View();
        }
        /// <summary>
        /// 查询核心技能信息
        /// </summary>
        /// <param name="userInfoID"></param>
        /// <returns></returns>
        public JsonResult FindCoreSkills()
        {
            var roleID = (Session["CurrentUser"] as ModelUser).RoleID;
            var result = domainUserCoreSkills.FindJobAndSkillAndLever(roleID);
            return Json(result);
        }
        /// <summary>
        /// 查询专业技能
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public JsonResult FindTeachSkills()
        {
            var roleID = (Session["CurrentUser"] as ModelUser).RoleID;
            var result= domainUserTeachSkills.FindJobAndSkillAndLever(roleID);
            return Json(result);
        }
        /// <summary>
        /// 查询用户的个人信息
        /// </summary>
        /// <returns></returns>
        public JsonResult FindUserInfo()
        {
            var userID = (Session["CurrentUser"] as ModelUser).UserID;
            var result = domainUserInfo.FindUserInfo(userID);
            return Json(result);
        }
        /// <summary>
        /// 查询用户的角色信息
        /// </summary>
        /// <returns></returns>
        public JsonResult FindRoleInfo()
        {
            var roleID = (Session["CurrentUser"] as ModelUser).RoleID;
            var result = domainRole.FindRole(roleID);
            return Json(result);
        }
        /// <summary>
        /// 插入用户信息
        /// </summary>
        /// <returns></returns>
        public JsonResult InsertUserInfo()
        {
           
            return Json(null);
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdateUserInfo( ModelUserInfo modelUserInfo)
        {
            var userID = (Session["CurrentUser"] as ModelUser).UserID;
            modelUserInfo.UserID = userID;
            var result = domainUserInfo.UpdateUserInfo(modelUserInfo);
            if (result)
            {
                return Json(new {message="ok" });
            }
            return Json(new { message = "error" });
        }
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <returns></returns>
        public JsonResult DeleteUserInfo()
        {

            return Json(null);
        }
        
    }
}