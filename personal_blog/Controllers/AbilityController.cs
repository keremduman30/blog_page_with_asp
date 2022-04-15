using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using personal_blog.Models.Entity;
using personal_blog.Repositories;

namespace personal_blog.Controllers
{
    public class AbilityController : Controller
    {
        AbilityRepository repo = new AbilityRepository();
        // GET: Ability
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult AddAbility(){
            return View();

        }
        [HttpPost]
        public ActionResult addAbility(TblAbility t)
        {
            repo.Tadd(t);
            return RedirectToAction("Index");//ekeledikten sonra gene indeex sayfasına gitsin

        }
        public ActionResult deleteAbility(int id) {
            var  ability = repo.find(x => x.Id == id);
            repo.TDelete(ability);
            return RedirectToAction("Index");//ekeledikten sonra gene indeex sayfasına gitsin
        }
        [HttpGet]
        public ActionResult updateAbility(int id)
        {
            var ability = repo.find(x => x.Id == id);
            return View(ability);
        }

        [HttpPost]
        public ActionResult updateAbility(TblAbility t)
        {
            var ability = repo.find(x => x.Id == t.Id);
            ability.ability = t.ability;
            ability.rate = t.rate;
            repo.Tupdate(ability);
            return RedirectToAction("Index");//ekeledikten sonra gene indeex sayfasına gitsin
        }
    }
}