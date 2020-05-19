using CP.ServiceLayer.Concrete;
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
    public partial class Order : ContentPage
    {
        CartService cs = new CartService();

        public Order()
        {
            InitializeComponent();
            Navigation.PopPopupAsync(true);
            OrderList();
        }
        public void OrderList()
        {
            cs.Url = "api/Cart/OrderAll/";
            CartListItems.ItemsSource = cs.GetAllFilter(Preferences.Get("UserId", 0));
        }
    }
}