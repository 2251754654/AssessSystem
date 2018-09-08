using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Views.Models;
using Corsis.Xhtml;

namespace Views.Controllers
{
    [UserFilter(IsCheck =false)]
    public class WebController : Controller
    {
        // GET: Web
        public async Task Index(string UserName, string Password)
        {
            await GetUser(UserName, Password);
            Response.Write(ViewBag.Message);
        }
        public async Task Indexdd(string UserName, string Password)
        {
            

        }


        /// <summary>
        /// HttpClient实现Post请求
        /// </summary>
        private async Task GetUser(string UserName, string Password)
        {
            string url = "http://localhost:55569/api/Login/LoginCheck";
            //设置HttpClientHandler的AutomaticDecompression
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            //创建HttpClient（注意传入HttpClientHandler）
            using (var http = new HttpClient(handler))
            {
                //使用FormUrlEncodedContent做HttpContent
                var content = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                  {"UserName", UserName},//键名必须为空
                  {"Password", Password}
                 });

                //await异步等待回应

                var response = await http.PostAsync(url, content);
                //确保HTTP成功状态值
               // response.EnsureSuccessStatusCode();
               
                if(response.IsSuccessStatusCode){

                    //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                   ViewBag.Message =  await response.Content.ReadAsStringAsync();
                }
                else
                {
                    ViewBag.Message = "失败！";
                }
            }

        }
    }
}