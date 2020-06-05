using CP.Mobile.Tools;

using CP.Mobile.Tools.AlertModals;
using CP.Mobile.Validator;
using CP.Mobile.ValidatorEntities;
using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
using CP.ServiceLayer.Firebase;
using FluentValidation;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Plugins.UnobtrusiveFluentValidation;

namespace CP.Mobile.ContentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        UserService userService = new UserService();
        UserViewModel userViewModel = new UserViewModel();
        MediaFile _profilPhoto;
        MediaFile _BackgroundPhoto;
        string ProfilPhoto;
        string BackGroundPhoto;
        FirebaseStorageHelper firebaseStorageHelper = new FirebaseStorageHelper("cafe-project-bfd17.appspot.com");


        public Register()
        {
            InitializeComponent();
            BindingContext = userViewModel;
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            FormClear();

        }

        private void FormClear()
        {
            FormTools.FormClear(StlRegister);
            userViewModel.ErrorClear();
            imgBackGround.Source = null;
            imgProfil.Source = null;
        }

        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            if (!userViewModel.ModelResult())
            {
                await Navigation.PushPopupAsync(new ErrorModal("Lütfen eksiksiz doldurun"));
            }
            else
            {
                if (picker.SelectedItem == null)
                {
                    await Navigation.PushPopupAsync(new ErrorModal("Lütfen cinsiyet seçiniz"), true);
                    return;
                }

                try
                {
                    await Navigation.PushPopupAsync(new LoaderModal());

                    if (_profilPhoto != null)
                    {
                        ProfilPhoto = await firebaseStorageHelper.UploadFile(_profilPhoto.GetStream(), Guid.NewGuid() + Path.GetFileName(_profilPhoto.Path), "User");
                    }
                    else
                    {
                        if (picker.SelectedIndex == 0)
                            ProfilPhoto = ProfilPhoto ?? "male.png";
                        else
                            ProfilPhoto = ProfilPhoto ?? "female.png";
                    }

                    if (_BackgroundPhoto != null)
                    {
                        BackGroundPhoto = await firebaseStorageHelper.UploadFile(_BackgroundPhoto.GetStream(), Guid.NewGuid() + Path.GetFileName(_BackgroundPhoto.Path), "User");
                    }

                    userService.Url = "api/User/IsThereEmail/" + EntEmail.EntryText;
                    if (userService.IsThereEmail())
                    {
                        await Navigation.PopPopupAsync(true);
                        await Navigation.PushPopupAsync(new ErrorModal("Email kullanılmış"), true);
                        return;
                    }

                    userService.Url = "api/User/IsThereUserName/";

                    if (userService.IsThereUserName(EntUserName.EntryText))
                    {
                        await Navigation.PopPopupAsync(true);
                        await Navigation.PushPopupAsync(new ErrorModal("Kullanıcı adı kullanılmış"), true);
                        return;
                    }



                    userService.Url = "/api/User/";
                    var _result = await userService.AddAsync(new User
                    {
                        FirstName = EntFirstName.EntryText,
                        LastName = EntLastName.EntryText,
                        Username = EntUserName.EntryText,
                        Email = EntEmail.EntryText,
                        Password = EntPassword.EntryText,
                        GenderId = picker.SelectedIndex == 0 ? 1 : 2,
                        ProfilPhoto = ProfilPhoto,
                        BackGroundPhoto = BackGroundPhoto ?? "bg.png"
                    });

                    await Navigation.PopPopupAsync(true);


                    if (_result.Contains("Başarıyla"))
                    {
                        await Navigation.PushPopupAsync(new SuccessModal("Başarıyla Kayıt Olundu"));

                        FormClear();
                    }
                    else
                    {
                        await Navigation.PushPopupAsync(new ErrorModal("Kayıt Ekleme Başarısız"));
                    }
                }
                catch (Exception ex)
                {
                    await Navigation.PushPopupAsync(new ErrorModal("Kayıt Eklenirken Hata Meydana Geldi"));

                    throw ex;
                }
            }
        }

        private async void btnProfilPhoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                _profilPhoto = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });
                if (_profilPhoto == null)
                    return;
                imgProfil.Source = ImageSource.FromStream(() =>
                {
                    var imageStram = _profilPhoto.GetStream();
                    return imageStram;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void btnBackGroundPhoto_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                _BackgroundPhoto = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });
                if (_BackgroundPhoto == null)
                    return;
                imgBackGround.Source = ImageSource.FromStream(() =>
                {
                    var imageStram = _BackgroundPhoto.GetStream();
                    return imageStram;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}