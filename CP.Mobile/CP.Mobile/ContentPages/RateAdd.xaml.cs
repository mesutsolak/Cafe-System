using CP.Mobile.Tools.AlertModals;
using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
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
    public partial class RateAdd : PopupPage
    {
        RateService rs = new RateService();
        int _ProductId = 0;
        Action _action;
        public RateAdd(int ProductId, Action action)
        {
            InitializeComponent();
            _ProductId = ProductId;
            _action = action;
            int _UserId = Preferences.Get("UserId", 0);

            rs.Url = "api/Rate/Find/" + _ProductId + "/" + _UserId;
            var _rate = rs.ProductRate();

            lblNumber.Text = _rate.ToString();


        }

        private async void btnRateAdd_Clicked(object sender, EventArgs e)
        {
            rs.Url = "api/Rate/Add";
            var result = rs.Add(new RateDTO
            {
                ProductId = _ProductId,
                UserId = Preferences.Get("UserId", 0),
                RateValue = int.Parse(lblNumber.Text)
            });

            await Navigation.PopAllPopupAsync(true);

            if (result.Contains("Başarıyla"))
            {
                _action.Invoke();

                await Navigation.PushPopupAsync(new SuccessModal(result), true);
            }
            else
            {
                await Navigation.PushPopupAsync(new ErrorModal(result), true);
            }
        }

        private async void btnRateClose_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAllPopupAsync(true);
        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            var number = int.Parse(lblNumber.Text);
            if (number!=10)
            {
                number++;
                lblNumber.Text = number.ToString();
            }
           
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