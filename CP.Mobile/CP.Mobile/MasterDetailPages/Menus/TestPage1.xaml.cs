using CP.Mobile.ImageSlider;
using CP.Mobile.Tools.AlertModals;
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
    public partial class TestPage1 : ContentPage
    {
        List<string> names = new List<string>
        {
            "Ahmet","Ali","Ceyhan"
        };
        public TestPage1()
        {
            try
            {
                  InitializeComponent();
            CVMovies.ItemsSource = new MovieService().GetMoviesList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        

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

            await Navigation.PopPopupAsync();

            Application.Current.MainPage = new NavigationPage(new CP.Mobile.MainPage());

        }
    }
}