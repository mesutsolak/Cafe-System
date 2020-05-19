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
    public partial class DrinkGeneral : PopupPage
    {
        ProductService ps = new ProductService();

        public DrinkGeneral()
        {
            InitializeComponent();
            ProductCount();

        }

        private async void btnClose_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync(true);
        }
        public void ProductCount()
        {
            ps.Url = "api/Product/ProductCount/" + 10;
            lblColdDrink.Text = ps.ProductCount();
            ps.Url = "api/Product/ProductCount/" + 11;
            lblHotDrink.Text = ps.ProductCount();
        }
    }
}