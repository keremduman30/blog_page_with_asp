using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using personal_blog.Models.Entity;
using System.Web.Security;
namespace personal_blog.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin t)
        {
            DbCvEntities db = new DbCvEntities();
            var userInfo = db.TblAdmin.FirstOrDefault(x => x.userName == t.userName && x.password == t.password);//eger bu geriye
            //bir sey dondururse demekki eşlesmis ama null donerse demekki hatalı oyuzdenn kontrol null uzerinden olcak
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.userName, false);
                Session["userName"] = userInfo.userName.ToString();
                return RedirectToAction("Index", "Education");
            }
            else {
                return RedirectToAction("Index","Login");

            }
        }
        public ActionResult LogOut() {
            FormsAuthentication.SignOut();//cıkıs yapıyoz
            Session.Abandon();//ve session kayıtlarını kaladırıyoruz
            return RedirectToAction("Index", "Login");
        }
    }
}