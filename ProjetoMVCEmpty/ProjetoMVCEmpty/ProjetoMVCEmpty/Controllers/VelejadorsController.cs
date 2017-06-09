using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoMVCEmpty.Models;

namespace ProjetoMVCEmpty.Controllers
{
    public class VelejadorsController : Controller
    {
        private ProjetoMVCEmptyContext db = new ProjetoMVCEmptyContext();

        // GET: Velejadors
        public ActionResult Index()
        {
            return View(db.Velejadors.ToList());
        }

        // GET: Velejadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Velejador velejador = db.Velejadors.Find(id);
            if (velejador == null)
            {
                return HttpNotFound();
            }
            return View(velejador);
        }

        // GET: Velejadors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Velejadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nome,Modalidade,Idade,Celular")] Velejador velejador)
        {
            if (ModelState.IsValid)
            {
                db.Velejadors.Add(velejador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(velejador);
        }

        // GET: Velejadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Velejador velejador = db.Velejadors.Find(id);
            if (velejador == null)
            {
                return HttpNotFound();
            }
            return View(velejador);
        }

        // POST: Velejadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nome,Modalidade,Idade,Celular")] Velejador velejador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(velejador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(velejador);
        }

        // GET: Velejadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Velejador velejador = db.Velejadors.Find(id);
            if (velejador == null)
            {
                return HttpNotFound();
            }
            return View(velejador);
        }

        // POST: Velejadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Velejador velejador = db.Velejadors.Find(id);
            db.Velejadors.Remove(velejador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
