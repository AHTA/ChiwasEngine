using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChiwasEngine.Models;

namespace ChiwasEngine.Controllers
{
    public class CategoryController : Controller
    {
        private ChiwasEngineContext db = new ChiwasEngineContext();

        public CategoryController()
        {
            ViewBag.MainMessage = "Clasifica toda la información de tu sitio, para que le sea más fácil navegar a tus usuarios.";
            ViewBag.MainTitle = "Categories";
        }

        //
        // GET: /Category/

        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        //
        // GET: /Category/Details/5

        public ActionResult Details(int id = 0)
        {
            Categories categoriesmodels = db.Categories.Find(id);
            if (categoriesmodels == null)
            {
                return HttpNotFound();
            }
            return View(categoriesmodels);
        }

        //
        // GET: /Category/Create

        public ActionResult Create()
        {
            return View(new Categories());
        }

        //
        // POST: /Category/Create

        [HttpPost]
        public ActionResult Create(Categories categoriesmodels)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(categoriesmodels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriesmodels);
        }

        //
        // GET: /Category/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Categories categoriesmodels = db.Categories.Find(id);
            if (categoriesmodels == null)
            {
                return HttpNotFound();
            }
            return View(categoriesmodels);
        }

        //
        // POST: /Category/Edit/5

        [HttpPost]
        public ActionResult Edit(Categories categoriesmodels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriesmodels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriesmodels);
        }

        //
        // GET: /Category/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Categories categoriesmodels = db.Categories.Find(id);
            if (categoriesmodels == null)
            {
                return HttpNotFound();
            }
            return View(categoriesmodels);
        }

        //
        // POST: /Category/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Categories categoriesmodels = db.Categories.Find(id);
            db.Categories.Remove(categoriesmodels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}