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
    [UserFilter(IsCheck = false)]
    public class LoginController : Controller
    {
        
        private iUserDomain iUserDomain { get; set; }
        public LoginController(iUserDomain _iuserDomain)
        {
            this.iUserDomain = _iuserDomain;
        }
        /// <summary>
        ///转到登陆视图
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginView()
        {
            return View();
        }
        /// <summary>
        /// 登陆信息处理
        /// </summary>
        /// <returns></returns>
        public JsonResult LoginCheck(string UserName, string Password)
        {
            UserModel userModel = new UserModel()
            {
                UserName = UserName,
                UserPassword = Password,
            };
            //封装成对象，调用domain查询User表

            UserModel checkResult = iUserDomain.LoginCheck(userModel);
            if (checkResult != null)
            {
                if (checkResult.UserPassword != "失败")
                {
                    Session["CurrentUser"] =  checkResult;
                    checkResult.UserName = "一秒后跳转到主页！";
                    checkResult.UserPassword =  "成功";
                    return Json(checkResult);
                }
                else
                {
                    checkResult.UserPassword = "失败";
                    return Json(checkResult);
                }
            }
            else
            {
                checkResult = new UserModel();
                checkResult.UserName = "用户不存在或信息有误！！";
                checkResult.UserPassword = "失败";
                return Json(checkResult);
            }

        }
        /// <summary>z
        ///将信息写入cookeis，实现自动登陆
        /// </summary>
        /// <returns></returns>
        //public ActionResult LoginView()
        //{
        //    return View();
        //}
    }
}