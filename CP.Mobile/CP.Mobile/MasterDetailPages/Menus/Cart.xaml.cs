using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
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
    public partial class Cart : ContentPage
    {
        CartService cartservice = new CartService();


        public Cart()
        {
            InitializeComponent();
            CartListItems.ItemsSource = CartList();
          }

        public List<CartDTO> CartList()
        {
           var _user = Preferences.Get("UserId", 0);
            cartservice.Url = "api/Cart/List/";
           return cartservice.Carts(_user);
        }

      
     
        private void btnRemove_Clicked(object sender, EventArgs e)
        {

        }

        private void btnSuccess_Clicked(object sender, EventArgs e)
        {

        }

    }
}