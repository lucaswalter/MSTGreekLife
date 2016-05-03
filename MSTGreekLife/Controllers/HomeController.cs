using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MSTGreekLife.DAL;
using MSTGreekLife.Models;

namespace MSTGreekLife.Controllers
{
    public class HomeController : Controller
    {
        private GreekLifeContext db = new GreekLifeContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Students()
        {
            // Group Students By Their Respective House & Order Them By Their First Name
            var students = db.Students.ToList().OrderBy(s => s.Name.FirstName).GroupBy(s => s.GreekHouse.Id);
            return View(students);
        }

        public ActionResult Blacklist()
        {
            var blacklistings = db.Blacklistings.ToList();
            return View(blacklistings);
        }

        public ActionResult BlacklistReason(int id)
        {
            var blacklisting = db.Blacklistings.Find(id);
            return View(blacklisting);
        }

        [HttpPost]
        public ActionResult BlacklistReason(BlacklistModel model)
        {
            var blacklisting = db.Blacklistings.Find(model.Id);

            blacklisting.Reason = model.Reason;
            db.SaveChanges();

            return RedirectToAction("Blacklist");
        }

        public ActionResult Unblacklist(int id)
        {
            var blacklisting = db.Blacklistings.Find(id);
            return View(blacklisting);
        }

        [HttpPost]
        public ActionResult Unblacklist(BlacklistModel model)
        {
            var blacklisting = db.Blacklistings.Find(model.Id);

            db.Blacklistings.Remove(blacklisting);
            db.SaveChanges();

            return RedirectToAction("Blacklist");
        }
    }
}