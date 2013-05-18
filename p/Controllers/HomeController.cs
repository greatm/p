﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace p.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "welcome";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "us";

            //bDBContext db = new bDBContext();
            //var whats = db.whatsnews.OrderByDescending(t => t.WorkTime).ToList();
            //return View(whats);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "info";

            return View();
        }
    }
}
