using CP.ServiceLayer.DTO;
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


namespace CP.Mobile.ListContent.CartModals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserUpdate : PopupPage
    {
        UserService us = new UserService();
        public User _user;
        public Action _action;
        public UserUpdate(User user, Action action)
        {
            InitializeComponent();

            _user = user;
            BindingContext = user;
            _action = action;
            GenderFind();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            var value = PickerGender.SelectedIndex;
            var _genderId = (value == 0) ? 1 : 2;

            us.Url = "api/User/Update/";
            var _result = us.Update(new User
            {
                Id = _user.Id,
                FirstName = EntFirstName.Text,
                LastName = EntLastName.Text,
                Username = EntUserName.Text,
                Password = EntPassword.Text,
                Email = EntEmail.Text,
                GenderId = _genderId
            });

            await Navigation.PopPopupAsync(true);

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
    }
}