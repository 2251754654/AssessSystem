using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Views.Models;

namespace Views.Controllers
{
    public class GetUserInfoController : Controller
    {
        // GET: GetUserInfo
        public ActionResult Index()
        {
            return View();
        }
        //查询核心技能信息
        public ActionResult GetCoreSkills(string userInfoID)
        {
            //查询到角色对应名称和对应的职位和对应的技能
            CoreAkillsDomain coreAkillsDomain = new CoreAkillsDomain();
            ViewBag.GetAllCoreSkills =  coreAkillsDomain.GetCoreSkillsByUserInfoID(Convert.ToInt32(userInfoID));
            return View();
        }
        //查询专业技能
        public ActionResult GetTeachSkills(string userInfoID)
        {
            TeachAkillsDomain teachAkillsDomain = new TeachAkillsDomain();
            ViewBag.GetAllTeachSkills = teachAkillsDomain.GetTeachSkillsByUserInfoID(Convert.ToInt32( userInfoID));
            return View();
        }
    }
}