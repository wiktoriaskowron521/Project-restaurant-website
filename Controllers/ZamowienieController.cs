using restauracjaTI.Models;
using restauracjaTI.Models.DbModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace restauracjaTI.Controllers
{
    public class ZamowienieController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: Realizacja
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.KlientId = new SelectList(db.Klienci, "KlientId", "Imie", "Nazwisko");
            return View(new Zamowienie());
        }

        [HttpPost]
        public ActionResult Create(Zamowienie zamowienie)
        {
            if (ModelState.IsValid)
            {

                db.Zamowienia.Add(zamowienie);
                db.SaveChanges();
                return RedirectToAction("ViewAll");
            }
            ViewBag.KlientId = new SelectList(db.Klienci, "ZamowienieId", "Imie", "Nazwisko", zamowienie.KlientId);
            return View(new Zamowienie());
        }

        [HttpGet]
        public ActionResult ViewAll()
        {
            List<Zamowienie> zamowienie;
            zamowienie = db.Zamowienia.ToList();
            return View(zamowienie);
        }

        public ActionResult View(int id)
        {
            Zamowienie zamowienie;
            zamowienie = db.Zamowienia.FirstOrDefault(x => x.ZamowienieId == id);
            return View(zamowienie);
        }
    }
}