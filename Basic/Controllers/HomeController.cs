using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate()
        {
            var basicClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Hakan"),
                new Claim(ClaimTypes.Email, "hakan@basic.com"),
                new Claim("Basic.Example", "Example")
            };

            var licenseClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Hakan"),
                new Claim("DirivingLicense", "A+")
            };

            var basicIdentity = new ClaimsIdentity(basicClaims, "Basic Identity");
            var licenceIdentity = new ClaimsIdentity(licenseClaims, "Government");

            var userPrincipal = new ClaimsPrincipal(new[] { basicIdentity, licenceIdentity });

            HttpContext.SignInAsync(userPrincipal);

            return RedirectToAction("Index");
        }
    }
}
