using EzTechReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzTechReview.Controllers
{
    public class ReviewDetailsController : Controller
    {

        private EztechreviewEntities db = new EztechreviewEntities();


        // GET: ReviewDetails
        public ActionResult ReviewDetails()
        {


            /* 
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
             */
            return View();
        }
    }
}