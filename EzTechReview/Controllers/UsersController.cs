using EzTechReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzTechReview.Controllers
{
    public class UsersController : Controller
    {
        private EzTechReviewEntities db = new EzTechReviewEntities();


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Login(LoginUser login)
        {

            if (ModelState.IsValid)
            {
                var user = db.Users.Where(u => u.UserEmail.Equals(login.UserEmail)
                 && u.UserPassword.Equals(login.UserPassword)).FirstOrDefault();

                if (user != null)
                {
                    Session["UserSessionEmail"] = user.UserEmail;
                    Session["UserSessionID"] = user.UserID;
                    Session["UserSessionName"] = user.UserName;

                    //return RedirectToAction("UserDashboard", new { email = user.UserEmail });
                    //  return RedirectToAction("UserDashboard");
                    return RedirectToAction("Profile","Home", new { area = "" });

                }
                else
                {

                    ViewBag.Loginfailed = "User not found or Password mismatch";
                    return View();

                }

            }

            return View();
        }

    }
}