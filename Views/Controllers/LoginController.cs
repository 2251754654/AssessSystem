using Domains;
using Models;
using System;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class LoginController : Controller
    {

        private readonly IDomainLogin domainLogin;

        public LoginController(IDomainLogin _domainLogin)
        {
            this.domainLogin = _domainLogin ?? throw new ArgumentNullException(nameof(domainLogin));
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
        public JsonResult Login(string UserName, string Password)
        {
            ModelUser  modelUser = new ModelUser()
            {
                UserName = UserName,
                UserPassword = Password,
            };
            //封装成对象，调用domain查询User表
            var result = domainLogin.Login(modelUser);
            if (result != null)
            {
                if (result.UserPassword != "0")
                {
                    Session["CurrentUser"] = result;
                    result.UserName = "一秒后跳转到主页！";
                    result.UserPassword =  "1";
                    return Json(result);
                }
                else
                {
                    result.UserPassword = "0";
                    return Json(result);
                }
            }
            else
            {
                result = new ModelUser();
                result.UserName = "用户不存在或信息有误！！";
                result.UserPassword = "失败";
                return Json(result);
            }
        }
    }
}