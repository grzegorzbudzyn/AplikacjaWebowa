using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AplikacjaWebowa.Models;//testgita

namespace AplikacjaWebowa.Controllers
{
    public class CmController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cm
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        // GET: Cm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontakty kontakty = db.Contacts.Find(id);
            if (kontakty == null)
            {
                return HttpNotFound();
            }
            return View(kontakty);
        }

        // GET: Cm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KontaktyId,Nazwa,Adres,Miasto,Stan,Kod_Kontenera,Email")] Kontakty kontakty)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(kontakty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kontakty);
        }

        // GET: Cm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontakty kontakty = db.Contacts.Find(id);
            if (kontakty == null)
            {
                return HttpNotFound();
            }
            return View(kontakty);
        }

        // POST: Cm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KontaktyId,Nazwa,Adres,Miasto,Stan,Kod_Kontenera,Email")] Kontakty kontakty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kontakty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kontakty);
        }

        // GET: Cm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontakty kontakty = db.Contacts.Find(id);
            if (kontakty == null)
            {
                return HttpNotFound();
            }
            return View(kontakty);
        }

        // POST: Cm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kontakty kontakty = db.Contacts.Find(id);
            db.Contacts.Remove(kontakty);
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
