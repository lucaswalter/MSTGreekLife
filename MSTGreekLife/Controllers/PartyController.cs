using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MSTGreekLife.DAL;
using MSTGreekLife.Models;

namespace MSTGreekLife.Controllers
{
    [Authorize]
    public class PartyController : Controller
    {
        private GreekLifeContext db = new GreekLifeContext();

        // TODO: Add GroupBy Aggregation
        // GET: Party
        public ActionResult Index()
        {
            return View(db.Parties.ToList());
        }

        // GET: Party/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Party/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Theme,Time,Location")] PartyModel partyModel)
        {
            if (ModelState.IsValid)
            {
                db.Parties.Add(partyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partyModel);
        }

        // GET: Party/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyModel partyModel = db.Parties.Find(id);
            if (partyModel == null)
            {
                return HttpNotFound();
            }
            return View(partyModel);
        }

        // POST: Party/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Theme,Time,Location")] PartyModel partyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partyModel);
        }

        // GET: Party/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartyModel partyModel = db.Parties.Find(id);
            if (partyModel == null)
            {
                return HttpNotFound();
            }
            return View(partyModel);
        }

        // POST: Party/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartyModel partyModel = db.Parties.Find(id);
            db.Parties.Remove(partyModel);
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
