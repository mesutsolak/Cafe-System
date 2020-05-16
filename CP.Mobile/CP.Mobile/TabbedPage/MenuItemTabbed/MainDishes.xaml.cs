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

namespace CP.Mobile.TabbedPage.MenuItemTabbed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainDishes : ContentPage
    {
        ProductService productService = new ProductService();
        CartService cartService = new CartService();

        MainPageModel pageModel;
        public MainDishes()
        {
            InitializeComponent();
            FlowListView.Init();
            MealLoad();
        }

        private void MealLoad()
        {
            pageModel = new MainPageModel(this, 4);
            BindingContext = pageModel;
        }

        private async void btnCart_Clicked(object sender, EventArgs e)
        {
            try
            {
                var _id = ((ImageButton)sender).CommandParameter.ToString();
                productService.Url = "api/Product/";
                ProductDTO p = productService.GetFind(int.Parse(_id));
                await Navigation.PushPopupAsync(new QuestionModal("Sepet İşlemi", p.Name + "adlı ürünü sepete eklemek istiyor musunuz ?", () => { CartAdd(p); }), true);

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
            ListMeals.FlowItemsSource = pageModel.Items.Where(x => x.Name.Contains(MealsSearch.Text)).ToList();
        }

        private async void FlowListView_Refreshing(object sender, EventArgs e)
        {

            ListMeals.IsRefreshing = true;


            MealLoad();


            await Task.Delay(1000);

            ListMeals.IsRefreshing = false;
        }
    }
}