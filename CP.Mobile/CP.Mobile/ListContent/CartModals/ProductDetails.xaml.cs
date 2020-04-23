using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.ListContent.CartModals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetails : PopupPage
    {
        public ProductDetails(Meal Meals)
        {
            InitializeComponent();
            ImageMeal.Source = Meals.Image;
            LblName.Text = Meals.Name;
            lblDescription.Text = Meals.Category + "uhuıuıhgıgıghghlghlghghllghlhghghgghghghghghghghghghghghghghghjhbhjbhbhklhblbhbhlhbhblbhlbhbhlbhhjjjjjjjjjjjjjjjjjjjjjıghhgghghghghghghghghghghhgghhhhlhhllhjjhjh ";
        }
        public void List()
        {
        }

        private async void btnOk_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            var number = int.Parse(lblNumber.Text);
            number++;
            lblNumber.Text = number.ToString();
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            var number = int.Parse(lblNumber.Text);
            if (number != 0)
            {
                number--;
                lblNumber.Text = number.ToString();
            }
        }
    }
}