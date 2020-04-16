using CP.Mobile.Tools;
using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.ContentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignIn : ContentPage
    {
        UserService userService = new UserService();
        public SignIn()
        {
            InitializeComponent();
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            FormTools.FormClear(StlForm);
        }

        private async void btnSignUp_Clicked(object sender, EventArgs e)
        {
            try
            {
                userService.Url = "/api/User/GetLoginControl/";
                var _result = await userService.LoginControl(new User
                {
                    Username = EntUserName.Text,
                    Password = EntPassword.Text,
                });
                if (_result.Contains("Başarıyla"))
                {
                    await DisplayAlert("Başarılı", _result, "Kapat");
                    FormTools.FormClear(StlForm);
                }
                else
                {
                    await DisplayAlert("Başarısız", _result, "Kapat");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}