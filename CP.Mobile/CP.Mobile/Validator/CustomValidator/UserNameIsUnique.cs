using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Plugins.UnobtrusiveFluentValidation;

namespace CP.Mobile.Validator.CustomValidator
{
    public class UserNameIsUnique: PropertyValidator 
    {
        public UserNameIsUnique():base("Kullanıcı Adı Alınmış")
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
