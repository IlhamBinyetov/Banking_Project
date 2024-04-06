using Banking_Project.DtoLayer.Dtos.AppUserDtos;
using Banking_Project.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using NuGet.Configuration;

namespace Banking_Project.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager; 
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                int code = random.Next(100000, 1000000);

				AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.UserName,
                    Name = appUserRegisterDto.Name,
                    SurName = appUserRegisterDto.SurName,
                    Email = appUserRegisterDto.Email,
                    ConfirmCode = code
                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    // Mail Process
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Banking_Project", "ilhamgb@code.edu.az");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Confirm Code for registration: " + code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Banking_Project Confirm Code";
                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com",587,false);
                    client.Authenticate("ilhamgb@code.edu.az", "");
                    client.Send(mimeMessage);
                    client.Disconnect(true);
                    

                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
