
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Handlers;
using System.Web.Http;

namespace WebApiUI.Models.Filters
{
    public class TokenValidateHandler : DelegatingHandler
    {
        /// <summary>
        /// 验证Token
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
           
            return base.SendAsync(request, cancellationToken);
        }
    }
}