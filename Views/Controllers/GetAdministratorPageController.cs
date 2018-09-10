using Domains;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Views.Models;
using X.PagedList;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Views.Controllers
{
    public class GetAdministratorPageController : Controller
    {
        public ActionResult SelectRole(int page)
        {

            RoleDomain roleDomain = new RoleDomain();
            var list = roleDomain.GetAllRole();
            var pageNum = list.Count / 10+1;
            var CurrList = list.ToPagedList(page, 10).ToList();
            CurrList.Add(new ModelRole() { RoleDetails = "pageNum", RoleID = pageNum });
            return Json(/*"../Home/GetAdministratorPage"*/CurrList);
        }

        public JsonResult DeleteRole(int[] Data)
        {
    
            RoleDomain roleDomain = new RoleDomain();
            return Json(roleDomain.DeletRole(Data));
        }

        public JsonResult UpdateRole(ModelRole roleModel)
        {
            RoleDomain roleDomain = new RoleDomain();
            return Json(roleDomain.UpdateRole(roleModel)) ;
        }
        //AJAX
        public JsonResult InsertRole()
        {
            string RoleName = Request["RoleName"].ToString();
            string RoleDetails = Request["RoleDetails"].ToString();
            RoleDomain roleDomain = new RoleDomain();
            ModelRole roleModel = new ModelRole() { RoleName = RoleName, RoleDetails = RoleDetails };
            if (roleDomain.InsertRole(roleModel) >0)
            {
                return Json(roleModel);
            }
            roleModel.RoleName = "0";
            return Json(roleModel);
        }
    }
}