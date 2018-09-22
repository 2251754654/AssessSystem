using Domains;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class OneSelfAssessController : AbstractAssessController
    {
        public OneSelfAssessController(IDomainOneselfAssess domainOneselfAssess) : base(domainOneselfAssess)
        {
        }
        /// <summary>
        /// 个人评价视图
        /// </summary>
        /// <returns></returns>
        public ActionResult OneSelfAssessView()
        {
            return View();
        }
        /// <summary>
        /// 查询自我评价信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public JsonResult FindOneselfAssess()
        {
            var userID = (Session["CurrentUser"] as ModelUser).UserID;
            var result = domainOneselfAssess.FindOneselfAssessToOneself(userID);
            return Json(result);
        }
      
    }
}