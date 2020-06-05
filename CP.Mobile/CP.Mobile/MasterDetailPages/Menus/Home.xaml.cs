using CP.Mobile.Tools.AlertModals;
using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.MasterDetailPages.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        CartService cs = new CartService();
        SliderService _ss = new SliderService();
        HomePageService hps = new HomePageService();
        ProductService ps = new ProductService();
        CampaignService _cs = new CampaignService();
        List<ProductDTO> chooseDTO = new List<ProductDTO>();
        List<ProductDTO> preferencesDTO = new List<ProductDTO>();
        List<CampaignDTO> CampaignDTO = new List<CampaignDTO>();


        private void CountFound()
        {
            try
            {
                cs.Url = "api/Cart/Count/";
                var result = cs.CartCount(Preferences.Get("UserId", 0));
                CartCount.Text = result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public Home()
        {
            InitializeComponent();
            BindingContext = HomePages();
            CountFound();
            Sliders();
            OrderCount();
            ProductPreferences();
            ProductChoose();
            Campaigns();
            Navigation.PopPopupAsync(true);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new QuestionModal("Çıkış İşlemi", "Çıkmak istiyor musunuz ?", () => { SignOut(); }), true);
        }
        public async void SignOut()
        {
            Preferences.Remove("UserName");

            Preferences.Remove("UserId");

            await Navigation.PopPopupAsync();

            Application.Current.MainPage = new NavigationPage(new CP.Mobile.MainPage());

        }

        public HomePageDTO HomePages()
        {
            hps.Url = "api/HomePage/GetAll";
            return hps.GetHome();
        }

        public void Sliders()
        {
            _ss.Url = "api/Slider/GetAll";
            CVMovies.ItemsSource = _ss.GetAll();
        }

        public void OrderCount()
        {
            cs.Url = "api/Cart/OrderCount/";
            OrderCountLbl.Text = cs.CartCount(Preferences.Get("UserId", 0));
        }

        public void ProductPreferences()
        {
            preferencesDTO.Clear();


            ps.Url = "api/Product/Prefences";

            preferencesDTO = ps.GetAll();
            CVPreferred.ItemsSource = preferencesDTO;
        }
        public void ProductChoose()
        {
            chooseDTO.Clear();

            ps.Url = "api/Product/Choose";

            chooseDTO = ps.GetAll();
            CVChoose.ItemsSource = chooseDTO;
        }
        public void Campaigns()
        {
            CampaignDTO.Clear();

            _cs.Url = "api/Campaign/All";

            CampaignDTO = _cs.GetAll();

            CVCampaign.ItemsSource = CampaignDTO;


        }

        private void btnCampaignCart_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnPreferenceCart_Clicked(object sender, EventArgs e)
        {
            var _id = ((ImageButton)sender).CommandParameter.ToString();
            ps.Url = "api/Product/";
            ProductDTO p = ps.GetFind(int.Parse(_id));
            await Navigation.PushPopupAsync(new QuestionModal("Sepet İşlemi", p.Name + " adlı ürünü sepete eklemek istiyor musunuz ?", () => { CartAdd(p); }), true);
        }

        private async void btnChooseCart_Clicked(object sender, EventArgs e)
        {

            var _id = ((ImageButton)sender).CommandParameter.ToString();
            ps.Url = "api/Product/";
            ProductDTO p = ps.GetFind(int.Parse(_id));
            await Navigation.PushPopupAsync(new QuestionModal("Sepet İşlemi", p.Name + " adlı ürünü sepete eklemek istiyor musunuz ?", () => { CartAdd(p); }), true);
        }
        public async void CartAdd(ProductDTO p)
        {
            var id = Preferences.Get("UserId", 0);
            cs.Url = "api/Cart/Add";
            var result = cs.Add(new CartDTO
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
    }
}