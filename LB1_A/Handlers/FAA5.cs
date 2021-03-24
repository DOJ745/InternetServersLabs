using System;
using System.Web;

namespace LB1
{
    public class FAA5 : IHttpHandler
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region Члены IHttpHandler

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest rq = context.Request;
            HttpResponse res = context.Response;

            if (rq.HttpMethod.Equals("GET")) { res.WriteFile(@"../TASK5.html"); }
           
            if (rq.HttpMethod.Equals("POST"))
            {
                int x = Convert.ToInt32(rq.Params["x"]);
                int y = Convert.ToInt32(rq.Params["y"]);
                int mul = x * y;
                res.Write($"{mul}");
            }
        }

        #endregion
    }
}
