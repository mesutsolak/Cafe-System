using CP.Mobile.Validator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Plugins.FluentValidation;
using Xamarin.Plugins.UnobtrusiveFluentValidation;

namespace CP.Mobile.ValidatorEntities
{
    [FluentValidation.Attributes.Validator(typeof(LoginValidator))]
    public class LoginViewModel : AbstractValidationViewModel
    {
        public ValidatableProperty<string> UserName { get; set; } = new ValidatableProperty<string>();
        public ValidatableProperty<string> Password { get; set; } = new ValidatableProperty<string>();

        protected override bool Validate()
        {
            return base.Validate();
        }

        public bool ModelResult()
        {
            return Validate();
        }

    }
}
