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
    public class MasterController : Controller
    {
        private MyDbContext db = new MyDbContext();
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowTeacherList()
        {

        

            return View(db.Masters.OrderBy(s => s.Name).ToList());
        }

        public ActionResult ViewTeachersProfile(int? id)
        {
            using (MyDbContext db = new MyDbContext())
            {

                try
                {

                    var usr = db.Masters.Single(u => u.MID == id);


                    if (usr != null)
                    {



                        Session["MID"] = usr.MID.ToString();
                        Session["MasterName"] = usr.Name.ToString();
                        try
                        {
                            Session["MasterStatus"] = usr.Status.ToString();
                            Session["MasterEmail"] = usr.Email.ToString();
                            Session["Department"] = usr.Department.ToString();
                            Session["Course"] = usr.Course.ToString();
                            Session["MasterPhone"] = usr.Phone.ToString();
                        }
                        catch (Exception e)
                        {

                        }
                 
                        return RedirectToAction("TeachersProfile");
                    }






                }

                catch (InvalidOperationException e)
                {

                }
            }
            return View();

        }


        public ActionResult TeachersProfile()
        {
            if (Session["MID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("ShowTeacherList");
            }
        }





        //public ActionResult PostReview()
        //{
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult PostReview([Bind(Include = "ReviewID,UserID,TeacherID,Username,TeacherName,ReviewDate,ReviewText")] Review review)
        //{
        //    var test = "Empty";
        //    var teacherID = 0;
        //    var userID = 0;
        //    var teacherName = "Empty";
        //    try
        //    {
        //        test = Session["Username"].ToString();
        //        teacherName = Session["MasterName"].ToString();
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    try
        //    {
        //        if (review != null)
        //        {
        //            review.ReviewDate = DateTime.Now;
        //            review.Username = test;
        //            review.UserID = 1;
        //            review.TeacherID = 2;
        //            review.TeacherName = teacherName;



        //        }
        //        if (ModelState.IsValid)
        //        {
        //            db.Reviews.Add(review);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }

        //    catch (Exception e)
        //    {

        //    }

        //    return View(review);
        //}
    }
}