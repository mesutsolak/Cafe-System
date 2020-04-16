using CP.Mobile.ValidatorEntities;
using CP.ServiceLayer.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Plugins.FluentValidation;

namespace CP.Mobile.Validator
{
    public class UserValidator : EnhancedAbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleForProp(x => x.FirstName).NotNull().NotEmpty().WithMessage("İsim boş gecilemez")
                .Length(5,10).WithMessage("sayı az");
        }
      
    }
}
