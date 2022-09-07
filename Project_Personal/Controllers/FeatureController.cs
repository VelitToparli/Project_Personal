using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personal.Models;

namespace Project_Personal.Controllers
{
    public class FeatureController : Controller
    {
        // GET: Feature

        PersonalDbEntities db = new PersonalDbEntities();

        public ActionResult Index()
        {
            var values = db.TblFeature.ToList();
            return View(values);
        }
    }
}