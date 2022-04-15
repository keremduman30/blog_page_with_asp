using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using personal_blog.Models.Entity;

namespace personal_blog.Controllers
{
    public class DefaultController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        
        // GET: Default
        public ActionResult Index()
        {
            var degerler = db.TblAbout.ToList();
            return View(degerler);
        }

        public PartialViewResult Experience(){
            var degerler = db.TblExperience.ToList();
            return PartialView(degerler);
        }
       
          public PartialViewResult SocialMedia()
        {
            var degerler = db.TblSocialMedya.Where(x=>x.durum==true).ToList();
            return PartialView(degerler);
        }
            
        public PartialViewResult Education()
        {
            var degerler = db.TblEducation.ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Ability()
        {
            var degerler = db.TblAbility.ToList();
            return PartialView(degerler);
        }
        [HttpGet]
        public PartialViewResult Comminucation()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Comminucation(TblComminucation comminucation)
        {
            comminucation.date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblComminucation.Add(comminucation);//mail gonderirse tbliletisime bir veri eklenecek yani her mailde veri tabanına gitcek
            db.SaveChanges();//sonra degisikleri kaydet

            return PartialView();


        }
    }
}