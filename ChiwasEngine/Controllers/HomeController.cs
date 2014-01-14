using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ChiwasEngine.Models;
using ChiwasEngine.Filters;

namespace ChiwasEngine.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public HomeController()
        {
            ViewBag.MainMessage = "Bienvenido a Chiwas Framework un administrador de contenido ¡Fácil y Ruidoso!";
            ViewBag.MainTitle = "Dashboard";
        }


        public ActionResult Index()
        {
            return View();
        }

    }
}
