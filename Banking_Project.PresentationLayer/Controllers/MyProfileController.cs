﻿using Microsoft.AspNetCore.Mvc;

namespace Banking_Project.PresentationLayer.Controllers
{
    public class MyProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}