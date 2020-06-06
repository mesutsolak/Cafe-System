using CP.Mobile.ValidatorEntities;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Plugins.FluentValidation;
using FluentValidation;

namespace CP.Mobile.Validator
{
    public class MusicValidator : EnhancedAbstractValidator<MusicViewModel>
    {
        public MusicValidator()
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleForProp(x => x.MusicName)
             .NotNull().NotEmpty().WithMessage("Müzik adı boş gecilemez");

            RuleForProp(x => x.ArtistName)
              .NotNull().NotEmpty().WithMessage("Sanatçı adı boş gecilemez");

        }
    }
}
