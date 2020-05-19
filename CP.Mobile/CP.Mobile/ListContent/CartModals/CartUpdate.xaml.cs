using CP.Mobile.Tools.AlertModals;
using CP.ServiceLayer.DTO;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.ListContent.CartModals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartUpdate : PopupPage
    {
        CP.ServiceLayer.Concrete.CartService cartService = new ServiceLayer.Concrete.CartService();

        public CartDTO _cartDTO { get; set; }
        public Action _action { get; set; }
        public CartUpdate(CartDTO cartDTO,Action action=null)
        {
                 InitializeComponent();
            _cartDTO = cartDTO; 
            CartUpdateLoad();
            _action = action;
               
        }

        public void CartUpdateLoad()
        {
            PictureShow.Source = _cartDTO.productDTO.Image;
            lblNumber.Text = _cartDTO.Count.ToString();
            lblPrice.Text = _cartDTO.productDTO.Price + " TL";
            lblTime.Text = _cartDTO.productDTO.Time + " dk";
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            if (lblNumber.Text == "0")
            {
                await Navigation.PushPopupAsync(new CP.Mobile.Tools.AlertModals.ErrorModal("Lütfen adet belirleyiniz"), true);
            }
            else
            {
                var count = int.Parse(lblNumber.Text);
                cartService.Url = "api/Cart/";
                var _result = await cartService.UpdateAsync(new CartDTO
                {
                    Id = _cartDTO.Id,
                    Count = count,
                    Price = _cartDTO.productDTO.Price * count,
                    Time = _cartDTO.productDTO.Time * count,
                    ConfirmId = 2,
                    UserId = _cartDTO.UserId,
                    ProductId = _cartDTO.ProductId
                });

                  await Navigation.PopPopupAsync(true);
              
                if (_result.Contains("Başarıyla"))
                {
                    
                    _action.Invoke();
                    await Navigation.PushPopupAsync(new SuccessModal("Ürün başarıyla güncelledi", null),true);
                }
                else
                {
                    await Navigation.PushPopupAsync(new ErrorModal("Ürün güncelleme başarısız"), true);

                }
            }
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync(true);
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
    }
}