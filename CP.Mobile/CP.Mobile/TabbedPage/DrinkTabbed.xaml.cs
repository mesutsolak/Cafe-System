using CP.Mobile.MasterDetailPages.PopupMenu;
using CP.Mobile.MasterDetailPages.PopupMenuContent;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.TabbedPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrinkTabbed : Xamarin.Forms.TabbedPage
    {

        public DrinkViewModel ViewModel => DrinkViewModel.Instance;
        public Xam.Plugin.PopupMenu Popup;

        public DrinkTabbed()
        {
            InitializeComponent();

            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            BarBackgroundColor = Color.FromHex("#eeeeee");
            BarTextColor = Color.Black;

            Popup = new Xam.Plugin.PopupMenu()
            {
                BindingContext = ViewModel
            };
            Popup.OnItemSelected += Popup_OnItemSelected; ;

            Popup.SetBinding(Xam.Plugin.PopupMenu.ItemsSourceProperty, "ListItems");

        }

        private async void Popup_OnItemSelected(string item)
        {
            switch (item)
            {
                case "Genel Durum":
                    await Navigation.PushPopupAsync(new DrinkGeneral(), true);
                    break;
                default:
                    break;
            }
        }

        private void DrinkGeneral_Clicked(object sender, EventArgs e)
        {
            Popup?.ShowPopup(sender as View);
        }
    }
}