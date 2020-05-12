using CP.Mobile.Tools;
using CP.Mobile.Tools.AlertModals;
using CP.Mobile.ValidatorEntities;
using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.ContentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignIn : ContentPage
    {
        UserService userService = new UserService();
        LoginViewModel userViewModel = new LoginViewModel();
        public SignIn()
        {
            InitializeComponent();
            BindingContext = userViewModel;
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            FormTools.FormClear(StlForm);
        }

        private async void btnSignUp_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!userViewModel.ModelResult())
                {
                    await Navigation.PushPopupAsync(new ErrorModal("Lütfen Gerekli Yerleri Doldurun"));
                }
                else
                {
                    userService.Url = "/api/User/Login";

                    await Navigation.PushPopupAsync(new LoaderModal());

                    var _result = await userService.LoginControl(new LoginControl
                    {
                        UserName = EntUserName.EntryText,
                        Password = EntPassword.EntryText,
                    });

                    await Navigation.PopPopupAsync(true);

                    if (_result.Contains("Başarıyla"))
                    {
                        userService.Url = "api/User/UserId/";

                        var result = _result.Split(',')[1];

                        Preferences.Set("UserName", EntUserName.EntryText);

                        Preferences.Set("FirstAndLast", result);

                        Preferences.Set("UserId",  userService.UserId(EntUserName.EntryText));

                        await Navigation.PushPopupAsync(new SuccessModal("Başarıyla Giriş Yapıldı", () => { RootMain(); }));

                        FormTools.FormClear(StlForm);
                    }
                    else
                    {
                        await Navigation.PushPopupAsync(new ErrorModal("Giriş Başarısız"));
                    }
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async void RootMain()
        {
            await Navigation.PushAsync(new CP.Mobile.MasterDetailPages.MainPage(), true);
        }
    }
}