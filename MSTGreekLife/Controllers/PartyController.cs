using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
            ApplicationUser user =
                System.Web.HttpContext.Current.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>()
                    .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var school = db.Schools.FirstOrDefault(x => x.Id == user.SchoolId);
            ViewBag.SchoolName = school.SchoolName;

            return View(db.Parties.ToList());
        }

        public ActionResult SignIn(int id)
        {
            var party = db.Parties.Find(id);
            return View(party);
        }

        public ActionResult CheckStudentID()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckStudentID(int studentID)
        {
            var student = db.Students.FirstOrDefault(x => x.StudentID == studentID);


            if (student != null)
            {
                // Add Student To Party Attendees List
                //var party = db.Parties.Find(partyID);
                //party.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("SignIn", "Party");
            }
            else
            {
                return RedirectToAction("SignIn", "Party");
            }
        }

       /* [HttpPost]
        public ActionResult SignIn(StudentSignIn studentSignIn)
        {
            var student = db.Students.FirstOrDefault(s => s.StudentID == studentSignIn.StudentID);

            if (student != null)
            {
                // Success, Add to List
            }
            else
            {
                // Failure
            }

            return View();
        }*/

        // GET: Party/Create
        public ActionResult Create()
        {
            var greekHouses = db.GreekHouses.ToList();
            var selectionList = new SelectList(greekHouses, "Id", "HouseName");
            var vm = new CreatePartyViewModel { ListOfGreekHouses = selectionList };

            return View(vm);
        }

        // POST: Party/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePartyViewModel model)
        {
            var partyModel = new PartyModel
            {
                HostingHouse = db.GreekHouses.Find(model.SelectedHouseId),
                Name = model.Name,
                Theme = model.Theme,
                Time = model.Time,
                Location = model.Location
            };

            if (ModelState.IsValid)
            {
                db.Parties.Add(partyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
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
