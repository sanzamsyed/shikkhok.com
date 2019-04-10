using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KnowYourProfDesign.Models;

namespace KnowYourProfDesign.Controllers
{
    public class AdminReviewController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: AdminReview
        public ActionResult Index()
        {
            if (Session["isAdmin"] != null)
                return View(db.Reviews.ToList());
            else
                return RedirectToAction("Index", "Home");
        }

        // GET: AdminReview/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: AdminReview/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminReview/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewID,UserID,TeacherID,Username,TeacherName,ReviewDate,ReviewText")] Review review)
        {
            var test = "Empty";
            try
            {
                test = Session["Username"].ToString();
            }
            catch (Exception e)
            {

            }
            try
            {
                if (review != null)
                {
                    review.ReviewDate = DateTime.Now;
                    review.Username = test;


                }
                if (ModelState.IsValid)
                {
                    db.Reviews.Add(review);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            catch (Exception e)
            {

            }

            return View(review);
        }

        // GET: AdminReview/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: AdminReview/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewID,UserID,TeacherID,Username,TeacherName,ReviewDate")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(review);
        }

        // GET: AdminReview/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: AdminReview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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


        public ActionResult ShowRelatedReviews()
        {

            return View(db.Reviews.ToList());
        }

        public ActionResult PostReview()
        {
            return View();
        }


        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostReview([Bind(Include = "ReviewID,UserID,TeacherID,Username,TeacherName,ReviewDate,ReviewText")] Review review)
        {
  
            if (ModelState.IsValid)
            {
                try
                {

                    if (review != null)
                    {
                        review.ReviewDate = DateTime.Now;
                        review.Username = Session["Username"].ToString();
                        review.UserID = 1;
                        review.TeacherID = 2;
                        review.TeacherName = Session["MasterName"].ToString();
                        

                    }


               
                    db.Reviews.Add(review);
                    db.SaveChanges();


                }
                catch (Exception e) { 
                    return RedirectToAction("Index");
                }

                

            }





            return View(review);



        }
    }
}
