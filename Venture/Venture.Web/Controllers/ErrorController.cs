using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABC.Venture.Web.Controllers
{
    public class ErrorController : Controller
    { 
       /// <summary>
       /// Return the Error Page view
       /// </summary>
       /// <returns></returns>
        public ActionResult Error()
        {
            return View();
        }
    }
}