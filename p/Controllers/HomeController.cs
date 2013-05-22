using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p.Models;
using Mvc.Mailer;
using p.Mailers;

namespace p.Controllers
{
    public class HomeController : Controller
    {
        private IUserMailer _userMailer = new UserMailer();
        public IUserMailer UserMailer
        {
            get { return _userMailer; }
            set { _userMailer = value; }
        }
        
        public ActionResult Index()
        {
            ViewBag.Message = "welcome";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "us";

            ContextP db = new ContextP();
            var whats = db.whatsnews.OrderByDescending(t => t.WorkTime).ToList();
            return View(whats);

            //return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "info";

            return View();
        }
        public ActionResult SendWelcomeMessage()
        {
            UserMailer.Welcome().Send(); //Send() extension method: using Mvc.Mailer
            return RedirectToAction("Index");
        }
    }
}
