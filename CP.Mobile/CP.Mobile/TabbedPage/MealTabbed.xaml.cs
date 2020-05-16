using CP.Mobile.MasterDetailPages.PopupMenu;
using CP.Mobile.MasterDetailPages.PopupMenuContent;
using CP.Mobile.Tools.AlertModals;
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
    public partial class MealTabbed : Xamarin.Forms.TabbedPage
    {
        public MealViewModel ViewModel => MealViewModel.Instance;
        public Xam.Plugin.PopupMenu Popup;

        public MealTabbed()
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
     
            Navigation.PopPopupAsync(true);

        }

        private async void Popup_OnItemSelected(string item)
        {
            switch (item)
            {
                case "Genel Durum":
                    await Navigation.PushPopupAsync(new MealGeneral(), true);
                    break;
                default:
                    break;
            }
        }

        private void MealGeneral_Clicked(object sender, EventArgs e)
        {
            Popup?.ShowPopup(sender as View);
        }
    }
}