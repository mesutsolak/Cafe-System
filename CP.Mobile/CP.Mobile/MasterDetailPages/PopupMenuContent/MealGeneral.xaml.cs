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

namespace CP.Mobile.MasterDetailPages.PopupMenuContent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealGeneral : PopupPage
    {
        ProductService ps = new ProductService();

        public MealGeneral()
        {
            InitializeComponent();
            ProductCount();
        }

        private async void btnClose_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

        public void ProductCount()
        {
            ps.Url = "api/Product/ProductCount/" + 4;
            lblMeal.Text = ps.ProductCount();
            ps.Url = "api/Product/ProductCount/" + 7;
            lblPotato.Text = ps.ProductCount();
            ps.Url = "api/Product/ProductCount/" + 8;
            lblSoup.Text = ps.ProductCount();
            ps.Url = "api/Product/ProductCount/" + 9;
            lblDessert.Text = ps.ProductCount();
        }

    }
}