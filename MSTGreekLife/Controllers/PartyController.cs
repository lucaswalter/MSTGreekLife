using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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

            // Order Parties By Date Time
            /*var orderedParties =
                db.Parties.OrderByDescending(x => x.Time).ThenByDescending(x => x.Time.TimeOfDay).ToList();*/

            return View(db.Parties.ToList());
        }

        [HttpGet]
        public PartialViewResult ListAttendees(int id)
        {
            var party = db.Parties.Find(id);
            // EF Query To Count Current Number Of Party Attendees
            ViewBag.NumberOfPeople = party.Students.Count;
            return PartialView(party);
        }

        [HttpGet]
        public ActionResult SignIn(int id)
        {
            var party = db.Parties.Find(id);
            var vm = new SignInViewModel {Party = party, PartyID = id};
            ViewBag.PartyID = id;

            return View(vm);
        }

        [HttpPost]
        public ActionResult SignIn(SignInViewModel model)
        {
            var student = db.Students.FirstOrDefault(s => s.StudentID == model.StudentId);

            // TODO: Check If Student Is Blacklisted
            if (student != null)
            {
                var party = db.Parties.Find(1);
                party.Students.Add(student);
                db.SaveChanges();
            }

            return RedirectToAction("SignIn");
        }

        public ActionResult DeleteStudent(int id, int partyId)
        {
            var student = db.Students.Find(id);
            var party = db.Parties.Find(partyId);

            party.Students.Remove(student);
            db.SaveChanges();

            return RedirectToAction("SignIn", "Party", new { id = partyId });
        }

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
