using Banking_Project.BusinessLayer.Abstract;
using Banking_Project.DataAccessLayer.Concrete;
using Banking_Project.DtoLayer.Dtos.CustomerAccountProcessDtos;
using Banking_Project.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Banking_Project.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto processDto)
        {
            var context = new Context();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberId = context.CustomerAccounts.Where(s => s.CustomerAccountNumber == processDto.ReceiverAccountNumber).Select(x => x.CustomerAccountId).FirstOrDefault();

            processDto.SenderId = user.Id;
            processDto.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            processDto.ProcessType = "Transfer";
            processDto.ReceiverId = receiverAccountNumberId;


           // _customerAccountProcessService.TInsert();

            return RedirectToAction("Index","Test");
        }
    }
}
