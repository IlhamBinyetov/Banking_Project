using Banking_Project.DtoLayer.Dtos.AppUserDtos;
using Banking_Project.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Project.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("SurName can not be empty");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName can not be empty");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email can not be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can not be empty");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("ConfirmPassword can not be empty");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Please enter maximum 30 characters");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Name must be minimum 2 characters");
            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password).WithMessage("Password and ConfirmPassword are not same");
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Please enter correct email address");
        }
    }
}
