using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FutureValueCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutureValueCalculator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.FutureValue = "";
            return View();
        }

        [HttpPost]
        public IActionResult Index(FutureValueModel fv)
        {
            if (ModelState.IsValid) 
            { 
            ViewBag.FutureValue = fv.Calculate().ToString("c2"); //FORMAT THE RETURNING VALUE IN 2 DECIMAL POINTS
            }
            else
            {
                ViewBag.FutureValue = "";
            }
            return View();
        }

    }
}
