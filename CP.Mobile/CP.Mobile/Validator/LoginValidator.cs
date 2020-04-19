using CP.Mobile.Validator.CustomValidator;
using CP.Mobile.ValidatorEntities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Plugins.FluentValidation;
using Xamarin.Plugins.UnobtrusiveFluentValidation;

namespace CP.Mobile.Validator
{
    public class LoginValidator : EnhancedAbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleForProp(x => x.UserName)
                 .NotNull().NotEmpty().WithMessage("Kullanıcı adı boş gecilemez")
            .MinimumLength(5).WithMessage("Kullanıcı adı en az 5 karakterden oluşmalıdır")
            .MaximumLength(20).WithMessage("Kullanıcı adı en fazla 20 karakterden oluşmalı");
            //.SetValidator(new UserNameIsUnique());
            //.Must(IsUniqueUserName).WithMessage("Kullanıcı adı alınmış");

            
            RuleForProp(x => x.Password)
                .NotNull().NotEmpty().WithMessage("Parola boş geçilemez")
             .MinimumLength(5).WithMessage("Parola en az 5 karakterden oluşmalıdır")
             .MaximumLength(30).WithMessage("Parola en fazla 30 karakterden oluşmalı");

        }
       
    }
}
