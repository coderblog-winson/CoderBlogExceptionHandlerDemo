using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoderBlogExceptionHandlerDemo.Controllers
{
    public class HomeController : BaseController
    {
        
        public ActionResult Error1()
        {
            List<string> test = null;

            test.Add("a");

            return View("Index");
        }

        public ActionResult Error2()
        {
            try
            {
                List<string> test = null;

                test.Add("a");
            }
            catch (Exception ex)
            {
                throw new Exception("Object is not defined!");
            }
            return View("Index");
        }
    }
}