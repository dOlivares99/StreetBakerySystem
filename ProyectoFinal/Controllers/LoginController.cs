﻿using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }

    }
}
