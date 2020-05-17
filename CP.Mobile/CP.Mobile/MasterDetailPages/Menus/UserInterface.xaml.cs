using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.MasterDetailPages.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserInterface : ContentPage
    {
        public UserInterface()
        {
            InitializeComponent();
            Navigation.PopPopupAsync(true);
        }

        private void btnUserInformationUpdate_Clicked(object sender, EventArgs e)
        {

        }
    }
}