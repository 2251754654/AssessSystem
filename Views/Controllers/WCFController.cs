using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using Views.DataService;

namespace Views.Controllers
{
    public class WCFController : Controller
    {
        
        private readonly DataServiceClient dataServiceClient; 
        public WCFController(DataServiceClient _dataServiceClient)
        {
            this.dataServiceClient = _dataServiceClient;
        }

        // GET: WCF
        [Models.UserFilter(IsCheck =false)]
        public ActionResult Login()
        {
            //调用登陆验证
            //DataServiceClient dataServiceClient = new DataServiceClient();
            if (dataServiceClient.LoginCheck1(new User() { Username = "fubowen", Password="123" }))
            {
                ViewBag.message = "登陆成功！";
            }
            else
            {
                ViewBag.message = "登陆失败！";
            }
            return View();
        }
    }
}