using restauracjaTI.Models;
using restauracjaTI.Models.DbModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace restauracjaTI.Controllers
{
    public class KlientController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: Zamowienie
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Klient klient)
        {
            if (ModelState.IsValid)
            {
                db.Klienci.Add(klient);
                db.SaveChanges();

            }
            return View(new Klient());
        }

        [HttpGet]
        public ActionResult ViewAll()
        {

            List<Klient> klient;
            klient = db.Klienci.ToList();
            return View(klient.ToList());

        }

        public ActionResult View(int id)
        {
            Klient klient;
            klient = db.Klienci.FirstOrDefault(c => c.KlientId == id);
            return View(klient);
        }

        public ActionResult Edit(int id)
        {
            Klient klient;
            klient = db.Klienci.FirstOrDefault(c => c.KlientId == id);
            return View(klient);
        }

        [HttpPost]
        public ActionResult Edit(Klient klient)
        {
            if (!ModelState.IsValid)
            {
                return View(klient);
            
            }

            db.Entry(klient).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("ViewAll");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Klient klient;
            klient = db.Klienci.FirstOrDefault(c => c.KlientId == id);
            return View(klient);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Klient zamowienie;
            zamowienie = db.Klienci.FirstOrDefault(c => c.KlientId == id);
            db.Klienci.Remove(zamowienie);
            db.SaveChanges();
            return RedirectToAction("ViewAll");
        }
    }
}