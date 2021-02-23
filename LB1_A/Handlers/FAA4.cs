using System;
using System.Web;

namespace LB1
{
    public class FAA4 : IHttpHandler
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
            if (rq.Params.Count >= 2)
            {
                int x = 0, y = 0;
                if (Int32.TryParse(rq.Params[0], out x) && int.TryParse(rq.Params[1], out y))
                {
                    res.Write($"x + y = {x + y}");
                }
                else { res.Write("Not number!"); }
            }
            else { res.Write("Put only 2 params!"); }
        }
        #endregion
    }
}
