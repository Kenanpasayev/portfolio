﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication15.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
