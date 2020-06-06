using CP.Mobile.Validator;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Plugins.FluentValidation;
using Xamarin.Plugins.UnobtrusiveFluentValidation;

namespace CP.Mobile.ValidatorEntities
{
    [FluentValidation.Attributes.Validator(typeof(MusicValidator))]
    public class MusicViewModel: AbstractValidationViewModel
    {
        public ValidatableProperty<string> MusicName { get; set; } = new ValidatableProperty<string>();
        public ValidatableProperty<string> ArtistName { get; set; } = new ValidatableProperty<string>();

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
            MusicName.ClearError();
            ArtistName.ClearError();
        }
    }
}
