using EzTechReview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace EzTechReview.Controllers
{
    public class QandAController : Controller
    {
        private EztechreviewEntities db = new EztechreviewEntities();

        LoginUser abc = new LoginUser();
        // GET: QandA
        public ActionResult Ques()
        {
            // int id = Convert.ToInt32(Session["UserSessionID"]);

            var que = db.Questions.SqlQuery("Select *from Questions")
                  .ToList<Question>();


            ViewData["QUE"] = que;
            return View();
        }

        [HttpPost]
        public ActionResult Ques(Question question)
        {

            question.UserID = Convert.ToInt32(Session["UserSessionID"]);
            question.QuestionDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("ques", "QandA");
            }

            return View(question);
        }

        public ActionResult Ques_de(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Session["Question_Id"] = id;
            Question q = db.Questions.Find(id);
            if (q == null)
            {
                return HttpNotFound();
            }

            return View(q);

        }



        [HttpGet]
        public ActionResult Ans()
        {
            //  var re = db.Reviews.Include(r => r.Product).Include(r => r.User).Where(m => m.ProductID.Equals(id)).ToList();

            int id = Convert.ToInt32(Session["Question_Id"]);

            var answ = db.Answers.Include(i => i.Question).Include(i => i.User).Where(i => i.QuestionID.Equals(id)).ToList();
            ViewData["ANS"] = answ;
            return View();
            //var answ = db.Answers.Include(a => a.Question).Include(a => a.User).Where(a => a.QuestionID.Equals(id)).ToList();

            // var answ = db.Answers.SqlQuery("Select  *from Answers").ToList<Answer>();

            // ViewData["ANS"] = answ;
            return View();

        }

        [HttpPost]
        public ActionResult Ans(Answer answer)
        {
            answer.UserID = Convert.ToInt32(Session["UserSessionID"]);
            answer.QuestionID = Convert.ToInt32(Session["Question_Id"]);
            answer.AnswerDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Answers.Add(answer);
                db.SaveChanges();
                return RedirectToAction("ans", "QandA");
            }

            return View(answer);
        }
    }
}