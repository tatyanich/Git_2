using ProgBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProgBlog.Controllers
{
    public class UsersController : Controller
    {
        BlogEntities db = new BlogEntities();
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrate(Users user)
        {
            if (ModelState.IsValid)
            {
               
                               
                db.Users.Add(user);
                db.SaveChanges();
                ModelState.Clear();
                user = null;
                ViewBag.Message = "Successfully Registrate";
            }
            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Login(Users user)
        {
            var v = db.Users.Where(a => a.Username.Equals(user.Username) && a.Password.Equals(user.Password)).FirstOrDefault();
            if (v == null)
            {   ViewBag.Message = "You enter invalid username or password";
                return View();
                

            }
            else
            {
                Session["UserId"] = v.ID.ToString();
                Session["LogedUserName"] = v.Username.ToString();
                return RedirectToAction("Index", "Home");
            }
    }

       public ActionResult Logout()
       {
           Session.Clear();
           return RedirectToAction("Index", "Home");
       }

       public ActionResult Details(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           Users users = db.Users.Find(id);
           if (users == null)
           {
               return HttpNotFound();
           }
           return View(users);
       }

       public ActionResult Edit(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           Users users = db.Users.Find(id);
           if (users == null)
           {
               return HttpNotFound();
           }
           return View(users);
       }

       // POST: Users/Edit/5
       // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
       // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
       
       [ValidateInput(false)]
       public ActionResult Edit(Users users)
       {
           
           if (ModelState.IsValid)
           {
               db.Entry(users).State = EntityState.Modified;
               db.SaveChanges();
               return RedirectToAction("Index");
           }
           var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
           return View(users);
       }
    }
}