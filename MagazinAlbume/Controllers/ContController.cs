using MagazinAlbume.Data;
using MagazinAlbume.Data.Static;
using MagazinAlbume.Data.ViewModels;
using MagazinAlbume.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagazinAlbume.Controllers
{
    public class ContController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppDbContext _context;

        public ContController(UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var rezultat = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (rezultat.Succeeded)
                    {
                        return RedirectToAction("Index", "Albume");
                    }
                }
                TempData["Error"] = "Datele introduse sunt gresite.Te rog incearca din nou!";
                return View(loginVM);
            }

            TempData["Error"] = "Datele introduse sunt gresite.Te rog incearca din nou!";
            return View(loginVM);
        }
    public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "Adresa de email este deja folosita";
                return View(registerVM);
            }

            var newUser = new User()
            {
                NumeUtilizator = registerVM.NumeUtilizator,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("RegisterCompleted");

        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Albume");
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            return View(); 
        }
    }
}
