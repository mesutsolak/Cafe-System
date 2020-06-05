using CP.Mobile.ContentPages;
using CP.ServiceLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CP.Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        GeneralService _gs = new GeneralService();
        public MainPage()
        {
            InitializeComponent();
            FormGeneral();
        }

        private void FormGeneral()
        {
            _gs.Url = "api/General/Get";
            var _general = _gs.Get();
            Image.Source = _general.Image ?? "cafe.png";
            Title.Text = _general.Title ?? "Beyoğlu Kafesi";
        }

        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        private async void btnSignIn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignIn());
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
