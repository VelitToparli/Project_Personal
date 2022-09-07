using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personal.Models;

namespace Project_Personal.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience

        PersonalDbEntities db = new PersonalDbEntities();
        public ActionResult Index()
        {
            var values = db.TblExperience.ToList();
            return View(values);
        }

        [HttpGet]

        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(TblExperience p)
        {
            db.TblExperience.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            var value = db.TblExperience.Where(x => x.ExperienceID == id).FirstOrDefault();
            db.TblExperience.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditExperience(int id)
        {
            var value = db.TblExperience.Where(x => x.ExperienceID == id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public ActionResult EditExperience()
        {
            return View();
        }
    }
}