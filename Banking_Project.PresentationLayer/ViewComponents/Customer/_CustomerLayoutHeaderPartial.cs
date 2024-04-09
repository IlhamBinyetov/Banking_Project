using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Banking_Project.PresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View(); 
        }
    }
}
