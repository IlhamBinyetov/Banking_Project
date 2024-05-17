using Microsoft.AspNetCore.Mvc;

namespace Banking_Project.PresentationLayer.Controllers
{
    public class MylastProcessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
