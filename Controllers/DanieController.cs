using restauracjaTI.Models;
using restauracjaTI.Models.DbModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace restauracjaTI.Controllers
{
    public class DanieController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: Danie
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.RodzajDaniaId = new SelectList(db.RodzajDan, "RodzajDaniaId", "NazwaRodzaju");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Danie danie)
        {
            if (ModelState.IsValid)
            {
                db.Dania.Add(danie);
                db.SaveChanges();

            }
            return RedirectToAction("ViewAll");

            ViewBag.RodzajDaniaId = new SelectList(db.RodzajDan, "RodzajDaniaId", "NazwaRodzaju", danie.RodzajDaniaId);
            return View(new Danie());
        }

        [HttpGet]
        public ActionResult ViewAll()
        {

            List<Danie> danie;
            danie = db.Dania.ToList();
            return View(danie.ToList());

        }

        public ActionResult View(int id)
        {
            Danie danie;
            danie = db.Dania.FirstOrDefault(c => c.DanieId == id);
            return View(danie);
        }

        public ActionResult Edit(int id)
        {
            Danie danie;
            danie = db.Dania.FirstOrDefault(c => c.DanieId == id);
            ViewBag.RodzajDaniaId = new SelectList(db.RodzajDan, "RodzajDaniaId", "NazwaRodzaju", danie.RodzajDaniaId);
            return View(danie);
        }

        [HttpPost]
        public ActionResult Edit(Danie danie)
        {
            if (!ModelState.IsValid)
            {
                return View(danie);
            }

            db.Entry(danie).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("ViewAll");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Danie danie;
            danie = db.Dania.FirstOrDefault(c => c.DanieId == id);
            return View(danie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Danie danie;
            danie = db.Dania.FirstOrDefault(c => c.DanieId == id);
            db.Dania.Remove(danie);
            db.SaveChanges();
            return RedirectToAction("ViewAll");
        }


    }
}
