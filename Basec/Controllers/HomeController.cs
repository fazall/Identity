using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basec.Controllers
{
    public class HomeController : Controller
    {
       public IActionResult Index()
        {
         
            return View();
        }   
        
        
        [Authorize(Roles ="Admin",Policy ="UMS:Create")]

        public IActionResult Secret()
        {
            return View();
        }
        
        public IActionResult Authenticate()
        {

            return RedirectToAction("Index");
        }



    }
}
