using EzTechReview.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzTechReview.Controllers
{
    public class AdminsController : Controller
    {

        LoginUser abc = new LoginUser();
        // GET: Admins
        private EztechreviewEntities db = new EztechreviewEntities();

        // GET: Admins
        [HttpGet]
        public ActionResult AdminLogin()
        {
            // if (Session["AdminSessionEmail"] != null)

            //  Response.Redirect("~/Home/Index");
            return View();

        }

        [HttpPost]
        public ActionResult Auth(Admin adminModel)
        {
            using (EztechreviewEntities db = new EztechreviewEntities())
            {
                var adminDetails = db.Admins.Where(x => x.AdminEmail == adminModel.AdminEmail && x.AdminPassword == adminModel.AdminPassword).FirstOrDefault();

                if (adminDetails == null)
                {
                    adminModel.LoginErrorMessage = "wrong email or password";
                    return View("AdminLogin", adminModel);

                }
                else
                {
                    Session["AdminSessionEmail"] = adminDetails.AdminEmail;

                    return RedirectToAction("AdminDashboard");
                }
            }
        }

        public ActionResult AdminDashboard()
        {
            var total_review = ("SELECT COUNT(*) FROM Reviews");

            try
            {
                using (SqlConnection connection = new SqlConnection(abc.ConString))
                //abc from login.cs
                {
                    SqlCommand cm = new SqlCommand(total_review, connection);
                    connection.Open();
                    total_review = cm.ExecuteScalar().ToString();
                }
            }
            catch (Exception e)
            {
                total_review = e.ToString();
            }

            ViewBag.review = total_review;

            var total_user = ("SELECT COUNT(*) FROM Users");

            try
            {
                using (SqlConnection connection = new SqlConnection(abc.ConString))
                //abc from login.cs
                {
                    SqlCommand cm = new SqlCommand(total_user, connection);
                    connection.Open();
                    total_user = cm.ExecuteScalar().ToString();
                }
            }
            catch (Exception e)
            {
                total_user = e.ToString();
            }
            ViewBag.user = total_user;

            var total_Product = ("SELECT COUNT(*) FROM Products");

            try
            {
                using (SqlConnection connection = new SqlConnection(abc.ConString))
                //abc from login.cs
                {
                    SqlCommand cm = new SqlCommand(total_Product, connection);
                    connection.Open();
                    total_Product = cm.ExecuteScalar().ToString();
                }
            }
            catch (Exception e)
            {
                total_Product = e.ToString();
            }

            ViewBag.product = total_Product;

            var total_category = ("SELECT COUNT(*) FROM Categories");

            try
            {
                using (SqlConnection connection = new SqlConnection(abc.ConString))
                //abc from login.cs
                {
                    SqlCommand cm = new SqlCommand(total_category, connection);
                    connection.Open();
                    total_category = cm.ExecuteScalar().ToString();
                }
            }
            catch (Exception e)
            {
                total_category = e.ToString();
            }
            ViewBag.category = total_category;




            var total_issue = ("SELECT COUNT(*) FROM Issues");
            try
            {
                using (SqlConnection connection = new SqlConnection(abc.ConString))
                //abc from login.cs
                {
                    SqlCommand cm = new SqlCommand(total_issue, connection);
                    connection.Open();
                    total_issue = cm.ExecuteScalar().ToString();
                }
            }
            catch (Exception e)
            {
                total_issue = e.ToString();
            }
            ViewBag.issue = total_issue;

            var total_pending = ("SELECT COUNT(*) FROM Pendings");

            try
            {
                using (SqlConnection connection = new SqlConnection(abc.ConString))
                //abc from login.cs
                {
                    SqlCommand cm = new SqlCommand(total_pending, connection);
                    connection.Open();
                    total_pending = cm.ExecuteScalar().ToString();
                }
            }
            catch (Exception e)
            {
                total_pending = e.ToString();
            }
            ViewBag.pending = total_pending;

            return View();
        }
    }
}