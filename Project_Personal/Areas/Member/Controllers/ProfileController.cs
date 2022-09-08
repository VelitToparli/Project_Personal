using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Personal.Models;

namespace Project_Personal.Areas.Member.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Member/Profile

        PersonalDbEntities db = new PersonalDbEntities();


        public ActionResult Index()
        {
            var mail = Session["MemberMail"];
            ViewBag.data1 = db.TblMember.Where(x => x.MemberMail == mail.ToString()).Select(y => y.MemberName + " " + y.MemberSurname).FirstOrDefault();
            return View();
        }


        [HttpGet]
        public ActionResult EditProfile()
        {
            var mail = Session["MemberMail"];
            var values = db.TblMember.Where(x => x.MemberMail == mail.ToString()).ToList().FirstOrDefault();
            return View(values);
        }


        [HttpPost]
        public ActionResult EditProfile(TblMember p)
        {
            var mail = Session["MemberMail"];
            var values = db.TblMember.Where(x => x.MemberMail == mail.ToString()).ToList().FirstOrDefault();
            values.MemberName = p.MemberName;
            values.MemberSurname = p.MemberSurname;
            values.MemberPassword = p.MemberPassword;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

/*
 401 --> Yetkisiz Erişim İsteği
 404 --> Sayfa Bulunamadı Hatası
 **/