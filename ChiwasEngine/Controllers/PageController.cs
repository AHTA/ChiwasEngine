using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChiwasEngine.Models;
using System.Web.Helpers;

namespace ChiwasEngine.Controllers
{
	[Authorize]
	public class PageController : Controller
	{
		private ChiwasEngineContext db = new ChiwasEngineContext();

		public PageController()
		{
			ViewBag.MainMessage = "En este lugar puedes crear todo el contenido de tu sitio web.";
			ViewBag.MainTitle = "Pages";
		}

		public ActionResult Index()
		{
			return View(db.Pages.ToList().OrderByDescending(orden => orden.page_id));
		}

		public ActionResult Details(int id = 0)
		{
			Pages postsmodels = db.Pages.Find(id);
			if (postsmodels == null)
			{
				return HttpNotFound();
			}
			return View(postsmodels);
		}

		#region Create
		public ActionResult Create()
		{
			//dd/mm/yyyy
            return View(new Pages() { page_date = DateTime.Now });
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Create(Pages postsmodels, FormCollection collection)
		{
			//Completando datos
			postsmodels.page_modified = DateTime.Now;
			postsmodels.UserProfile = db.UserProfiles.FirstOrDefault(item => item.UserName.ToLower() == User.Identity.Name.ToLower());

			//Agregando categorias
			foreach (var category in db.Categories.ToList())
			{
				if (collection["category_" + category.category_id] != null)
				{
					if (collection["category_" + category.category_id].ToString().Contains("on"))
					{
						postsmodels.Categories.Add(category);
					}
				}
			}

			//Guardando imagen
			var file = Request.Files["page_image"];

			if (file != null && file.ContentLength > 0)
			{
				var fileName = DateTime.Now.ToFileTime() + System.IO.Path.GetExtension(file.FileName);
				var path = System.IO.Path.Combine(Server.MapPath("~/Content/uploads/"), fileName);

				postsmodels.page_image = fileName;

				file.SaveAs(path);
			}

			//Validando modelo
			if (ModelState.IsValid)
			{
				postsmodels.page_title = postsmodels.page_title.Trim();
				postsmodels.page_content = postsmodels.page_content.Trim();
				postsmodels.page_description = postsmodels.page_description.Trim();

				db.Pages.Add(postsmodels);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(postsmodels);
		}
		
		#endregion

		#region Edit
		public ActionResult Edit(int id = 0)
		{
			Pages postsmodels = db.Pages.Find(id);
			if (postsmodels == null)
			{
				return HttpNotFound();
			}
			return View(postsmodels);
		}

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Edit(int id, Pages postsmodels, FormCollection collection)
		{
			//Buscando pagina
			Pages pagina = db.Pages.Find(id);
			if (pagina == null)
			{
				return HttpNotFound();
			}

			//Completando datos
			pagina.page_content = postsmodels.page_content.Trim();
			pagina.page_title = postsmodels.page_title.Trim();
			pagina.page_description = postsmodels.page_description.Trim();
			pagina.page_visible = postsmodels.page_visible;
			pagina.page_modified = DateTime.Now;
            pagina.page_date = postsmodels.page_date;

			pagina.Categories.Clear();

			//Agregando categorias
			foreach (var category in db.Categories.ToList())
			{
				if (collection["category_" + category.category_id] != null)
				{
					if (collection["category_" + category.category_id].ToString().Contains("on"))
					{
						pagina.Categories.Add(category);
					}
				}
			}

			//Guardando imagen
			var file = Request.Files["page_image"];

			if (file != null && file.ContentLength > 0)
			{
				var fileName = DateTime.Now.ToFileTime() + System.IO.Path.GetExtension(file.FileName);
				var path = System.IO.Path.Combine(Server.MapPath("~/Content/uploads/"), fileName);

				pagina.page_image = fileName;

				file.SaveAs(path);
			}

			//Validando modelo
			if (ModelState.IsValid)
			{
				db.Entry(pagina).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(postsmodels);
		}
		#endregion

		#region Delete
		public ActionResult Delete(int id = 0)
		{
			Pages postsmodels = db.Pages.Find(id);
			if (postsmodels == null)
			{
				return HttpNotFound();
			}
			return View(postsmodels);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Pages postsmodels = db.Pages.Find(id);
			db.Pages.Remove(postsmodels);
			db.SaveChanges();
			return RedirectToAction("Index");
		} 
		#endregion

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}
	}
}