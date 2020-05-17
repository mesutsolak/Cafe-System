using CP.Mobile.ListContent.CartModals;
using CP.Mobile.MasterDetailPages.PopupMenu;
using CP.Mobile.MasterDetailPages.PopupMenuContent;
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

        public CartViewModel ViewModel => CartViewModel.Instance;
        public Xam.Plugin.PopupMenu Popup;

        public Cart()
        {
            try
            {
                InitializeComponent();
                CartList();

                Popup = new Xam.Plugin.PopupMenu()
                {
                    BindingContext = ViewModel
                };
                Popup.OnItemSelected += Popup_OnItemSelected; ;

                Popup.SetBinding(Xam.Plugin.PopupMenu.ItemsSourceProperty, "ListItems");

                Navigation.PopPopupAsync(true);

            }
            catch (Exception ex)
            {

                throw;
            }
       
        }

        private async void Popup_OnItemSelected(string item)
        {
            switch (item)
            {
                case "Genel Durum":
                    await Navigation.PushPopupAsync(new CartGeneral(), true);
                    break;
                case "Ürünleri Kaldır":
                    await Navigation.PushPopupAsync(new QuestionModal("Silme İşlemi", "Ürünler silinsin mi ?", () => { CartRemoves(); }), true);
                    break;
                case "Ürünleri Onayla":
                    await Navigation.PushPopupAsync(new QuestionModal("Onaylama İşlemi", "Ürünler Onaylansın mı ?", () => { CartConfirms(); }), true);
                    break;
                default:
                    break;
            }
        }

        public void CartConfirms()
        {

        }

        public void CartRemoves()
        {

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
        public async void Confirm(int CartId)
        {
            cartservice.Url = "api/Cart/Confirm/";
            //var _result = cartservice.ConfirmCart(CartId);

            //await Navigation.PopPopupAsync(true);

            //if (_result.Contains("Onaylandı"))
            //{
            //    CartList();
            //    await Navigation.PushPopupAsync(new SuccessModal("Ürün Başarıyla Onaylandı"), true);
            //}
            //else
            //{
            //    await Navigation.PushPopupAsync(new ErrorModal("Ürün Onaylama Başarısız"), true);
            //}
        }


        private async void btnSuccess_Clicked(object sender, EventArgs e)
        {
            var _id = (sender as ImageButton).CommandParameter.ToString();

            await Navigation.PushPopupAsync(new QuestionModal("Onaylama İşlemi", "Ürün Onaylansın mı ?", () => { Confirm(int.Parse(_id)); }), true);
        }


        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            var _id = (sender as ImageButton).CommandParameter.ToString();

            try
            {
                cartservice.Url = "api/Cart/Find/";
                var _cart = cartservice.GetFindString(int.Parse(_id));

                await Navigation.PushPopupAsync(new CartUpdate(_cart, () => { CartList(); }));

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        private void CartGeneral_Clicked(object sender, EventArgs e)
        {
            Popup?.ShowPopup(sender as View);
        }
    }
}