using Domains;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ABCController : Controller
    {
        private readonly IDomainLogin domainLogin;

        public ABCController(IDomainLogin _domainLogin)
        {
            this.domainLogin = _domainLogin ?? throw new ArgumentNullException(nameof(domainLogin));
        }


        public ActionResult Index()
        {
            return View();
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
        public ActionResult LoginSystem(string UserName, string Password)
        {
            ModelUser modelUser = new ModelUser()
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
                    result.UserPassword = "成功";
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