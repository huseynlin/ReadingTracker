using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ReadingTracker.Models;
using ReadingTracker.Services;

namespace ReadingTracker.Controllers
{
    public class AccountController : Controller
    {
        private readonly JsonDataService _dataService;

        public AccountController(JsonDataService dataService)
        {
            _dataService = dataService;
        }

        // --- QEYDİYYAT ---
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                var users = _dataService.GetUsers();
                if (users.Any(u => u.Username == model.Username))
                {
                    ModelState.AddModelError("", "Bu istifadəçi adı artıq mövcuddur!");
                    return View(model);
                }

                users.Add(model);
                _dataService.SaveUsers(users);
                return RedirectToAction("Login");
            }
            return View(model);
        }

        // --- GİRİŞ ---
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var users = _dataService.GetUsers();
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // İstifadəçini sistemə "Cookie" ilə daxil edirik
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.Username)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Book"); // Giriş etdisə kitablarına getsin
            }

            ModelState.AddModelError("", "İstifadəçi adı və ya şifrə yanlışdır!");
            return View();
        }

        // --- ÇIXIŞ ---
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}