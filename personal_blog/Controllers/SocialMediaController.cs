using personal_blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using personal_blog.Models.Entity;

namespace personal_blog.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        SocialMediaRepository repo = new SocialMediaRepository();

        public ActionResult Index()
        {
            var degerler = repo.List(); 
            return View(degerler);
        }
     /*   public ActionResult updateSocailMedia(int id) {

        }*/

        [HttpGet]
        public ActionResult addSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addSocialMedia(TblSocialMedya t)
        {
            repo.Tadd(t);
            return RedirectToAction("Index");
        }
        public ActionResult deleteSocialMedia(int id)
        {
            /*var socail = repo.find(x => x.Id == id);
            repo.TDelete(socail);
            return RedirectToAction("Index");//ekeledikten sonra gene indeex sayfasına gitsin
            */
            var socail = repo.find(x => x.Id == id);
            socail.durum = false;
            repo.Tupdate(socail);
            return RedirectToAction("Index");//ekeledikten sonra gene indeex sayfasına gitsin
        }
        [HttpGet]
        public ActionResult updateSocialMedia(int id)
        {
            var social = repo.find(x => x.Id == id);
            return View(social);
        }

        [HttpPost]
        public ActionResult updateSocialMedia(TblSocialMedya t)
        {
            var social = repo.find(x => x.Id == t.Id);
            social.Ad = t.Ad;
            social.icon = t.icon;
            social.Link = t.Link;
            social.durum = true;
            repo.Tupdate(social);
            return RedirectToAction("Index");//ekeledikten sonra gene indeex sayfasına gitsin
        }


    }
}