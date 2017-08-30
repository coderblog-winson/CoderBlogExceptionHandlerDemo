using CoderBlogExceptionHandlerDemo.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;

namespace CoderBlogExceptionHandlerDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            Exception ex = HttpContext.Current.Server.GetLastError();

            bool handleUnknownError = Convert.ToBoolean(WebConfigurationManager.AppSettings["HandleUnknownError"]);
            if (handleUnknownError)
            {
                //var routeData = new RouteData();
                //routeData.Values["controller"] = "Error";
                //routeData.Values["action"] = "CustomError";
                Response.StatusCode = 500;

                //HttpContext.Current.Session["exception"] = ex;

                ExceptionHandler.LogException();

                UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
                var redirectUrl = url.RouteUrl(new { Controller = "Error", Action = "CustomErrorFromGlobal" });
                HttpContext.Current.Response.Redirect(redirectUrl);
            }
        }
    }
}
