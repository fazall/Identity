using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public HomeController(
               UserManager<IdentityUser> userManager,
               SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {

            return View();
        }


        public IActionResult Secret()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = await userManager.FindByNameAsync(userName);
            if(user != null)
            {
               var signInResult = await signInManager.PasswordSignInAsync(user, password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Register()
        {

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Register(string userName, string password)
        {
            var user = new IdentityUser
            {
                UserName = userName,
                Email = userName,
              
            };
            var result = await userManager.CreateAsync(user);

            if(result.Succeeded)
            {
                    var signInResult = await signInManager.PasswordSignInAsync(user, password, false, false);

                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                
            }
            return RedirectToAction("Index");
        }

       public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index");
        }

    }
}
