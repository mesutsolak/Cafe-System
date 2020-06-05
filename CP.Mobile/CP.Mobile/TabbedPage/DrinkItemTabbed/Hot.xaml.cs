using CP.Mobile.ListContent;
using CP.Mobile.Tools.AlertModals;
using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
using DLToolkit.Forms.Controls;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.TabbedPage.DrinkItemTabbed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Hot : ContentPage
    {
        MainPageModel pageModel;

        ProductService productService = new ProductService();
        CartService cartService = new CartService();

        public Hot()
        {
            InitializeComponent();
            FlowListView.Init();
            HotLoad();
        }
        public void HotLoad()
        {
            pageModel = new MainPageModel(this, 11);
            BindingContext = pageModel;
        }

        private async void FlowListView_Refreshing(object sender, EventArgs e)
        {

            ListHots.IsRefreshing = true;


            HotLoad();


            await Task.Delay(1000);

            ListHots.IsRefreshing = false;
        }

        private async void btnCart_Clicked(object sender, EventArgs e)
        {
            try
            {
                var _id = ((ImageButton)sender).CommandParameter.ToString();
                productService.Url = "api/Product/";
                ProductDTO p = productService.GetFind(int.Parse(_id));
                await Navigation.PushPopupAsync(new QuestionModal("Sepet İşlemi", p.Name + " adlı ürünü sepete eklemek istiyor musunuz ?", () => { CartAdd(p); }), true);

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async void CartAdd(ProductDTO p)
        {
            var id = Preferences.Get("UserId", 0);
            cartService.Url = "api/Cart/Add";
            var result = cartService.Add(new CartDTO
            {
                Count = 1,
                UserId = id,
                Price = p.Price,
                ProductId = p.Id,
                Time = p.Time
            });

            await Navigation.PopPopupAsync();

            if (result.Contains("Başarıyla"))
                await Navigation.PushPopupAsync(new SuccessModal(result, null), true);
            else
                await Navigation.PushPopupAsync(new ErrorModal(result));

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListHots.ItemsSource = pageModel.Items.Where(x => x.Name.Contains(HotSearch.Text)).ToList();
        }
    }
}