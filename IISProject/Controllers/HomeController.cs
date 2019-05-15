using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IISProject.Models;

namespace IISProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("Admin") && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Products");
            }
            if (User.Identity.IsAuthenticated && !User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "ProductsForUser");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
