using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProgBlog.Models;

namespace ProgBlog.Controllers
{
    public class UsersController : Controller
    {
        private BlogEntities db = new BlogEntities();

        // GET: Users
        public ActionResult Registrate()
        {
            return View();
        }

        public ActionResult Index(int? id)
        {
            int userid = Convert.ToInt32(Session["UserId"]);
            var posts = db.Posts.Where(p => p.UserId == id).Select(p => p);
            ViewBag.AuthorId=RouteData.Values["id"];
            //if (id!=userid) {
            //    ViewBag.Message ="neok";
            //}
            //else
            //{
            //    ViewBag.Message = "";
            //}
            return View(posts.ToList());
        }

        // GET: Users/Details/5
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

            
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrate( Users users)
        {
            var v = db.Users.Where(a => a.Username.Equals(users.Username) || a.Email.Equals(users.Email)).FirstOrDefault();
            if (ModelState.IsValid && v == null)
            {

                db.Users.Add(users);
                db.SaveChanges();

                return RedirectToAction("Login", "Users");
            }
            else
            {
                ViewBag.Message = "You have been already registrated with this email or this Username have already used";
                return View(users);
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Login(Users user)
        {
            var v = db.Users.Where(a => a.Username.Equals(user.Username) && a.Password.Equals(user.Password)).FirstOrDefault();
            if (v == null)
            {
                ViewBag.Message = "You enter invalid username or password";
                return View();


            }
            else
            {
                Session["UserId"] = v.Id.ToString();
                Session["LogedUserName"] = v.Username.ToString();

                return RedirectToAction("Index", new { id = Convert.ToInt32(Session["UserId"]) });
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Posts");
        }



        // GET: Users/Edit/5
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Users users, HttpPostedFileBase upload)
        {
           
                if (ModelState.IsValid)
            {
                if (upload != null)
                {
                    Int32 length = upload.ContentLength;
                    byte[] tempImage = new byte[length];
                    upload.InputStream.Read(tempImage, 0, length);
                    users.Avatar = tempImage;
                }

              
                else { users.Avatar = db.Users.Where(u => u.Id == users.Id).Select(u => u.Avatar).First(); }
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public JsonResult IsUserExists(string UserName)
        {
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
            return Json(!db.Users.Any(x => x.Username == UserName), JsonRequestBehavior.AllowGet);
        }
    }
}
