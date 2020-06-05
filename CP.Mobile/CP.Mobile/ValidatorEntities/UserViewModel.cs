using CP.Mobile.Validator;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Plugins.FluentValidation;
using Xamarin.Plugins.UnobtrusiveFluentValidation;

namespace CP.Mobile.ValidatorEntities
{
    [FluentValidation.Attributes.Validator(typeof(UserValidator))]
    public class UserViewModel: AbstractValidationViewModel
    {
        public ValidatableProperty<string> UserName { get; set; } = new ValidatableProperty<string>();
        public ValidatableProperty<string> Password { get; set; } = new ValidatableProperty<string>();
        public ValidatableProperty<string> Email { get; set; } = new ValidatableProperty<string>();
        public ValidatableProperty<string> FirstName { get; set; } = new ValidatableProperty<string>();
        public ValidatableProperty<string> LastName { get; set; } = new ValidatableProperty<string>();

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
            UserName.ClearError();
            Password.ClearError();
            Email.ClearError();
            FirstName.ClearError();
            LastName.ClearError();
        }
    }
}
