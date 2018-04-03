using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Calculator.Models;
using Microsoft.AspNetCore.Hosting;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _env;
        public HomeController(IHostingEnvironment env)
        {
            _env = env;
        }

        public IActionResult Index()
        {
            CompoundInterest c = new CompoundInterest();
            if (
                HttpContext.Request.Query["p"].Count != 0
                && HttpContext.Request.Query["i"].Count != 0
                && HttpContext.Request.Query["t"].Count != 0
                && HttpContext.Request.Query["y"].Count != 0
            )
            {
                c.Principal = Convert.ToDouble(HttpContext.Request.Query["p"].ToString());
                c.InterestRate = Convert.ToDouble(HttpContext.Request.Query["i"].ToString());
                c.TimesCompounded = Convert.ToInt32(HttpContext.Request.Query["t"].ToString());
                c.Years = Convert.ToInt32(HttpContext.Request.Query["y"].ToString());
            }
            else
            {
                c.Principal = 1000;
                c.InterestRate = 5;
                c.TimesCompounded = 12;
                c.Years = 10;
            }

            ViewBag.Env = _env.EnvironmentName;

            return View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CompoundInterest c)
        {
            if (ModelState.IsValid)
            {
                var result = c.CompoundInterestCalculator();

                TempData["balance"] = result;

                return RedirectToAction("Index", new { p = c.Principal, i = c.InterestRate, t = c.TimesCompounded, y = c.Years });
            }

            return View(c);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
