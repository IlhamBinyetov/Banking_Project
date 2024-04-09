using Banking_Project.EntityLayer.Concrete;
using Banking_Project.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Banking_Project.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;     
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel viewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.UserName,viewModel.Password,false,true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(viewModel.UserName);
                if (user.EmailConfirmed)
                {
                    return RedirectToAction("Index", "MyProfile");
                }  
            }
            return View();
        }
    }
}
