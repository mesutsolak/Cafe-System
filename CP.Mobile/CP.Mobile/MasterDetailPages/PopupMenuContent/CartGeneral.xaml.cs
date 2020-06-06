using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.MasterDetailPages.PopupMenuContent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartGeneral : PopupPage
    {
        public CartGeneral(string name, int count, int price, int time)
        {

            InitializeComponent();

            lblName.Text = name;
            lblCount.Text = count.ToString();
            lblPrice.Text = price.ToString() + " TL";
            lblClock.Text = time.ToString() + " dk";
        }

        private async void btnClose_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync(true);
        }
    }
}