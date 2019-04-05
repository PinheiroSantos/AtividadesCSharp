using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GerenciamentoMovelVendas.Models;

namespace GerenciamentoMovelVendas.Controllers
{
    public class MoveisController : Controller
    {
        private GerenciamentoMovelVendasContext db = new GerenciamentoMovelVendasContext();

        // GET: Moveis
        public ActionResult Index()
        {
            return View(db.Movels.ToList());
        }

        // GET: Moveis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movel movel = db.Movels.Find(id);
            if (movel == null)
            {
                return HttpNotFound();
            }
            return View(movel);
        }

        // GET: Moveis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moveis/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovelId,Nome,Cor,Medida,Material,LinkImagemMovel,Status")] Movel movel)
        {
            if (ModelState.IsValid)
            {
                db.Movels.Add(movel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movel);
        }

        // GET: Moveis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movel movel = db.Movels.Find(id);
            if (movel == null)
            {
                return HttpNotFound();
            }
            return View(movel);
        }

        // POST: Moveis/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovelId,Nome,Cor,Medida,Material,LinkImagemMovel,Status")] Movel movel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movel);
        }

        // GET: Moveis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movel movel = db.Movels.Find(id);
            if (movel == null)
            {
                return HttpNotFound();
            }
            return View(movel);
        }

        // POST: Moveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movel movel = db.Movels.Find(id);
            db.Movels.Remove(movel);
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
