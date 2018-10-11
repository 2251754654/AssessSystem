using Domains.AssessTerritory;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.OAuth;
using NLog;
using Repositorys.DataAccess.Context;
using Repositorys.Repositroy.Specific;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.AspNet.WebApi;
using WebApiUI.Models.Filters;

namespace WebApiUI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //消息拦截验证
            config.MessageHandlers.Add(new TokenValidateHandler());
            // 使用权限控制
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            //日志记录
            //Logger logger = LogManager.GetCurrentClassLogger();

            //跨域解决方案二

            var cors = new EnableCorsAttribute(
                ConfigurationManager.AppSettings["Origins"],
                ConfigurationManager.AppSettings["Headers"],
                ConfigurationManager.AppSettings["Methods"]);

            config.EnableCors(cors);

            //跨域解决方案一
            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
