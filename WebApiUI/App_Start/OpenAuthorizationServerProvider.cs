using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Repositorys.DataAccess.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using UserInfoDomain.UserTerritory;
using WebApiUI.Models.DbContext;

namespace WebApiUI.App_Start
{
    public class OpenAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        ///     验证客户端
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)

        {
            //处理预检请求
            //if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            //{
            //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "*");
            //    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "*");
            //    return;
            //}

            string client_id;
            string clientSecret;
            context.TryGetFormCredentials(out client_id, out clientSecret);
            if (!context.TryGetFormCredentials(out client_id, out clientSecret))
            {
                if (!context.TryGetBasicCredentials(out client_id, out clientSecret)) //Basic认证
                {
                    client_id = context.Parameters.Get("client_id");
                }

            }
            // TODO: 读库，验证
            if (client_id != "assess")
            {
                context.SetError("客户端", "没有通过验证！");
                return;
            }
            //获取登陆的用户名密码
            string userName = context.Parameters.Get("username");
            string password = context.Parameters.Get("password");


            var user = DbContextFactory.GetDbContext().Set<User>().Where(o=>o.UserName == userName&&o.Password == password).FirstOrDefault();
            if (user == null)
            {
                context.SetError("username", "账户不存在或者密码错误！");
                return;
            }
            context.OwinContext.Set("Guid", user.Guid.ToString());
            context.Validated(client_id);
        }

        /// <summary>
        ///     客户端授权[生成access token]
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
        {
            var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.ClientId));
            var props = new AuthenticationProperties(new Dictionary<string, string> { { "client_id", context.ClientId }, { "Guid", context.OwinContext.Get<string>("Guid") } }) { AllowRefresh=true };
            var ticket = new AuthenticationTicket(oAuthIdentity,props);
            context.Validated(ticket);
            context.Response.Headers.Add("Access-Control-Allow-Origin",new string[] {"*"});
            return base.GrantClientCredentials(context);
        }


        /// <summary>
        /// 刷新Token[刷新refresh_token]
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            if (context.Ticket == null || context.Ticket.Identity == null || !context.Ticket.Identity.IsAuthenticated)
            {
                context.SetError("invalid_grant", "Refresh token is not valid");
            }
            else
            {
                //Additional claim is needed to separate access token updating from authentication 
                
            }
            return base.GrantRefreshToken(context);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            //if (context.ClientId == "fubowen")
            //{
            //    var expectedRootUri = new Uri(context.Request.Uri, "/");
            //    if (expectedRootUri.AbsoluteUri == context.RedirectUri)
            //    {
            //        context.Validated();
            //    }
            //}
            return Task.FromResult<object>(null);
        }
        //客户端验证和生成
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return base.GrantResourceOwnerCredentials(context);
        }
    }
}