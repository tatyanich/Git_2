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
            var post = db.Post.Where(p => p.Title.Contains(term)).Select(p => new { lable = p.Title });

            return Json(post, JsonRequestBehavior.AllowGet);
        }

        // GET: Posts
        public ActionResult Index(string searchstr = null)
        {
            var post = db.Post.Include(p => p.Users).Where(p => searchstr == null || p.Title.Contains(searchstr));

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
            Post post = db.Post.Find(id);
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
        public ActionResult Create(Post post)
        {
            post.DateTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Post.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index", "Users");
            }

            //ViewBag.UserId = new SelectList(db.Users, "ID", "Username", post.UserId);
            return View(post);
        }



        [ValidateInput(true)]

        public ActionResult Comments(int id, string name, string message)
        {
            Post post = GetPost(id);
            Comments comment = new Comments();

            comment.Post = post;
            comment.DateTime= DateTime.Now;
            comment.Author = name;

            comment.Content = message;
            if (((comment.Author == "") && (comment.Content == "")) || (comment.Content == " "))
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
            Post post = db.Post.Find(id);
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
        public ActionResult Edit(Post post)
        {
            post.DateTime = DateTime.Now;
          
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
            Post post = db.Post.Find(id);
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
            Post post = db.Post.Find(id);
            db.Post.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index", "Users");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        private Post GetPost(int? id)
        {
            return id.HasValue ? db.Post.Where(x => x.ID == id).First() : new Post() { ID = -1 };

        }
    }
}
