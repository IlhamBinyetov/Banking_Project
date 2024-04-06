using Banking_Project.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Banking_Project.PresentationLayer.Controllers
{
	public class ConfirmMailController : Controller
	{
		[HttpGet]
		public IActionResult Index(int id)
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(ConfirmMailViewModel viewModel)
		{
			return View();
		}
	}
}
