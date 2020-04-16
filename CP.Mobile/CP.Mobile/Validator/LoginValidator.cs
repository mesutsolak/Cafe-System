using CP.Mobile.ValidatorEntities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Plugins.FluentValidation;

namespace CP.Mobile.Validator
{
    public class LoginValidator : EnhancedAbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleForProp(x => x.UserName).NotNull().NotEmpty().WithMessage("İsim boş gecilemez")
                .Length(5, 10).WithMessage("sayı az");
        }
    }
}
