using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using personal_blog.Models.Entity;
using personal_blog.Repositories;

namespace personal_blog.Controllers
{
    public class ComminucationController : Controller
    {
        ComminucationRepository repo = new ComminucationRepository();

        // GET: Comminucation
        public ActionResult Index()
        {
            var degerler = repo.List();
            return View(degerler);
        }
    }
}