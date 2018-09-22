using Domains;
using System;
using System.Threading;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDomainOneselfAssess domainOneselfAssess;
        private readonly IDomainOtherAssess domainOtherAssess;

        public HomeController(IDomainOneselfAssess domainOneselfAssess, IDomainOtherAssess domainOtherAssess)
        {
            this.domainOneselfAssess = domainOneselfAssess ?? throw new ArgumentNullException(nameof(domainOneselfAssess));
            this.domainOtherAssess = domainOtherAssess ?? throw new ArgumentNullException(nameof(domainOtherAssess));
        }

        /// <summary>
        /// 转到主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 转到个人信息页面
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public ActionResult UserInfo()
        {
            return RedirectToAction("UserInfoView","UserInfo");
        }
        /// <summary>
        /// 转到自我评价页面
        /// </summary>
        /// <returns></returns>
        public ActionResult OneSelfAssess()
        {
            return RedirectToAction("OneSelfAssessView", "OneSelfAssess");
        }
        /// <summary>
        /// 转到他人评价页面
        /// </summary>
        /// <returns></returns>
        public ActionResult OtherAssess()
        {
            return RedirectToAction("OtherAssessView", "OtherAssess");
        }
        /// <summary>
        /// 转到角色管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Role()
        {
            return RedirectToAction("RoleView", "Role");
        }
        /// <summary>
        /// 转到职业管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Job()
        {
            return RedirectToAction("JobView", "Job");
        }
        /// <summary>
        /// 转到技能管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Skill()
        {
            return RedirectToAction("SkillView", "Skill");
        }
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            if (Session["CurrentUser"] != null)
            {
                Session.Remove("CurrentUser");
            }
            return View();
        }
        /// <summary>
        /// 主页显示的数据
        /// </summary>
        /// <returns></returns>
        public JsonResult FindAllAssess()
        { 
            try
            {
                Thread.Sleep(200);
                var result = domainOtherAssess.FindAllAssess();
                var resultCount = result.Count;
                return Json(new { Result = "OK", Records = result, TotalRecordCount = resultCount });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}