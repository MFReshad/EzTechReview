using EzTechReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzTechReview.Controllers
{
    public class CategoriesController : Controller
    {
        private EztechreviewEntities db = new EztechreviewEntities();


        // GET: Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        [HttpPost]
        public ActionResult Auth(Admin adminModel)
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
                return RedirectToAction("Categories");
            }
            return View();
        }


        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName")] Category category)
        {
            // Admin adminModel = new Admin();
            // var adminDetails = db.Admins.Where(x => x.AdminEmail == adminModel.AdminEmail && x.AdminPassword == adminModel.AdminPassword).FirstOrDefault();

            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }
    }
}