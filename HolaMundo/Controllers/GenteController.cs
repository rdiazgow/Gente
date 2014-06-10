using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HolaMundo.Models;

namespace HolaMundo.Controllers
{
    public class GenteController : Controller
    {
        private HolaMundoContext db = new HolaMundoContext();

        //
        // GET: /Gente/

        public ActionResult Index()
        {
            return View(db.Gentes.ToList());
        }

        //
        // GET: /Gente/Details/5

        public ActionResult Details(int id = 0)
        {
            Gente gente = db.Gentes.Find(id);
            if (gente == null)
            {
                return HttpNotFound();
            }
            return View(gente);
        }

        //
        // GET: /Gente/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Gente/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gente gente)
        {
            if (ModelState.IsValid)
            {
                db.Gentes.Add(gente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gente);
        }

        //
        // GET: /Gente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Gente gente = db.Gentes.Find(id);
            if (gente == null)
            {
                return HttpNotFound();
            }
            return View(gente);
        }

        //
        // POST: /Gente/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gente gente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gente);
        }

        //
        // GET: /Gente/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Gente gente = db.Gentes.Find(id);
            if (gente == null)
            {
                return HttpNotFound();
            }
            return View(gente);
        }

        //
        // POST: /Gente/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gente gente = db.Gentes.Find(id);
            db.Gentes.Remove(gente);
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