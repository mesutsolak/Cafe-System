using CP.Mobile.Tools;

using CP.Mobile.Tools.AlertModals;
using CP.Mobile.Validator;
using CP.Mobile.ValidatorEntities;
using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
using FluentValidation;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
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
        public Register()
        {
            InitializeComponent();
            BindingContext = userViewModel;
        }

        private async void btnClear_Clicked(object sender, EventArgs e)
        {
            //FormClear();
            //this.Navigation.PopAsync();
            //this.Navigation.PopToRootAsync();
            //await Application.Current.MainPage.Navigation.PopAsync();
            await Navigation.PushAsync(new Register());
        }

        private void FormClear()
        {
            FormTools.FormClear(StlForm);
        }

        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            if (!userViewModel.ModelResult())
            {
                await Navigation.PushPopupAsync(new ErrorModal("Lütfen Gerekli Yerleri Doldurun"));
            }
            else
            {
                try
                {
                    await Navigation.PushPopupAsync(new LoaderModal());

                    userService.Url = "/api/User";
                    var _result = await userService.AddAsync(new User
                    {
                        FirstName = EntFirstName.EntryText,
                        LastName = EntLastName.Text,
                        Username = EntUserName.Text,
                        Email = EntEmail.Text,
                        Password = EntPassword.Text,
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
    }
}