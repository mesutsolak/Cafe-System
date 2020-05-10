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
    public partial class Cart : ContentPage
    {
        CartService cartservice = new CartService();


        public Cart()
        {
            InitializeComponent();
            CartList();
        }

        public void CartList()
        {
            var _user = Preferences.Get("UserId", 0);
            cartservice.Url = "api/Cart/List/";
            CartListItems.ItemsSource = cartservice.Carts(_user);
        }



        private async void btnRemove_Clicked(object sender, EventArgs e)
        {
            var _id = (sender as ImageButton).CommandParameter.ToString();

            await Navigation.PushPopupAsync(new QuestionModal("Silme İşlemi", "Ürün Silinsin mi ?", () => { Remove(int.Parse(_id)); }), true);
        }

        public async void Remove(int id)
        {
            cartservice.Url = "api/Cart/";
            var _result = await cartservice.RemoveAsync(id);

            await Navigation.PopPopupAsync(true);

            if (_result.Contains("Başarıyla"))
            {
                CartList();
                await Navigation.PushPopupAsync(new SuccessModal("Ürün Başarıyla Silindi"), true);
            }
            else
            {
                await Navigation.PushPopupAsync(new ErrorModal("Ürün Silme Başarısız"), true);
            }
        }

        private void btnSuccess_Clicked(object sender, EventArgs e)
        {

        }

    }
}