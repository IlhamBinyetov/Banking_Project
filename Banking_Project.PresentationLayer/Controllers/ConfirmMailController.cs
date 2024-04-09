using Banking_Project.EntityLayer.Concrete;
using Banking_Project.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Banking_Project.PresentationLayer.Controllers
{
	public class ConfirmMailController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
				_userManager = userManager;
        }

        [HttpGet]
		public IActionResult Index()
		{
			var value = TempData["Mail"];
            if (value != null)
            {
                ViewBag.v = value;
            }
			//confirmMailViewModel.Mail = value.ToString();
            return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(ConfirmMailViewModel viewModel)
		{
            var value = TempData["Mail"];
			var user = await _userManager.FindByEmailAsync(value.ToString());

			if(user.ConfirmCode == viewModel.ConfirmCode)
			{
				user.EmailConfirmed = true;
				await _userManager.UpdateAsync(user);
				return RedirectToAction("Index","MyProfile");
			}
            return View();
		}
	}
}
