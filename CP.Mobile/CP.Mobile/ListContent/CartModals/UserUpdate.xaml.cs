﻿using CP.ServiceLayer.DTO;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP.ServiceLayer.Concrete;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CP.Mobile.Tools.AlertModals;
using CP.Mobile.ValidatorEntities;
using CP.Mobile.Tools;
using CP.ServiceLayer.Firebase;
using Plugin.Media.Abstractions;
using System.IO;
using Xamarin.Essentials;

namespace CP.Mobile.ListContent.CartModals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserUpdate : PopupPage
    {
        UserViewModel uvm = new UserViewModel();

        UserService us = new UserService();
        public User _user;
        public Action _action;

        string ProfilPhoto;
        string BackGroundPhoto;
        FirebaseStorageHelper firebaseStorageHelper = new FirebaseStorageHelper("cafe-project-bfd17.appspot.com");

        public UserUpdate(User user, Action action)
        {
            InitializeComponent();

            _user = user;
            uvm.Email.Value = user.Email;
            uvm.FirstName.Value = user.FirstName;
            uvm.LastName.Value = user.LastName;
            uvm.UserName.Value = user.Username;
            uvm.Password.Value = user.Password;
            uvm.ProfilPhoto = user.ProfilPhoto;
            uvm.BackGroundPhoto = user.BackGroundPhoto;

            BindingContext = uvm;

            _action = action;
            GenderFind();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if (!uvm.ModelResult())
            {
                await Navigation.PushPopupAsync(new ErrorModal("Lütfen eksiksiz doldurun"));
            }
            else
            {

                if (PickerGender.SelectedItem == null)
                {
                    await Navigation.PushPopupAsync(new ErrorModal("Lütfen cinsiyet seçiniz"), true);
                    return;
                }

                try
                { 
                    await Navigation.PushPopupAsync(new LoaderModal());

                   
                    us.Url = "api/User/EmailControl/" + EntEmail.EntryText + "/"+Preferences.Get("UserId",0);
                    if (us.IsThereEmail())
                    {
                        await Navigation.PopPopupAsync(true);
                        await Navigation.PushPopupAsync(new ErrorModal("Email kullanılmış"), true);
                        return;
                    }

                    us.Url = "api/User/UserNameControl/" + EntUserName.EntryText + "/" + Preferences.Get("UserId", 0);

                    if (us.IsThereUserName(EntUserName.EntryText))
                    {
                        await Navigation.PopPopupAsync(true);
                        await Navigation.PushPopupAsync(new ErrorModal("Kullanıcı adı kullanılmış"), true);
                        return;
                    }

                    var value = PickerGender.SelectedIndex;
                    var _genderId = (value == 0) ? 1 : 2;

                    us.Url = "api/User/Update/";
                    var _result = us.Update(new User
                    {
                        Id = _user.Id,
                        FirstName = EntFirstName.EntryText,
                        LastName = EntLastName.EntryText,
                        Username = EntUserName.EntryText,
                        Password = EntPassword.EntryText,
                        Email = EntEmail.EntryText,
                        GenderId = _genderId
                    });

                    await Navigation.PopAllPopupAsync(true);

                    if (_result.Contains("Başarıyla"))
                    {
                        _action.Invoke();
                        await Navigation.PushPopupAsync(new SuccessModal(_result), true);
                    }
                    else
                    {
                        await Navigation.PushPopupAsync(new ErrorModal(_result), true);
                    }
                }
                catch(Exception ex)
                {
                    await Navigation.PushPopupAsync(new ErrorModal("Kayıt Güncellenirken Hata Meydana Geldi"));

                    throw ex;
                }       
            }
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync(true);
        }
        private void GenderFind()
        {
            if (_user.GenderId == 1)
            {
                PickerGender.SelectedIndex = 0;
            }
            else
            {
                PickerGender.SelectedIndex = 1;
            }
        }

        private async void ClosePassword_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAllPopupAsync(true);
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            uvm.ErrorClear();
            FormTools.FormClear(UserUpdateBody);
            imgBackGround.Source = null;
            imgProfil.Source = null;
            PickerGender.SelectedItem = null;
        }
    }
}