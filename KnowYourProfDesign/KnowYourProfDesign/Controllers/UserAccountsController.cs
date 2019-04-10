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
    public class UserAccountsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(UserAccount user)
        {
            using (MyDbContext db = new MyDbContext())
            {

                var loginSuccess = false;

                try
                {

                    var usr = db.userAccount.Single(u => u.Username == user.Username && u.Password == user.Password);
                                                    

                    if (usr != null)
                    {

                        if(usr.FullName.ToString() == "admin" && usr.Password.ToString() == "admin")
                        {
                            Session["isAdmin"] = true;
                        } 

                        Session["UserID"] = usr.UserID.ToString();
                        Session["Username"] = usr.Username.ToString();
                        try
                        {
                            Session["FullName"] = usr.FullName.ToString();
                            Session["Email"] = usr.Email.ToString();
                        }
                        catch(Exception e)
                        {

                        }
                        loginSuccess = true;

                        return RedirectToAction("LoggedIn");
                    }






                }

                catch (InvalidOperationException e)
                {

                }

                if (!loginSuccess)
                {
                    
                    ViewBag.Message = "Incorrect Combination!";
                }
            }

            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            bool registerSuccess = false;
            if (ModelState.IsValid)
            {
                using (MyDbContext db = new MyDbContext())
                {
                    try
                    {
                        db.userAccount.Add(account);
                        db.SaveChanges();
                        registerSuccess = true;
                    }

                    catch(Exception e)
                    {

                    }
                }

                ModelState.Clear();
                if(registerSuccess)
                ViewBag.Message = account.FullName + " " + " thank you for registration";
                else
                {
                    ViewBag.Message = "Try again with a different username or email";
                }
            }

            return View();


        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }








        // GET: UserAccounts
        public ActionResult Index()
        {
            return View(db.userAccount.ToList());
        }

        // GET: UserAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.userAccount.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // GET: UserAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,FirstName,LastName,Email,Username,Password,ConfirmPassword")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.userAccount.Add(userAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userAccount);
        }

        // GET: UserAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.userAccount.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // POST: UserAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FirstName,LastName,Email,Username,Password,ConfirmPassword")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAccount);
        }

        // GET: UserAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.userAccount.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }




        // POST: UserAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAccount userAccount = db.userAccount.Find(id);
            db.userAccount.Remove(userAccount);
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
    }
}
