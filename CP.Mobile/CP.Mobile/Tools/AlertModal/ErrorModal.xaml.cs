using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.Tools.AlertModal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public  partial class ErrorModal : PopupPage
    {       
        public ErrorModal()
        {
            InitializeComponent();
        }
        private async void PopupPage_BackgroundClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

    }
}