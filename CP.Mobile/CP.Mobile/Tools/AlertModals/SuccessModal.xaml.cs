using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.Tools.AlertModals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuccessModal : PopupPage
    {
        public SuccessModal(string Description)
        {
            InitializeComponent();
            lblDescription.Text = Description;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }

        private async void btnOk_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync(true);
        }
    }
}