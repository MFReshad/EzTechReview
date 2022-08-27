using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzTechReview.Controllers
{
    public class IssueController : Controller
    {
        // GET: Issue
        public ActionResult IssuesInProductDetails()
        {
            return View();
        }
    }
}