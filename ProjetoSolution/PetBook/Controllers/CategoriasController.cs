using BaseModels;
using PetBook.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PetBook.Controllers
{
    public class CategoriasController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        // GET: Categorias
        public ActionResult Index()
        {
            var categorias = db.Categorias.ToList();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Categorias.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Categoria categoria = db.Categorias.Find(id);
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            if(categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }
        [HttpPost]
        public ActionResult DeleteConfirmed(int? id)
        {
            Categoria categoria = db.Categorias.Find(id);
            categoria.Ativo = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            Categoria categoria = db.Categorias.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);
        }
        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Details(int? id)
        {
            Categoria categoria = db.Categorias.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            if (categoria == null)
            {
                return HttpNotFound();
            }

            return View(categoria);

        }
    }
}