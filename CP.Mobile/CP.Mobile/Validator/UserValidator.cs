using CP.Mobile.Validator.CustomValidator;
using CP.Mobile.ValidatorEntities;
using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Plugins.FluentValidation;
using Xamarin.Plugins.UnobtrusiveFluentValidation;

namespace CP.Mobile.Validator
{
    public class UserValidator : EnhancedAbstractValidator<UserViewModel>
    {
        UserService userService = new UserService();
        public UserValidator()
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleForProp(x => x.FirstName)
                .NotNull().NotEmpty().WithMessage("İsim boş gecilemez")
                .MinimumLength(5).WithMessage("İsim en az 5 karakterden oluşmalıdır")
                .MaximumLength(20).WithMessage("İsim en fazla 20 karakterden oluşmalı")
                .Matches("^[a-zA-Z]*$").WithMessage("İsim sadece harften oluşmalıdır.");

            RuleForProp(x => x.LastName)
                .NotNull().NotEmpty().WithMessage("Soyisim boş gecilemez")
             .MinimumLength(5).WithMessage("Soyisim en az 5 karakterden oluşmalıdır")
             .MaximumLength(20).WithMessage("Soyisim en fazla 20 karakterden oluşmalı")
             .Matches("^[a-zA-Z]*$").WithMessage("Soyisim sadece harften oluşmalıdır.");

            RuleForProp(x => x.UserName)
                .NotNull().NotEmpty().WithMessage("Kullanıcı adı boş gecilemez")
           .MinimumLength(5).WithMessage("Kullanıcı adı en az 5 karakterden oluşmalıdır")
           .MaximumLength(20).WithMessage("Kullanıcı adı en fazla 20 karakterden oluşmalı");
           //.Must(IsUniqueUserName).WithMessage("Kullanıcı adı alınmış");

            RuleForProp(x => x.Email)
                .NotNull().NotEmpty().WithMessage("Email boş geçilemez")
             .MinimumLength(5).WithMessage("Email en az 5 karakterden oluşmalıdır")
             .MaximumLength(30).WithMessage("Email en fazla 30 karakterden oluşmalı")
             .EmailAddress().WithMessage("Geçerli email giriniz");
           //.Must(IsUniqueEmail).WithMessage("Email alınmış");


            RuleForProp(x => x.Password)
                .NotNull().NotEmpty().WithMessage("Parola boş geçilemez")
             .MinimumLength(5).WithMessage("Parola en az 5 karakterden oluşmalıdır")
             .MaximumLength(30).WithMessage("Parola en fazla 30 karakterden oluşmalı");
        }



        //protected bool IsUniqueUserName(string UserName)
        //{
        //    if (UserName != null)
        //    {
        //        userService.Url = "api/User/IsThereUserName/" + UserName;
        //        var r = userService.IsThereUserName(UserName).Result;
        //        return r;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}
        //protected bool IsUniqueEmail(string Email)
        //{
        //    if (Email != null)
        //    {
        //        userService.Url = "api/User/IsThereEmail/"+ Email;
        //        var e = userService.IsThereEmail(Email).Result;
        //        return e;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
