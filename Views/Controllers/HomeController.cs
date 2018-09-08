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
    public class HomeController : Controller
    {

        //个人信息
        public ActionResult GetUserInfo(string userID)
        {
            return View();
        }
        //自我测评
        public ActionResult GetOneselfEvaluation(string userInfoID)
        {
            OneselfEvaluationDomain oneselfEvaluationDomain = new OneselfEvaluationDomain();
            ViewBag.OneselfEvaluation = oneselfEvaluationDomain.GetOneselfEvaluation(Convert.ToInt32(userInfoID));
            return View();
        }
        //他人测评
        public ActionResult GetOtherEvaluation(string userInfoID)
        {
            OtherEvaluationDomain otherEvaluationDomain = new OtherEvaluationDomain();
            ViewBag.OtherEvaluation = otherEvaluationDomain.GetOtherEvaluation(Convert.ToInt32(userInfoID));
            return View();
        }
        //管理员视图
        public ActionResult GetAdministratorPage()
        {
            return View();
        }
        //退出系统
        public ActionResult LogOut()
        {
            if (Session["CurrentUser"] != null)
            {
                Session.Remove("CurrentUser");
            }
            return View();
        }
        //校验
        public ActionResult HomePage()
        {
            return View();
        }
        //一个请求数据
        public ActionResult GetEvaluation()
        {
            //将谁评价了谁显示在主页
            EvaluationDomain evaluationDomain = new EvaluationDomain();
            ViewBag.AllEvaluation = evaluationDomain.GetAllEvaluation();
            return View("HomePage");
        }
        //一个AJAX请求数据
        public JsonResult GetAJAXEvaluation()
        {
            //将谁评价了谁显示在主页
            EvaluationDomain evaluationDomain = new EvaluationDomain();
            return Json(evaluationDomain.GetAllEvaluation());
        }


        public JsonResult SSSSGetAJAXEvaluation()
        {
            //将谁评价了谁显示在主页
            EvaluationDomain evaluationDomain = new EvaluationDomain();
            return Json(evaluationDomain.GetAllEvaluation());
        }
    }
}