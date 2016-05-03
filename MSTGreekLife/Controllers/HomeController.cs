using System.Linq;
using System.Web.Mvc;
using MSTGreekLife.DAL;

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
    }
}