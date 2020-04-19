using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CP.Mobile.Validator.CustomValidator
{
    public class EmailIsUnique: PropertyValidator
    {
        public EmailIsUnique() : base("Hata")
        {

        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            if ((string)context.PropertyValue == "Mesut")
            {
                return true;
            }
            return false;
        }
    }
}
