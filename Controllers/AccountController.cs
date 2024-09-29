using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProductDosageApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Tutaj zaimplementuj swoją logikę weryfikacji użytkownika, np. sprawdzenie w bazie danych
            if (username == "admin" && password == "password") // Prosta weryfikacja
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // Można skonfigurować opcje, np. zapamiętanie logowania, czas wygaśnięcia itd.
                    // do tej metody dodamy poznie autoryzacjie
                };

                // Zalogowanie użytkownika
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home"); // Po udanym logowaniu przekieruj na stronę główną
            }

            // Jeśli logowanie się nie powiedzie
            ViewBag.ErrorMessage = "falsches Login oder Passwort";
            return View();
        }

        // GET: /Account/Logout
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            // Wylogowanie użytkownika
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
