using restauracjaTI.Models;
using restauracjaTI.Models.DbModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace restauracjaTI.Controllers
{
    public class SzczegolyZamowieniaController : Controller
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
            ViewBag.DanieId = new SelectList(db.Dania, "DanieId", "NazwaDania");
            ViewBag.ZamowienieId = new SelectList(db.Zamowienia, "ZamowienieId", "ZamowienieId");
            return View();
        }

        [HttpPost]
        public ActionResult Create(SzczegolyZamowienia szczegolyZamowienia)
        {
            if (ModelState.IsValid)
            {
                db.SzczegolyZamowien.Add(szczegolyZamowienia);
                db.SaveChanges();

            }
            return RedirectToAction("ViewAll");

            ViewBag.DanieId = new SelectList(db.Dania, "DanieId", "NazwaDania");
            ViewBag.ZamowienieId = new SelectList(db.Zamowienia, "ZamowienieId", "ZamowienieId");
            return View(new Danie());
        }

        [HttpGet]
        public ActionResult ViewAll()
        {

            List<SzczegolyZamowienia> szczegolyZamowienia;
            szczegolyZamowienia = db.SzczegolyZamowien.ToList();
            return View(szczegolyZamowienia.ToList());

        }

        public ActionResult View(int id)
        {
            SzczegolyZamowienia szczegolyZamowienia;
            szczegolyZamowienia = db.SzczegolyZamowien.FirstOrDefault(c => c.SzczegolyZamowieniaId == id);
            return View(szczegolyZamowienia);
        }

        public ActionResult Edit(int id)
        {
            SzczegolyZamowienia szczegolyzamowienia;
            using (DatabaseContext db = new DatabaseContext())
            {
                szczegolyzamowienia = db.SzczegolyZamowien.FirstOrDefault(x => x.SzczegolyZamowieniaId == id);
            }
            return View(szczegolyzamowienia);
        }

        [HttpPost]
        public ActionResult Edit(SzczegolyZamowienia szczegolyzamowienia)
        {
            if (!ModelState.IsValid)
            {
                return View(szczegolyzamowienia);
            }
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Entry(szczegolyzamowienia).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            SzczegolyZamowienia szczegolyzamowienia;
            using (DatabaseContext db = new DatabaseContext())
            {
                szczegolyzamowienia = db.SzczegolyZamowien.FirstOrDefault(x => x.SzczegolyZamowieniaId == id);
            }
            return View(szczegolyzamowienia);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            SzczegolyZamowienia szczegolyzamowienia;
            using (DatabaseContext db = new DatabaseContext())
            {
                szczegolyzamowienia = db.SzczegolyZamowien.FirstOrDefault(x => x.SzczegolyZamowieniaId == id);
                db.SzczegolyZamowien.Remove(szczegolyzamowienia);
                db.SaveChanges();

            }
            return RedirectToAction("ViewAll");
        }
    }
}

     