﻿using Microsoft.AspNetCore.Mvc;

namespace BookWormProject.Controllers
{
    public class ChapterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}