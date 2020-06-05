using CP.Mobile.Tools;
using CP.Mobile.Tools.AlertModals;
using CP.Mobile.ValidatorEntities;
using CP.ServiceLayer.Concrete;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
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
    public partial class PasswordForget : PopupPage
    {
        UserService us = new UserService();
        PasswordForgetViewModel vm = new PasswordForgetViewModel();
        public PasswordForget()
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private async void btnPasswordclose_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        private async void btnPasswordSend_Clicked(object sender, EventArgs e)
        {

            try
            {
                var model = ((sender as View).BindingContext as PasswordForgetViewModel);
                if (!model.ModelResult())
                {
                    await Navigation.PushPopupAsync(new CP.Mobile.Tools.AlertModals.ErrorModal("Lütfen eksiksiz doldurun"), true);
                }
                else
                {
                    await Navigation.PushPopupAsync(new LoaderModal());

                    us.Url = "api/User/PasswordForget/";
                    var _result = us.PasswordFind(model.Email.Value);

                    await Navigation.PopPopupAsync();

                    await Navigation.PopPopupAsync();


                    if (_result.Contains("Başarıyla"))
                    {
                        await Navigation.PushPopupAsync(new SuccessModal(_result));
                    }
                    else
                    {
                        await Navigation.PushPopupAsync(new ErrorModal(_result));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void btnPasswordClear_Clicked(object sender, EventArgs e)
        {
            FormTools.FormClear(stlPassword);
            vm.ErrorClear();
        }

        private async void ClosePassword_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}