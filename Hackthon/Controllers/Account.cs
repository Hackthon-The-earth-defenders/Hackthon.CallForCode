﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Hackthon.Controllers
{
    public class Account : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}