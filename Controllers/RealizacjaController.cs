using restauracjaTI.Models;
using restauracjaTI.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace restauracjaTI.Controllers
{
    public class RealizacjaController : Controller
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
            ViewBag.DanieId = new SelectList(db.Dania, "DanieId", "NazwaDania", "CenaDania");
            ViewBag.KlientId = new SelectList(db.Klienci, "KlientId", "Imie", "Nazwisko");
            return View(new Realizacja());
        }

        [HttpPost]
        public ActionResult Create(Realizacja realizacja)
        {
            if (ModelState.IsValid)
            {

                db.Realizacje.Add(realizacja);
                db.SaveChanges();
                return RedirectToAction("ViewAll");
            }
            ViewBag.DanieId = new SelectList(db.Dania, "DanieId", "NazwaDania", "CenaDania", realizacja.DanieId);
            ViewBag.KlientId = new SelectList(db.Klienci, "ZamowienieId", "Imie", "Nazwisko", realizacja.KlientId);
            return View(new Realizacja());
        }

        [HttpGet]
        public ActionResult ViewAll()
        {
            List<Realizacja> realizacja;
            realizacja = db.Realizacje.ToList();
            return View(realizacja);
        }

        public ActionResult View(int id)
        {
            Realizacja realizacja;
            realizacja = db.Realizacje.FirstOrDefault(x => x.RealizacjaId == id);
            return View(realizacja);
        }
    }
}