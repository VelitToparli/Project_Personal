using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personal.Models;

namespace Project_Personal.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial

        PersonalDbEntities db = new PersonalDbEntities();

        public ActionResult Index()
        {
            var values = db.TblTestimonial.ToList();
            return View(values);
        }

        [HttpGet]

        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonial p)
        {
            db.TblTestimonial.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = db.TblTestimonial.Where(x => x.TestimonialID == id).FirstOrDefault();
            db.TblTestimonial.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditTestimonial(int id)
        {
            var value = db.TblTestimonial.Where(x => x.TestimonialID == id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public ActionResult EditTestimonial()
        {
            return View();
        }
    }
}