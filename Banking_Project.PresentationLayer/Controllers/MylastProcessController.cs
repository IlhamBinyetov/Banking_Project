using Banking_Project.BusinessLayer.Abstract;
using Banking_Project.DataAccessLayer.Abstract;
using Banking_Project.DataAccessLayer.Concrete;
using Banking_Project.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Banking_Project.PresentationLayer.Controllers
{
    public class MylastProcessController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public MylastProcessController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService )
        {
            _userManager = userManager; 
            _customerAccountProcessService = customerAccountProcessService;
        }
        public async Task<IActionResult> Index()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var context = new Context();
            int id = context.CustomerAccounts.Where(x=>x.AppUserId == user.Id).Select(x=>x.CustomerAccountId).FirstOrDefault();

            var values = _customerAccountProcessService.TMyLastProcess(id);
            return View(values);
        }
    }
}
