﻿using Microsoft.AspNetCore.Mvc;

namespace Banking_Project.PresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutFooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}