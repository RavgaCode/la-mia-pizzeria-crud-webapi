﻿using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria.Models;
using System.Diagnostics;

namespace la_mia_pizzeria.Controllers
{
    public class GuestController : Controller
    {
        public IActionResult Index()
        {
            ViewData["title"] = "Home";
            return View();
        }
    }
}