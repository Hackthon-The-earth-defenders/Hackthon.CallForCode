using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackthon.Controllers
{
   //[Authorize]
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
