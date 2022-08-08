using EzTechReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzTechReview.Controllers
{
    public class ProductsController : Controller
    {

        private EztechreviewEntities db = new EztechreviewEntities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }
    }
}