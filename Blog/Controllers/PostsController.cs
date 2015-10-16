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
    public class PostsController : Controller
    {
        private BlogEntities db = new BlogEntities();

        public ActionResult Autocomplete(string term)
        {
            var post = db.Posts.Where(p => p.Title.Contains(term)).Select(p => new { lable = p.Title });

            return Json(post, JsonRequestBehavior.AllowGet);
        }

        // GET: Posts
        public ActionResult Index(string searchstr = null)
        {
            var post = db.Posts.Include(p => p.Users).Where(p=> searchstr==null|| p.Title.Contains(searchstr));

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Posts", post.ToList());
            }
            return View(post.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posts post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "ID", "Username");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Posts post)
        {
            post.Datetime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index","Users");
            }

            //ViewBag.UserId = new SelectList(db.Users, "ID", "Username", post.UserId);
            return View(post);
        }



        [ValidateInput(true)]

        public ActionResult Comments(int id, string name, string message)
        {
            Posts post = GetPost(id);
            Comments comment = new Comments();

            comment.Posts = post;
            comment.Datetime = DateTime.Now;
            comment.Author = name;
            
            comment.Message = message;
            if (((comment.Author == "") && (comment.Message == "")) || (comment.Message == " "))
            {
                return RedirectToAction("Details", new
                {
                    id = id

                });
            }

            db.Comments.Add(comment);
            db.SaveChanges();


            // Here user object with updated data
            return RedirectToAction("Details", new
            {
                id = id

            });

        }




        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posts post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "ID", "Username", post.UserId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Title,Content")] Posts post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "ID", "Username", post.UserId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posts post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Posts post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index","Users");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        private Posts GetPost(int? id)
        {
            return id.HasValue ? db.Posts.Where(x => x.Id == id).First() : new Posts() { Id = -1 };

        }
    }
}
