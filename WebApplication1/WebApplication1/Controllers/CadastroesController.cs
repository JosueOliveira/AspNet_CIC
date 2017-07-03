using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CadastroesController : Controller
    {
        private CadastroContext db = new CadastroContext();

        // GET: Cadastroes
        public ActionResult Index()
        {
            return View(db.Cadastroes.ToList());
        }

        // GET: Cadastroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadastro cadastro = db.Cadastroes.Find(id);
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            return View(cadastro);
        }

        // GET: Cadastroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cadastroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCadastro,Nome,Sobrenome")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                db.Cadastroes.Add(cadastro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastro);
        }

        // GET: Cadastroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadastro cadastro = db.Cadastroes.Find(id);
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            return View(cadastro);
        }

        // POST: Cadastroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCadastro,Nome,Sobrenome")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastro);
        }

        // GET: Cadastroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadastro cadastro = db.Cadastroes.Find(id);
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            return View(cadastro);
        }

        // POST: Cadastroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cadastro cadastro = db.Cadastroes.Find(id);
            db.Cadastroes.Remove(cadastro);
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
