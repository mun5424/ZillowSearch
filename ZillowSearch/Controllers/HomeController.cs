﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ZillowSearch.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchInfo()
        {
            ViewBag.Message = "FUCK";
            return View();

        }
    }
}
