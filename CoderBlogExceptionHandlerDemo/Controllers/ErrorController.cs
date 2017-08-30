using CoderBlogExceptionHandlerDemo.App_Start;
using CoderBlogExceptionHandlerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoderBlogExceptionHandlerDemo.Controllers
{
    public class ErrorController : BaseController
    {     

        public ActionResult CustomErrorFromGlobal()
        {
            var err = ExceptionHandler.GetLastError;
            return View("Error", ExceptionHandler.GetLastError);
        }

        /// <summary>
        /// For handle access right case
        /// </summary>
        /// <returns></returns>
        public ActionResult AccessDenied()
        {
            var error = new ErrorViewModel();
            var errInfo = new ErrorInfo();

            errInfo.Message = "Error";
            errInfo.Details = "Sorry, you do not have access right for this operation!";

            error.ErrorInfo = errInfo;

            return View("Error", error);
        }
    }
}