using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using KnowYourProfDesign.Models;

namespace KnowYourProfDesign.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: ContactUs

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ContactUs contact)
        {
            bool contactSuccess = false;
            ViewBag.Message = "";
            if (ModelState.IsValid)
            {
                using (MyDbContext db = new MyDbContext())
                {
                    try
                    {
                        db.ContactUs.Add(contact);
                        db.SaveChanges();
                        contactSuccess = true;
                    }

                    catch (Exception e)
                    {

                    }
                }

                ModelState.Clear();


                if (contactSuccess)
                {
                    //ViewBag.Message = " thank you for registration";
                    TempData["AlertMessage"] = "Thank you for your feedback!";
                    return RedirectToAction("SomeAction");
                }
                else
                {
                    //ViewBag.Message = "Try again with a different username or email";
                    TempData["AlertMessage"] = "Yeet, something went wrong!";
                    return RedirectToAction("SomeAction");
                }
            }

            return View();
        }




        public ActionResult SomeAction()
        {
            return View();
        }

    }

    
}