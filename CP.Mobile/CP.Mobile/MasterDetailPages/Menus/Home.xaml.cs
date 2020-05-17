using CP.Mobile.Tools.AlertModals;
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

namespace CP.Mobile.MasterDetailPages.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        CartService cs = new CartService();
        SliderService _ss = new SliderService();
        HomePageService hps = new HomePageService();


        private void CountFound()
        {
            try
            {
                cs.Url = "api/Cart/Count/";
                var a = Preferences.Get("UserId", 0);
                var result = cs.CartCount(a);
                CartCount.Text = result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        List<string> names = new List<string>
        {
            "Ahmet","Ali","Ceyhan"
        };
        public Home()
        {
            try
            {
                InitializeComponent();
                BindingContext = HomePages();
                CountFound();
                Sliders();
                //OrderCount();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            Navigation.PopPopupAsync(true);


        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new QuestionModal("Çıkış İşlemi", "Çıkmak istiyor musunuz ?", () => { SignOut(); }), true);
        }
        public async void SignOut()
        {
            Preferences.Remove("UserName");

            Preferences.Remove("UserId");

            await Navigation.PopPopupAsync();

            Application.Current.MainPage = new NavigationPage(new CP.Mobile.MainPage());

        }

        public HomePageDTO HomePages()
        {
            hps.Url = "api/HomePage/GetAll";
            return hps.GetHome();
        }

        public void Sliders()
        {
            _ss.Url = "api/Slider/GetAll";
            CVMovies.ItemsSource = _ss.GetAll();
        }

        public void OrderCount()
        {
            cs.Url = "api/Cart/OrderCount/";
            OrderCountLbl.Text = cs.CartCount(Preferences.Get("UserId", 0));
        }

    }
}