using CP.Mobile.MasterDetailPages.PopupMenu;
using CP.Mobile.MasterDetailPages.PopupMenuContent;
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
    public partial class Order : ContentPage
    {
        CartService cs = new CartService();
        List<CartDTO> _order = new List<CartDTO>();
        public Xam.Plugin.PopupMenu Popup;
        public OrderViewModel ViewModel => OrderViewModel.Instance;


        private int _count;
        private int _price;
        private int _time;

        public Order()
        {
            InitializeComponent();
            OrderList();
            OrderGeneral();


            Popup = new Xam.Plugin.PopupMenu()
            {
                BindingContext = ViewModel
            };
            Popup.OnItemSelected += Popup_OnItemSelected; ;

            Popup.SetBinding(Xam.Plugin.PopupMenu.ItemsSourceProperty, "ListItems");

            Navigation.PopPopupAsync(true);
        }

        private void OrderGeneral()
        {
            _count = _order.Count;

            _price = (int)_order.Select(x => x.Price).Sum();

            _time = (int)_order.Select(x => x.Time).Sum();

        }

        private async void Popup_OnItemSelected(string item)
        {
            switch (item)
            {
                case "Genel Durum":
                    await Navigation.PushPopupAsync(new CartGeneral("Sipariş Bilgileri", _count, _price, _time), true);
                    break;
                default:
                    break;
            }
        }

        public void OrderList()
        {
            cs.Url = "api/Cart/OrderAll/";
             _order  = cs.GetAllFilter(Preferences.Get("UserId", 0));
            CartListItems.ItemsSource = _order;
        }
        private async void CartListItems_Refreshing(object sender, EventArgs e)
        {
            CartListItems.IsRefreshing = true;

            OrderList();

            await Task.Delay(1000);

            CartListItems.IsRefreshing = false;
        }

        private void OrderGeneral_Clicked(object sender, EventArgs e)
        {
            Popup?.ShowPopup(sender as View);
        }
    }
}