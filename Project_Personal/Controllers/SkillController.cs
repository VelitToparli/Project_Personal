using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personal.Models;

namespace Project_Personal.Controllers
{
    public class SkillController : Controller
    {
        PersonalDbEntities db = new PersonalDbEntities();
        // GET: Skill
        public ActionResult Index()
        {
            var values = db.TblSkill.ToList();
            return View(values);
        }

        [HttpGet]

        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill( TblSkill p)
        {
            db.TblSkill.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = db.TblSkill.Where(x => x.SkillID == id).FirstOrDefault();
            db.TblSkill.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var value = db.TblSkill.Where(x => x.SkillID == id).FirstOrDefault();
            return View(value);
        }

        [HttpPost]
        public ActionResult EditSkill()
        {
            return View();
        }

    }
}