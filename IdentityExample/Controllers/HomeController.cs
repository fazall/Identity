using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }


        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Login()
        {

            return View("Index");
        }

        public IActionResult Login(string userName, string password)
        {

            return RedirectToAction("Index");
        }


        public IActionResult Register()
        {

            return RedirectToAction("Index");
        }
        public IActionResult Register(string userName, string password)
        {

            return RedirectToAction("Index");
        }

    }
}
