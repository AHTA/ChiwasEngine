using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChiwasEngine.Models;

namespace ChiwasEngine.Controllers
{
    public class ConfigurationController : Controller
    {
        ChiwasEngineContext db = new ChiwasEngineContext();

        public ConfigurationController()
        {
            ViewBag.MainMessage = "Configuraciones del generador de contenido.";
            ViewBag.MainTitle = "Configuración";
        }

        public ActionResult Index()
        {
            //var settings = new Settings(db);
            //settings.General.Editor = "Summernote";
            //settings.Save();

            var settings = new Settings(db);
            var editor = settings.General.Editor;

            return View(new ConfigurationModel() { Editor = editor });
        }

        [HttpPost]
        public ActionResult Settings(ConfigurationModel model)
        {
            var settings = new Settings(db);
            settings.General.Editor = model.Editor;
            settings.Save();

            return RedirectToAction("Index");
        }
    }
}
