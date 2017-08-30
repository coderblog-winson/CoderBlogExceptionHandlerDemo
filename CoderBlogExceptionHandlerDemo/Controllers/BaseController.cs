using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoderBlogExceptionHandlerDemo.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnException(ExceptionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            //If exception handled before, do nothing.
            //If this is child action, exception should be handled by main action.
            if (context.ExceptionHandled || context.IsChildAction)
            {
                base.OnException(context);
                return;
            }

            // If custom errors are disabled, we need to let the normal ASP.NET exception handler
            // execute so that the user can see useful debugging information.
            if (!context.HttpContext.IsCustomErrorEnabled)
            {
                base.OnException(context);
                return;
            }

            // If this is not an HTTP 500 (for example, if somebody throws an HTTP 404 from an action method),
            // ignore it.
            if (new HttpException(null, context.Exception).GetHttpCode() != 500)
            {
                base.OnException(context);
                return;
            }

            //We handled the exception!
            context.ExceptionHandled = true;

            //Return a special error response to the client.
            context.HttpContext.Response.Clear();

            // Certain versions of IIS will sometimes use their own error page when
            // they detect a server error. Setting this property indicates that we
            // want it to try to render ASP.NET MVC's error page instead.
            context.HttpContext.Response.TrySkipIisCustomErrors = true;

            // update the error status code
            context.HttpContext.Response.StatusCode = 500;

            // Pass the exception data to error controller
            TempData["exception"] = context.Exception;
            context.Result = this.RedirectToAction("CustomError", "Error");
        }
    }
}