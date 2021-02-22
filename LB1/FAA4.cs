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

            res.Write("<h3>TASK 4</h3>");
            res.Write("<!DOCTYPE html> " +
                "<html>" +
                "<head> <meta charset = 'utf-8'>" +
                "<title>LB1</title>" +
                "</head>" +
                "<body>" +
                    "<form method='POST'>" +
                    "<p>X - <input name = 'x' type = 'number'></p>" +
                    "<p>Y - <input name = 'y' type = 'number'></p> " +
                    "<p><input type = 'submit'></p>" +
                    "</form>" +
                "</body>" +
                "</html>");

            //for (int i = 0; i < 2; i++)
            //{

            res.Write($"<br/>" + $"{ Convert.ToInt32(@rq.Params.Get(rq.Params.GetKey(0))) + Convert.ToInt32(@rq.Params.Get(rq.Params.GetKey(1))) } ");
             
            //}
        }
        #endregion
    }
}
