using CoderBlogExceptionHandlerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoderBlogExceptionHandlerDemo.App_Start
{
    public static class ExceptionHandler
    {
        private static ErrorViewModel error;

        public static ErrorViewModel GetLastError
        {
            get
            {
                HttpContext.Current.Server.ClearError();
                return error;
            }
        }

        public static void LogException()
        {
            error = new ErrorViewModel();
            var errInfo = new ErrorInfo();
            errInfo.Message = "Unknow Error";
            Exception exc = HttpContext.Current.Server.GetLastError();
            if (exc == null) return;
            string errLog = "";
            errLog += "**********" + DateTime.Now + "**********<br>";

            if (exc.InnerException != null)
            {
                errLog += "Inner Exception Type: <br>";
                errLog += exc.InnerException.GetType() + "<br>";
                errLog += "Inner Exception: " + "<br>";
                errLog += exc.InnerException.Message + "<br>";
                errLog += "Inner Source: ";
                errLog += exc.InnerException.Source + "<br>";
                if (exc.InnerException.StackTrace != null)
                {
                    errLog += "\nInner Stack Trace: " + "<br>";
                    errLog += exc.InnerException.StackTrace + "<br>";
                }
            }

            errLog += "Exception Type: " + exc.GetType().ToString() + "<br>";

            if (exc.StackTrace != null)
            {
                errLog += "\nStack Trace: " + "<br>";
                errLog += exc.StackTrace + "<br>";
            }

            errInfo.Message = exc.Message;
            errInfo.Details = errLog;

            error.ErrorInfo = errInfo;
        }
    }

}