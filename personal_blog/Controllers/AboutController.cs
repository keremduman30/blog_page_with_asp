using personal_blog.Models.Entity;
using personal_blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace personal_blog.Controllers
{
    public class AboutController : Controller
    {
        AboutRepository repo = new AboutRepository();

        // GET: About
        [HttpGet]
        public ActionResult Index()
        {
            var degeler = repo.List();
            return View(degeler);
        }
        [HttpPost]
        public ActionResult Index(TblAbout t)
        {

            var about = repo.find(x => x.Id == 1);
            about.name = t.name;
            about.surname = t.surname;
            about.adress = t.adress;
            about.mail = t.mail;
            about.telephone = t.telephone;
            about.explain = t.explain;
            about.image = t.image;

            repo.Tupdate(about);
            return RedirectToAction("Index");//ekeledikten sonra gene indeex sayfasına gitsin        }
        }
    }
}