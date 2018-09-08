using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Models
{
    public class UserFilter : ActionFilterAttribute
    {
        public bool IsCheck { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //全局拦截器，拦截未登录用户
            if (IsCheck)
            {
                //校验用户是否已经登录            
                //if (filterContext.HttpContext.Session["CurrentUser"] == null || filterContext.HttpContext.Session["CurrentUser"].ToString() == "")
                //{
                //    //跳转到登陆页                                       
                //    filterContext.HttpContext.Response.Redirect("~/Login/LoginView");
                //}
            }
            //如果用户已经登陆，拦截普通用户访问管理员页面
            base.OnActionExecuting(filterContext);
        }
    }
}