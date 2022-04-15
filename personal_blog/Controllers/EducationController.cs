using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using personal_blog.Models.Entity;
using personal_blog.Repositories;


namespace personal_blog.Controllers
{
    public class EducationController : Controller
    {
        EduationRepository repo = new EduationRepository();

        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult addEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addEducation(TblEducation t)
        {
            if (!ModelState.IsValid)
            {
                return View("addEducation");
            }
            t.date = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString();
            repo.Tadd(t);
            return RedirectToAction("Index");//ekeledikten sonra gene indeex sayfasına gitsin


        }
        public ActionResult deleteEducation(int id) {
            var education = repo.find(x => x.Id == id);
            repo.TDelete(education);
            return RedirectToAction("Index");//ekeledikten sonra gene indeex sayfasına gitsin
        }
        //update
        [HttpGet]
        public ActionResult updateEducation(int id)
        {
            var education = repo.find(x => x.Id == id);
            return View(education);
        }

        [HttpPost]
        public ActionResult updateEducation(TblEducation t)
        {
            var education = repo.find(x => x.Id == t.Id);
            education.title = t.title;
            education.subtitle = t.subtitle;
            education.subtitle2 = t.subtitle2;
            education.date = DateTime.Parse(DateTime.Now.ToShortDateString()).ToString();
            repo.Tupdate(education);
            return RedirectToAction("Index");//ekeledikten sonra gene indeex sayfasına gitsin
        }
    }
    
}