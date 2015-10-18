using ProgBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProgBlog.Controllers
{
    public class HomeController : Controller
    {
        BlogEntities db = new BlogEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
           return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users u)
        {
           
                var v = db.Users.Where(a => a.Username.Equals(u.Username) && a.Password.Equals(u.Password)).FirstOrDefault();
                if (v != null)
                {
                FormsAuthentication.SetAuthCookie(v.Username, true);
                Session["LogedUserID"] = v.Id.ToString();
                    Session["LogedUserName"] = v.Username.ToString();
                    
                }
return View();
            }        

        public ActionResult Logout()
            {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }

    
}