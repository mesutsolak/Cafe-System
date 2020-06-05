using CP.Mobile.Validator;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Plugins.FluentValidation;
using Xamarin.Plugins.UnobtrusiveFluentValidation;

namespace CP.Mobile.ValidatorEntities
{
    [FluentValidation.Attributes.Validator(typeof(PasswordForgetValidator))]
    public class PasswordForgetViewModel: AbstractValidationViewModel
    {
        public ValidatableProperty<string> Email { get; set; } = new ValidatableProperty<string>();

        protected override bool Validate()
        {
            return base.Validate();
        }

        public bool ModelResult()
        {
            return Validate();
        }
        public void ErrorClear()
        {
            Email.ClearError();
        }
    }
}
