using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personal.Models;

namespace Project_Personal.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education

        PersonalDbEntities db = new PersonalDbEntities();

        public ActionResult Index()
        {
            var values = db.TblEducation.ToList();
            return View(values);
        }


        [HttpGet]

        public ActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(TblEducation p)
        {
            db.TblEducation.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            var value = db.TblEducation.Where(x => x.EducationID == id).FirstOrDefault();
            db.TblEducation.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditEducation(int id)
        {
            var value = db.TblEducation.Where(x => x.EducationID == id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public ActionResult EditEducation()
        {
            return View();
        }

    }

}