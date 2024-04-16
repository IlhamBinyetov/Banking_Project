using Microsoft.AspNetCore.Mvc;

namespace Banking_Project.PresentationLayer.Controllers
{
    public class MyAccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
