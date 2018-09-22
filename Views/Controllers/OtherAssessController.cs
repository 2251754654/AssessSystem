using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domains;
using Models;

namespace Views.Controllers
{
    public  class OtherAssessController : AbstractAssessController
    {
        public OtherAssessController(IDomainOtherAssess domainOtherAssess) : base(domainOtherAssess)
        {
        }
        /// <summary>
        /// 他人评价视图
        /// </summary>
        /// <returns></returns>
        public ActionResult OtherAssessView()
        {
            return View();
        }
        /// <summary>
        /// 查询他人对自己的评价
        /// </summary>
        /// <param name="userInfoID"></param>
        /// <returns></returns>
        public JsonResult FindOtherAssess()
        {
            var userID = (Session["CurrentUser"] as ModelUser).UserID;
            var result = domainOtherAssess.FindOtherAssessToOneself(userID);
            return Json(result);
        }
    }
}