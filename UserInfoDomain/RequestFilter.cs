using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Json;

namespace AssessApi.Models
{
    public class RequestFilter : DelegatingHandler
    {
        /// <summary>
        /// 请求拦截，可进行权限验证
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //获取url参数
            var keyValue = HttpUtility.ParseQueryString(request.RequestUri.Query);
            //获取post正文数据
            var content = request.GetRequestContext();
            //获取请求的键值对
            var key = request.GetQueryNameValuePairs().ToList();
            //获取Post正文数据，比如json文本
            string fRequesContent = request.Content.ReadAsStringAsync().Result;

            //可以做一些其他安全验证工作，比如Token验证，签名验证。

            //可以在需要时自定义HTTP响应消息

            //return SendError("自定义的HTTP响应消息", HttpStatusCode.OK);

            //记录响应时间

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //发送请求
            var response = base.SendAsync(request, cancellationToken);
            //修改响应体
            //response.Result.Content = new StringContent(response.Result.Content.ReadAsStringAsync().Result.Replace(@"\\", @"\"));
            //sw.Stop();
            //long exeMs = sw.ElapsedMilliseconds;
            //response.Result.Content = new StringContent(exeMs.ToString()+"时间！");
            //var result = response.Result;
            //response.Result.Content = new StringContent(JsonParser.Serialize(result), Encoding.UTF8,"application/json");
            return response ;
        }
        //构造响应体
        private HttpResponseMessage SendMessage(string error, HttpStatusCode code)
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(error);
            response.StatusCode = code;
            return response;
        }

        private HttpResponseMessage SendError(string error,HttpStatusCode code)
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent(error);
            response.StatusCode = code;
            return response;
        }
    }
}