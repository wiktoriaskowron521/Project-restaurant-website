using restauracjaTI.Models;
using restauracjaTI.Models.DbModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace restauracjaTI.Controllers
{
    public class RodzajDaniaController : Controller
    {
        // GET: RodzajDania
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new RodzajDania());
        }

        [HttpPost]
        public ActionResult Create(RodzajDania rodzajdania)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    db.RodzajDan.Add(rodzajdania);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
            return View(new RodzajDania());
        }

        [HttpGet]
        public ActionResult ViewAll()
        {
            List<RodzajDania> rodzajdania;
            using (DatabaseContext db = new DatabaseContext())
            {
                rodzajdania = db.RodzajDan.ToList();
            }
            return View(rodzajdania);
        }

        public ActionResult View(int id)
        {
            RodzajDania rodzajdania;
            using (DatabaseContext db = new DatabaseContext())
            {
                rodzajdania = db.RodzajDan.FirstOrDefault(x => x.RodzajDaniaId == id);
            }
            return View(rodzajdania);
        }

        public ActionResult Edit(int id)
        {
            RodzajDania rodzajdania;
            using (DatabaseContext db = new DatabaseContext())
            {
                rodzajdania = db.RodzajDan.FirstOrDefault(x => x.RodzajDaniaId == id);
            }
            return View(rodzajdania);
        }

        [HttpPost]
        public ActionResult Edit(RodzajDania rodzajdania)
        {
            if (!ModelState.IsValid)
            {
                return View(rodzajdania);
            }
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Entry(rodzajdania).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            RodzajDania rodzajdania;
            using (DatabaseContext db = new DatabaseContext())
            {
                rodzajdania = db.RodzajDan.FirstOrDefault(x => x.RodzajDaniaId == id);
            }
            return View(rodzajdania);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            RodzajDania rodzajdania;
            using (DatabaseContext db = new DatabaseContext())
            {
                rodzajdania = db.RodzajDan.FirstOrDefault(x => x.RodzajDaniaId == id);
                db.RodzajDan.Remove(rodzajdania);
                db.SaveChanges();

            }
            return RedirectToAction("ViewAll");
        }



    }
}