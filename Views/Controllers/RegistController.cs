using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class RegistController : Controller
    {
        /// <summary>
        /// 转到注册视图
        /// </summary>
        /// <returns></returns>
        public ActionResult RegistView()
        {
            return View();
        }
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <returns></returns>
        public JsonResult Regist()
        {
            return Json(null);
        }
    }
}