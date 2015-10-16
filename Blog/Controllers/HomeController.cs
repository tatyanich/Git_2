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

            }

    
}