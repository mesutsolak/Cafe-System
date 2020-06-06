using CP.Mobile.ValidatorEntities;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Plugins.FluentValidation;
using FluentValidation;

namespace CP.Mobile.Validator
{
    public class CommentValidator : EnhancedAbstractValidator<CommentViewModel>
    {
        public CommentValidator()
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleForProp(x => x.Description)
                .NotNull().NotEmpty().WithMessage("Yorum boş gecilemez");
        }
    }
}
