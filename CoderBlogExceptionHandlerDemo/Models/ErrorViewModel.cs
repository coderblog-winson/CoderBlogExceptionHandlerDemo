using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoderBlogExceptionHandlerDemo.Models
{
    public class ErrorViewModel
    {
        public ErrorInfo ErrorInfo { get; set; }

        public Exception Exception { get; set; }

        public ErrorViewModel()
        {

        }

        public ErrorViewModel(Exception exception)
        {
            Exception = exception;
        }
    }
}