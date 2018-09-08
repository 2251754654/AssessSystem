
using Domains;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Views.Models;

namespace Views.Controllers
{
    public class UserInfoController : Controller
    {
        //个人信息
        public JsonResult GetUserInfoByAJAX()
        {
            //显示用户的个人信息
            int userID = (Session["CurrentUser"] as UserModel).UserID;
            return Json(new UserInfoDomain().GetUserInfoModelsByID(userID));
        }

        //个人信息
        public JsonResult GetCoreSkillsByAJAX()
        {
            //显示用户的核心技能
            return Json(new UserCoreSkillsDomain().GetCoreSkillsByUserID((Session["CurrentUser"] as UserModel).UserID));
        }
        //个人信息
        public JsonResult GetTeachSkillsByAJAX()
        {
            //显示用户的专业技能
            return Json(new UserTeachSkillsDomain().GetTeachSkillsByUserID((Session["CurrentUser"] as UserModel).UserID));
        }
        //个人信息
        public JsonResult GetRolesByAJAX()
        {
            //显示用户的角色信息
            return Json(new UserRoleDomain().GetRoleByUserID(Convert.ToInt32((Session["CurrentUser"] as UserModel).UserID)));
        }
    }
}