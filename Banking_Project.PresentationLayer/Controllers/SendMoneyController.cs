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
        public IActionResult Index(string mycurrency)
        {
            ViewBag.currency = mycurrency;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto processDto)
        {
            var context = new Context();

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberId = context.CustomerAccounts.Where(s => s.CustomerAccountNumber == processDto.ReceiverAccountNumber).Select(x => x.CustomerAccountId).FirstOrDefault();
            var senderAccountNumberId = context.CustomerAccounts.Where(x=>x.AppUserId == user.Id).Where(y=>y.CustomerAccountCurrency == "").Select(x => x.CustomerAccountId).FirstOrDefault();
  

            var values = new CustomerAccountProcess();
            values.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.SenderId = 1;
            values.ProcessType = "Transfer";
            values.ReceiverId = receiverAccountNumberId;
            values.Amount = processDto.Amount;
            values.Description = processDto.Description; 

           _customerAccountProcessService.TInsert(values);

            return RedirectToAction("Index","Test");
        }
    }
}
