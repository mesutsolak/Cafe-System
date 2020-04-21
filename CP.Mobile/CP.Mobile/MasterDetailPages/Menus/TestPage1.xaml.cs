using CP.Mobile.ImageSlider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}