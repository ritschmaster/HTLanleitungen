﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicService.Controllers
{
    public class MusicController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
