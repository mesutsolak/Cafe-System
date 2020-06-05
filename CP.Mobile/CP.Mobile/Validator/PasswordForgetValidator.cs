using CP.Mobile.ValidatorEntities;
using System;
using FluentValidation;
using System.Collections.Generic;
using System.Text;
using Xamarin.Plugins.FluentValidation;

namespace CP.Mobile.Validator
{
    public class PasswordForgetValidator : EnhancedAbstractValidator<PasswordForgetViewModel>
    {
        public PasswordForgetValidator()
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleForProp(x => x.Email)
                .NotNull().NotEmpty().WithMessage("Email boş gecilemez");
        }
    }
}
