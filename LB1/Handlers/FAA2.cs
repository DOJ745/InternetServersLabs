using System;
using System.Web;

namespace LB1
{
    public class FAA2 : IHttpHandler
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

            res.Write("<h3>TASK 2</h3>");

            res.Write($"<br/>" +
                    $"{ @rq.HttpMethod }" + "-Http-FAA:" +
                    "<span>ParamA = </span>" +
                    $"{ @rq.Params.Get(rq.Params.GetKey(0)) }" +
                    "<span>, ParamB = </span>" +
                    $"{ @rq.Params.Get(rq.Params.GetKey(1)) }"
                    );
        }

        #endregion
    }
}
