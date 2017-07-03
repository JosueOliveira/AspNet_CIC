using BaseModels;
using PetBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PetBook.Controllers
{
    public class AnimaisController : Controller
    {
        private dbContext db = new dbContext();
        public ActionResult Index()
        {
            return View(db.Categorias.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animais.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animais.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animal);
        }
                 

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animais.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        [HttpPost]        
        public ActionResult Edit(Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animal);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animais.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        [HttpPost]        
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animais.Find(id);
            db.Animais.Remove(animal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}