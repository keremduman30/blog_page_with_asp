using personal_blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using personal_blog.Models.Entity;
namespace personal_blog.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceRepository repo = new ExperienceRepository();
        // GET: Experience
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult addExperience() {
            return View();
        }
        [HttpPost]
        public ActionResult addExperience(TblExperience experience)
        {
            repo.Tadd(experience);
            return RedirectToAction("Index");//ekeledikten sonra gene indeex sayfasına gitsin
        }
        public ActionResult deleteExperience(int id) {
            TblExperience t = repo.find(x=>x.Id==id);
            repo.TDelete(t);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult getExperience(int id) {
            TblExperience t = repo.find(x => x.Id == id);
            return View(t);


        }
        [HttpPost]
        public ActionResult getExperience(TblExperience p)
        {
            TblExperience t = repo.find(x => x.Id == p.Id);
            t.title = p.title;
            t.subtitle = p.subtitle;
            t.explain = p.explain;
            t.date = p.date;
            repo.Tupdate(t);
            return RedirectToAction("Index");


        }
    }
}