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

namespace CP.Mobile.ContentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetail : ContentPage
    {
        CartService cartService = new CartService();
        public ProductDTO p { get; set; }

        public ProductDetail(ProductDTO product)
        {
            InitializeComponent();


            p = product;

            ImageMeal.Source = product.Image;
            lblCategory.Text = "/ " + product.Category.Name;
            lblClock.Text = product.Time.ToString();
            lblComment.Text = "5";
            lblPrice.Text = product.Price + " TL";
            lblRating.Text = "5";
            LblName.Text = product.Name;
            lblDescription.Text = product.ProductDetail;

        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            var number = int.Parse(lblNumber.Text);
            number++;
            lblNumber.Text = number.ToString();
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            var number = int.Parse(lblNumber.Text);
            if (number != 0)
            {
                number--;
                lblNumber.Text = number.ToString();
            }
        }

        private async void CartDetailAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new QuestionModal("Sepet İşlemi", lblNumber.Text + " Adet Ürünü Sepete Eklensin ?", () => { CartAdd(); }));
        }
        public async void CartAdd()
        {
            //lblNumber
            var number = int.Parse(lblNumber.Text);


            if (number > 0)
            {
                var id = Preferences.Get("UserId", 0);
                cartService.Url = "api/Cart/Add";
                var result = cartService.Add(new CartDTO
                {
                    Count = number,
                    UserId = id,
                    Price = p.Price * number,
                    ProductId = p.Id,
                    Time = p.Time * number
                });

                await Navigation.PopPopupAsync();



                if (result.Contains("Başarıyla"))
                {
                    lblNumber.Text = "0";
                    await Navigation.PushPopupAsync(new SuccessModal(result, null), true);

                }
                else
                    await Navigation.PushPopupAsync(new ErrorModal(result));

            }
            else
            {
                await Navigation.PopPopupAsync();
                await Navigation.PushPopupAsync(new ErrorModal("Lütfen ürün sayısı seçiniz"));
            }
        }

        private void btnCommentAdd_Clicked(object sender, EventArgs e)
        {

        }

        private void btnRatingAdd_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }
    }
}